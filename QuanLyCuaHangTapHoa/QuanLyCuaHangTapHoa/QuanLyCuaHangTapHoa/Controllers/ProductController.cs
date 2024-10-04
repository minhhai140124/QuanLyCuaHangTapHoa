using QuanLyCuaHangTapHoa.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCuaHangTapHoa.Controllers
{
    public class GiohangController : Controller
    {
        /*quantaphoaEntities _db = new quantaphoaEntities();*/

        // GET: Giohang
        public ActionResult Index()
        {
            /*List<Giohang> listGioHang = Laygiohang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();*/
            return View(/*listGioHang*/);
        }

        /*
        // Các phương thức xử lý giỏ hàng đã được comment out
        public List<Giohang> Laygiohang() { ... }
        public int TongSoLuong() { ... }
        private double TongTien() { ... }
        */

        public ActionResult Xoagiohang(int IdProduct)
        {
            /*
            // Logic xóa sản phẩm khỏi giỏ hàng đã được comment out
            */
            return RedirectToAction("Index", "Giohang");
        }

        public ActionResult Capnhatgiohang(int IdProduct, FormCollection f)
        {
            /*
            // Logic cập nhật giỏ hàng đã được comment out
            */
            return RedirectToAction("Index", "Giohang");
        }

        public ActionResult DeleteAll()
        {
            /*
            // Logic xóa tất cả sản phẩm khỏi giỏ hàng đã được comment out
            */
            return RedirectToAction("Indexadminsp", "Product");
        }

        public ActionResult Themgiohang(int IdProduct, string strURL)
        {
            /*
            // Logic thêm sản phẩm vào giỏ hàng đã được comment out
            */
            return Redirect(strURL);
        }

        [HttpGet]
        public ActionResult DatHang()
        {
            /*
            // Logic kiểm tra và lấy thông tin giỏ hàng đã được comment out
            */
            return View(/*listGiohang*/);
        }

        public ActionResult DatHang2(int id)
        {
            /*
            // Logic xử lý đặt hàng đã được comment out
            */
            return RedirectToAction("Xacnhandonhang", "Giohang");
        }

        public ActionResult BuyNow(int IdProduct)
        {
            /*
            // Logic mua ngay đã được comment out
            */
            return RedirectToAction("Indexadminsp", "Product");
        }

        public ActionResult Xacnhandonhang()
        {
            return View();
        }

        public ActionResult PaymentConfirm()
        {
            /*
            // Logic xác nhận thanh toán đã được comment out
            */
            return View();
        }
    }
}