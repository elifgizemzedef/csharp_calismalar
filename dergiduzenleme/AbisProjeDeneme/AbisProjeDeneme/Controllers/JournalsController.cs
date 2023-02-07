using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbisProjeDeneme.DataContext;
using AbisProjeDeneme.Models;

namespace AbisProjeDeneme.Controllers
{
    public class JournalsController : Controller
    {
        private JournalDbContext db = new JournalDbContext();

        // GET: Journals
        public ActionResult Index()
        {
            return View(db.Journals.ToList());
        }

        // GET: Journals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalClass journal = db.Journals.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }

        // GET: Journals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Journals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Group,IsISI")] JournalClass journal)
        {
            if (ModelState.IsValid)
            {
                db.Journals.Add(journal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(journal);
        }

        // GET: Journals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalClass journal = db.Journals.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }

        // POST: Journals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Group,IsISI")] JournalClass journal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(journal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(journal);
        }

        // GET: Journals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalClass journal = db.Journals.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }

        // POST: Journals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JournalClass journal = db.Journals.Find(id);
            db.Journals.Remove(journal);
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
