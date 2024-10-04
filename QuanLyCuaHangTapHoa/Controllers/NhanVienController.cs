using QuanLyCuaHangTapHoa.Models;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyCuaHangTapHoa.Controllers
{
    public class NhanVienController : Controller
    {
        private quantaphoaEntities _db = new quantaphoaEntities();

        // GET: NhanVien
        public ActionResult Index()
        {
            var dsNhanVien = _db.NhanViens.ToList();
            return View(dsNhanVien);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Delete(int? id)
        {
            return View();
        }

        public ActionResult Detail(int? id)
        {
            return View();
        }
    }
}