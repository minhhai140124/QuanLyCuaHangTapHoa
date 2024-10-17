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

            //Tìm kiếm khách hàng trong quản lý khách hàng bằng email
            if (!String.IsNullOrEmpty(searchStr))
            {
                searchStr = searchStr.ToLower();
                dsKhachHang = dsKhachHang.Where(s => s.Email.ToLower().Contains(searchStr)).ToList();
                ViewBag.dsKh = dsKhachHang;
            }
            else
            {
                ViewBag.dsKH = dsKhachHang;
            }
            return View();
        }


        //Thông tin khách hàng
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachhang = _db.KhachHangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }
        
       
        
    }
}