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

            // Tìm kiếm khách hàng trong quản lí khách hàng bằng email 
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
        public ActionResult Edit(int id)
        {
            if (id.ToString() == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang nhanvien = _db.KhachHangs.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUser,FirstName,LastName,Email,Picture,Address,NgaySinh,CMT,Sdt,Password,ConfirmPassword")] KhachHang kh, HttpPostedFileBase file)
        {
            KhachHang khachhang = _db.KhachHangs.Find(kh.idUser);
            ModelState.Remove("Password");
            ModelState.Remove("ConfirmPassword");
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    String path = System.IO.Path.Combine(
                                            Server.MapPath("~/Hinh/KhachHang"), pic);
                    file.SaveAs(path);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                    khachhang.Picture = pic;
                }
                khachhang.FirstName = kh.FirstName;
                khachhang.LastName = kh.LastName;
                khachhang.Email = kh.Email;
                khachhang.Address = kh.Address;
                khachhang.ConfirmPassword = kh.ConfirmPassword;

                if (kh.NgaySinh != null)
                {
                    khachhang.NgaySinh = kh.NgaySinh;
                }
                if (kh.CMT != null)
                {
                    khachhang.CMT = kh.CMT;
                }

                if (kh.Sdt != null)
                {
                    khachhang.Sdt = kh.Sdt;
                }
                _db.Entry(khachhang).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("ProFile");
            }
            return View(kh);
        }
    }
}