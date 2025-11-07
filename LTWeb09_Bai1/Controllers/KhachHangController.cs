using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb09_Bai1.Models;

namespace LTWeb09_Bai1.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        Model1 data = new Model1();

        // =============== ĐĂNG KÝ ===============
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra trùng tài khoản
                var check = data.KhachHangs.FirstOrDefault(k => k.TaiKhoan == kh.TaiKhoan);
                if (check != null)
                {
                    ViewBag.ThongBao = "⚠️ Tên tài khoản đã tồn tại!";
                    return View();
                }

                // Tự sinh mã khách hàng 
                kh.MaKH = data.KhachHangs.Any()
                    ? data.KhachHangs.Max(k => k.MaKH) + 1
                    : 1;

                data.KhachHangs.Add(kh);
                data.SaveChanges();

                ViewBag.ThongBao = "✅ Đăng ký thành công! Hãy đăng nhập.";
                return RedirectToAction("DangNhap");
            }

            return RedirectToAction("Index", "Home");
        }

        // =============== ĐĂNG NHẬP ===============
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string TaiKhoan, string MatKhau)
        {
            var kh = data.KhachHangs.FirstOrDefault(k => k.TaiKhoan == TaiKhoan && k.MatKhau == MatKhau);
            if (kh != null)
            {
                Session["KhachHang"] = kh;
                Session["TenKH"] = kh.HoTen;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ThongBao = "❌ Sai tài khoản hoặc mật khẩu!";
            return View();
        }

        // =============== ĐĂNG XUẤT ===============
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}