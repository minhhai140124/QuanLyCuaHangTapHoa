using DinkToPdf;
using QuanLyCuaHangTapHoa.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCuaHangTapHoa.Controllers
{
    public class OrderController : Controller
    {
        quantaphoaEntities _db = new quantaphoaEntities();

        // GET: Order
        public ActionResult Index(string searchStr, string sort, int? page)
        {
            const int pageSize = 10;
            int pageNumber = page ?? 1;
            var orders = _db.Orders.Include(o => o.NhanVien).ToList();

            // Tìm kiếm đơn hàng theo ID đơn hàng
            if (!String.IsNullOrEmpty(searchStr))
            {
                searchStr = searchStr.ToLower();
                ViewBag.searchStr = searchStr;
                orders = orders.Where(p => p.ID.ToString().ToLower().Contains(searchStr)).ToList();
            }
            else
            {
                orders = Sort(orders, sort).ToList();
            }

            // Phân trang
            int totalOrders = orders.Count();
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalOrders / pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.orderList = orders.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return View();
        }

        // Phương thức Sort được sửa để nhận vào danh sách orders
        private IEnumerable<Order> Sort(IEnumerable<Order> orders, string sort)
        {
            ViewBag.Sort = sort;
            var orderList = orders.ToList();

            foreach (var order in orderList)
            {
                if (order.NgayGiao < DateTime.Now && order.Status == "Đang giao hàng")
                {
                    Order editOrder = _db.Orders.Find(order.ID);
                    editOrder.Status = "Hoàn thành";
                    editOrder.Payment = true;
                    _db.Entry(editOrder).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }

            if (String.IsNullOrEmpty(sort))
            {
                return orderList.OrderBy(s => s.NgayDat);
            }
            else
            {
                switch (sort)
                {
                    case "Wait":
                        return orderList.Where(s => s.Status == "Chưa giao hàng");
                    case "Deli":
                        return orderList.Where(s => s.Status == "Đang giao hàng");
                    case "Done":
                        return orderList.Where(s => s.Status == "Hoàn thành");
                    case "Cancel":
                        return orderList.Where(s => s.Status == "Đã hủy");
                    default:
                        return orderList;
                }
            }
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = _db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            var orderDetails = _db.Order_Detail.Where(item => item.ID_Order == order.ID).ToList();
            ViewBag.OrderDetails = orderDetails.Select(item => new
            {
                Item = item,
                Product = _db.Products.Find(item.ID_Product)
            }).ToList();

            return View(order);
        }

        public ActionResult Edit(int Id)
        {
            if (Id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = _db.Orders
                             .Include(o => o.Order_Detail)
                             .FirstOrDefault(o => o.ID == Id);

            if (order == null)
            {
                return HttpNotFound();
            }

            ViewBag.Status = new SelectList(_db.Order_Status, "Status", "Status", order.Status);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] Order model)
        {
            Order order = _db.Orders.Find(model.ID);

            if (order == null)
            {
                return HttpNotFound();
            }

            order.Status = "Đang giao hàng";
            order.NgayGiao = DateTime.Now.AddDays(3);

            var orderDetails = _db.Order_Detail.Where(item => item.ID_Order == order.ID).ToList();

            foreach (var detail in orderDetails)
            {
                Product product = _db.Products.Find(detail.ID_Product);
                product.SoLuong -= 1;
                product.ProductSold += 1;
                _db.Entry(product).State = EntityState.Modified;
            }

            _db.Entry(order).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}
