using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ass2mvc4.Models;

namespace ass2mvc4.Controllers
{
    public class SaleRecordController : Controller
    {
        private bookSaleEntities3 db = new bookSaleEntities3();

        // GET: /SaleRecord/
        public ActionResult Index()
        {
            var salerecords = db.saleRecords.Include(s => s.book).Include(s => s.user);
            return View(salerecords.ToList());
        }

        // GET: /SaleRecord/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            saleRecord salerecord = db.saleRecords.Find(id);
            if (salerecord == null)
            {
                return HttpNotFound();
            }
            return View(salerecord);
        }

        // GET: /SaleRecord/Create
        public ActionResult Create()
        {
            ViewBag.ISBN = new SelectList(db.books, "ISBN", "bookName");
            ViewBag.userId = new SelectList(db.users, "userId", "lastName");
            return View();
        }

        // POST: /SaleRecord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="saleId,userId,ISBN")] saleRecord salerecord)
        {
            if (ModelState.IsValid)
            {
                db.saleRecords.Add(salerecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ISBN = new SelectList(db.books, "ISBN", "bookName", salerecord.ISBN);
            ViewBag.userId = new SelectList(db.users, "userId", "lastName", salerecord.userId);
            return View(salerecord);
        }

        // GET: /SaleRecord/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            saleRecord salerecord = db.saleRecords.Find(id);
            if (salerecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.ISBN = new SelectList(db.books, "ISBN", "bookName", salerecord.ISBN);
            ViewBag.userId = new SelectList(db.users, "userId", "lastName", salerecord.userId);
            return View(salerecord);
        }

        // POST: /SaleRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="saleId,userId,ISBN")] saleRecord salerecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salerecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ISBN = new SelectList(db.books, "ISBN", "bookName", salerecord.ISBN);
            ViewBag.userId = new SelectList(db.users, "userId", "lastName", salerecord.userId);
            return View(salerecord);
        }

        // GET: /SaleRecord/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            saleRecord salerecord = db.saleRecords.Find(id);
            if (salerecord == null)
            {
                return HttpNotFound();
            }
            return View(salerecord);
        }

        // POST: /SaleRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            saleRecord salerecord = db.saleRecords.Find(id);
            db.saleRecords.Remove(salerecord);
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
