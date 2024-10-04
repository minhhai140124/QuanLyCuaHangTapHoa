using QuanLyCuaHangTapHoa.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCuaHangTapHoa.Controllers
{
    public class KhachHangController : Controller
    {
        quantaphoaEntities _db = new quantaphoaEntities();
        // GET: KhachHang
        public ActionResult Index(string searchStr)
        {
            NhanVien nv = (NhanVien)Session["NV"];
            var dsKhachHang = _db.KhachHangs.ToList();


            return View();
        }

        
       
        
    }
}