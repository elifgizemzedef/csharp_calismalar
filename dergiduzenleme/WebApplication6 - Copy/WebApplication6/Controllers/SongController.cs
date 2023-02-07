using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6.DataContext;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class SongController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Song
        public ActionResult Index()
        {
            return View(db.Songs.ToList());
        }

        // GET: Song/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SongClass songClass = db.Songs.Find(id);
            if (songClass == null)
            {
                return HttpNotFound();
            }
            return View(songClass);
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Song/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,singer,album")] SongClass songClass)
        {
            if (ModelState.IsValid)
            {
                db.Songs.Add(songClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(songClass);
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SongClass songClass = db.Songs.Find(id);
            if (songClass == null)
            {
                return HttpNotFound();
            }
            return View(songClass);
        }

        // POST: Song/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,singer,album")] SongClass songClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(songClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(songClass);
        }

        // GET: Song/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SongClass songClass = db.Songs.Find(id);
            if (songClass == null)
            {
                return HttpNotFound();
            }
            return View(songClass);
        }

        // POST: Song/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SongClass songClass = db.Songs.Find(id);
            db.Songs.Remove(songClass);
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
