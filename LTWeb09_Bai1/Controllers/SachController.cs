using LTWeb09_Bai1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb09_Bai1.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        Model1 data=new Model1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HTSachTHeoChuDe(int id)
        {
            List<Sach> ds = data.Saches.Where(s => s.MaChuDe == id).OrderBy(s=>s.GiaBan).ToList();
            return PartialView(ds);
        }
    }
}