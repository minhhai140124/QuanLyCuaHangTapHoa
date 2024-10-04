using QuanLyCuaHangTapHoa.Models;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyCuaHangTapHoa.Controllers
{
    public class KhachHangController : Controller
    {
        private quantaphoaEntities _db = new quantaphoaEntities();

        // GET: KhachHang
        public ActionResult Index()
        {
            var dsKhachHang = _db.KhachHangs.ToList();
            return View(dsKhachHang);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
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