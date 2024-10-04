using QuanLyCuaHangTapHoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCuaHangTapHoa.Controllers
{
    public class HomeController : Controller
    {
         quantaphoaEntities _db = new quantaphoaEntities();
        // GET: Admin/Home
        public ActionResult Indexadmin()
        {
            if (Session["NV"] == null)
            {
                return RedirectToAction("Loginadmin", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult getDataOrder()
        {
            bool proxyCreation = _db.Configuration.ProxyCreationEnabled;
            try
            {
                _db.Configuration.ProxyCreationEnabled = false;

                //your stuff
                var result = _db.Orders.ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
            finally
            {
                //restore ProxyCreation to its original state
                _db.Configuration.ProxyCreationEnabled = proxyCreation;
            }
        }

        //Đăng nhập - đăng xuất admin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Loginadmin(NhanVien objUser)
        {
            if (ModelState.IsValid)
            {
                var obj = _db.NhanViens.Where(a => a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                //var data = _db.NhanViens.Where(s => s.Email.Equals(objUser.Email) && s.Password.Equals(objUser.Password)).ToList();
                if (obj != null && obj.MaChucVu == 2)
                {
                    Session["NV"] = obj;
                    Session["NVID"] = obj.Id;
                    return RedirectToAction("Indexadmin", "Home");
                }
                else if (obj != null && obj.MaChucVu == 1)
                {
                    Session["NV"] = obj;
                    Session["NVID"] = obj.Id;
                    return RedirectToAction("Indexadmin", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Không phải là tài khoản quản trị viên");
                }
            }
            return View(objUser);
        }
        [HttpGet]
        public ActionResult Loginadmin()
        {
            if (Session["NV"] != null)
            {
                return RedirectToAction("Indexadmin", "Home");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["NV"] = null;
            return RedirectToAction("Loginadmin", "Home");
        }
    }
}