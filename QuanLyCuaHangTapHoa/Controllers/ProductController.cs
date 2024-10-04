using PagedList;
using QuanLyCuaHangTapHoa.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyCuaHangTapHoa.Utils;
using System.Data.Entity;
using System.Net;
using System.Windows.Input;

namespace QuanLyCuaHangTapHoa.Controllers
{
    public class ProductController : Controller
    {
        quantaphoaEntities _db = new quantaphoaEntities();
        public static readonly string PRODUCT_IMG_PATH = ConfigParser.Parse("products_img_path");
        public ActionResult Indexadminsp(string sort, int? page, string searchString, int? category)
        {
            const int pageSize = 10;
            int pageNumber = page ?? 1;

            var products = _db.Products.Include("Catalog").ToList();

            if (category.HasValue && category != 0) // Assuming 0 means "all categories"
            {
                products = products.Where(p => p.Catalog.ID == category).ToList();
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                products = products.Where(p => p.ProductName.ToLower().Contains(searchString) ||
                                               p.Catalog.CatalogName.ToLower().Contains(searchString)).ToList();
            }

            // Filter products based on the sort parameter
            if (sort == "pre-sold")
            {
                products = products.Where(p => p.SoLuong > 0 && p.SoLuong <= 50).ToList();
            }
            else if (sort == "sold")
            {
                products = products.Where(p => p.SoLuong == 0).ToList();
            }
            else if (sort == "available")
            {
                products = products.Where(p => p.SoLuong > 50).ToList();
            }

            ViewBag.totalPage = Math.Ceiling((double)products.Count() / pageSize);
            ViewBag.products = products.ToPagedList(pageNumber, pageSize);
            ViewBag.searchStr = searchString;
            ViewBag.Sort = sort;
            ViewBag.category = category;

            return View(ViewBag.products);
        }

        public ActionResult Create()
        {
            ViewBag.CatalogId = new SelectList(_db.Catalogs, "ID", "CatalogName");
            return View();
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product sanPham)
        {
            if (ModelState.IsValid)
            {
                if (sanPham.ProductThumbnailStream != null)
                {
                    string extension = Path.GetExtension(sanPham.ProductThumbnailStream.FileName).ToLower();
                    string modifiedFileName = $"{DateTime.Now.ToString("hhmmss_ddMMyyyy")}{extension}";
                    sanPham.ProductThumbnailStream.SaveAs($"{Server.MapPath(PRODUCT_IMG_PATH)}/{modifiedFileName}");
                    sanPham.Picture = modifiedFileName;
                }
                sanPham.NgayNhapHang = DateTime.Now;
                Random prCode = new Random();
                sanPham.ProductCode = String.Concat("PR", prCode.Next(5000, 7000).ToString());
                sanPham.ProductSold = 0;
                sanPham.UnitPrice = sanPham.ProductSale != null
                    ? (sanPham.UnitPrice = sanPham.PriceOld - (sanPham.PriceOld * int.Parse(sanPham.ProductSale)) / 100)
                    : sanPham.UnitPrice = sanPham.PriceOld;

                // Thêm sản phẩm trực tiếp vào cơ sở dữ liệu
                if (sanPham.PriceOld >= 0)
                {
                    _db.Products.Add(sanPham);
                    _db.SaveChanges();
                    return RedirectToAction("Indexadminsp");
                }
                else
                {
                    // Xử lý trường hợp dữ liệu không hợp lệ
                    ModelState.AddModelError("", "Dữ liệu không hợp lệ");
                }
            }

            ViewBag.CatalogId = new SelectList(_db.Catalogs, "ID", "CatalogName", sanPham.CatalogId);
            return View();


        }
        
    }
}