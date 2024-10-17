using System;
using QuanLyCuaHangTapHoa.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCuaHangTapHoa.Controllers
{
    public class GiohangController : Controller
    {

        quantaphoaEntities _db = new quantaphoaEntities();

        // GET: Giohang - Chỉ hiển thị
        public ActionResult Index()
        {
            List<Giohang> listGioHang = Laygiohang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(listGioHang);
        }


        // Hàm lấy giỏ hàng
        public List<Giohang> Laygiohang()
        {
            List<Giohang> listGiohang = Session["Giohang"] as List<Giohang>;
            if (listGiohang == null)
            {
                listGiohang = new List<Giohang>();
                Session["Giohang"] = listGiohang;
            }
            return listGiohang;
        }

        // Tính tổng số lượng
        public int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<Giohang> listGiohang = Session["Giohang"] as List<Giohang>;
            if (listGiohang != null)
            {
                iTongSoLuong = listGiohang.Sum(n => n.SoLuong);
            }
            return iTongSoLuong;
        }

        // Tính tổng tiền
        private double TongTien()
        {
            double iTongTien = 0;
            List<Giohang> listGiohang = Session["Giohang"] as List<Giohang>;
            if (listGiohang != null)
            {
                iTongTien = listGiohang.Sum(n => n.Price);
            }
            return iTongTien;
        }

        // Thêm sản phẩm vào giỏ hàng - Chức năng duy nhất còn hoạt động
        public ActionResult Themgiohang(int IdProduct, string strURL)
        {
            List<Giohang> listGiohang = Laygiohang();
            Giohang product = listGiohang.Find(n => n.IdProduct == IdProduct);
            if (product == null)
            {
                product = new Giohang(IdProduct);
                listGiohang.Add(product);
                return Redirect(strURL);
            }
            else
            {
                product.SoLuong++;
                return Redirect(strURL);
            }
        }

        // Các action khác giữ nguyên nhưng return về trang hiện tại
        public ActionResult Xoagiohang(int IdProduct)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Capnhatgiohang(int IdProduct, FormCollection f)
        {
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll()
        {
            return RedirectToAction("Index");
        }

        public ActionResult DatHang()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Payment()
        {
            return RedirectToAction("Index");
        }
    }

}



