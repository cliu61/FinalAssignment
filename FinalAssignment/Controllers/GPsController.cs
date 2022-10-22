using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalAssignment.Models;

namespace FinalAssignment.Controllers
{
    public class GPsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GPs
        public ActionResult Index()
        {
            return View(db.GPs.ToList());
        }

        // GET: GPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GP gP = db.GPs.Find(id);
            if (gP == null)
            {
                return HttpNotFound();
            }
            return View(gP);
        }

        // GET: GPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GPId,FirstName,LastName,Specialist")] GP gP)
        {
            if (ModelState.IsValid)
            {
                db.GPs.Add(gP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gP);
        }

        // GET: GPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GP gP = db.GPs.Find(id);
            if (gP == null)
            {
                return HttpNotFound();
            }
            return View(gP);
        }

        // POST: GPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GPId,FirstName,LastName,Specialist")] GP gP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gP);
        }

        // GET: GPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GP gP = db.GPs.Find(id);
            if (gP == null)
            {
                return HttpNotFound();
            }
            return View(gP);
        }

        // POST: GPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GP gP = db.GPs.Find(id);
            db.GPs.Remove(gP);
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
