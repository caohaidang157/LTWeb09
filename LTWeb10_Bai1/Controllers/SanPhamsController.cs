using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTWeb10_Bai1.Models;

namespace LTWeb10_Bai1.Controllers
{
    public class SanPhamsController : Controller
    {
        private Model1 db = new Model1();

        // GET: SanPhams
        public ActionResult Index()
        {
            return View(db.tblSanPhams.ToList());
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSanPham tblSanPham = db.tblSanPhams.Find(id);
            if (tblSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tblSanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,DonGia,HinhAnh,MoTa,SoLuong")] tblSanPham tblSanPham)
        {
            if (ModelState.IsValid)
            {
                db.tblSanPhams.Add(tblSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSanPham);
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSanPham tblSanPham = db.tblSanPhams.Find(id);
            if (tblSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tblSanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,DonGia,HinhAnh,MoTa,SoLuong")] tblSanPham tblSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSanPham);
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSanPham tblSanPham = db.tblSanPhams.Find(id);
            if (tblSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tblSanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSanPham tblSanPham = db.tblSanPhams.Find(id);
            db.tblSanPhams.Remove(tblSanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
