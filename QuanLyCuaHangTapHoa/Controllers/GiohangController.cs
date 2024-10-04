using System;
using System.Collections.Generic;
using System.Web.Mvc;
using QuanLyCuaHangTapHoa.Models;

namespace QuanLyCuaHangTapHoa.Controllers
{
    public class GiohangController : Controller
    {
        private quantaphoaEntities db = new quantaphoaEntities();

        // GET: Giohang
        public ActionResult Index()
        {
            List<Giohang> giohang = Session["Giohang"] as List<Giohang>;
            return View(giohang);
        }

        // Action để xử lý đặt hàng
        public ActionResult DatHang()
        {
            // Xử lý logic đặt hàng ở đây
            return View();
        }

        // Các action khác như Capnhatgiohang, Xoagiohang, DeleteAll
    }
}