using LTWeb09_Bai1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb09_Bai1.Controllers
{
    public class NhaXuatBanController : Controller
    {
        Model1 data=new Model1();
        // GET: NhaXuatBan
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HTSachTHeoNXB(int id)
        {
            List<Sach> ds = data.Saches.Where(s => s.MaNXB == id).OrderBy(s=>s.GiaBan).ToList();
            return PartialView(ds);
        }
    }
}