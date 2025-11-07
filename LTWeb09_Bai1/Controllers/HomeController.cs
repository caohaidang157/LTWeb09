using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb09_Bai1.Models;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Security.Policy;

namespace LTWeb09_Bai1.Controllers
{
    public class HomeController : Controller
    {
        Model1 data=new Model1();
        public ActionResult Index()
        {
            List<Sach>ds=data.Saches.ToList();
            return View(ds);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DSMenu_ChuDe()
        {
            List<ChuDe>ds=data.ChuDes.Take(10).ToList();
            return PartialView(ds);
        }
        public ActionResult DSMenu_NXB()
        {
            List<NhaXuatBan>ds=data.NhaXuatBans.ToList();
            return PartialView(ds);
        }
        public ActionResult Details(int id)
        {
            var sach = data.Saches
                .Include(s => s.ThamGIas.Select(tg => tg.TacGia))
                .Include(s => s.ChuDe)
                .Include(s => s.NhaXuatBan)
                .FirstOrDefault(s => s.MaSach == id);

            if (sach == null)
                return HttpNotFound();

            // Lấy danh sách sách cùng chủ đề
            var sachCungChuDe = data.Saches
                .Where(s => s.MaChuDe == sach.MaChuDe && s.MaSach != sach.MaSach)
                .Take(4)
                .ToList();

            // Lấy danh sách sách cùng nhà xuất bản
            var sachCungNXB = data.Saches
                .Where(s => s.MaNXB == sach.MaNXB && s.MaSach != sach.MaSach)
                .Take(4)
                .ToList();

            ViewBag.SachCungChuDe = sachCungChuDe;
            ViewBag.SachCungNXB = sachCungNXB;

            return View(sach);
        }
        public ActionResult TimKiem(string tenSach, int? maChuDe, string[] gia)
        {
            var ds = data.Saches.AsQueryable();

            // Lọc theo tên sách
            if (!string.IsNullOrEmpty(tenSach))
                ds = ds.Where(s => s.TenSach.Contains(tenSach));

            // Lọc theo chủ đề
            if (maChuDe.HasValue && maChuDe.Value > 0)
                ds = ds.Where(s => s.MaChuDe == maChuDe.Value);

            // Lọc theo mức giá
            if (gia != null && gia.Length > 0)
            {
                foreach (var muc in gia)
                {
                    switch (muc)
                    {
                        case "0-10000":
                            ds = ds.Where(s => s.GiaBan >= 0 && s.GiaBan <= 10000);
                            break;
                        case "11000-20000":
                            ds = ds.Where(s => s.GiaBan >= 11000 && s.GiaBan <= 20000);
                            break;
                        case "21000-40000":
                            ds = ds.Where(s => s.GiaBan >= 21000 && s.GiaBan <= 40000);
                            break;
                        case "40000+":
                            ds = ds.Where(s => s.GiaBan > 40000);
                            break;
                    }
                }
            }

            ViewBag.MaChuDe = new SelectList(data.ChuDes.ToList(), "MaChuDe", "TenChuDe");
            return View(ds.ToList());
        }


    }
}