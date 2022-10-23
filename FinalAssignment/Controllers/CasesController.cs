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
    public class CasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cases
        public ActionResult Index()
        {
            var cases = db.Cases.Include(c => c.CaseType).Include(c => c.Clinic);
            return View(cases.ToList());
        }

        // GET: Cases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // GET: Cases/Create
        [Authorize(Roles = "GP")]
        public ActionResult Create()
        {
            ViewBag.CaseTypeId = new SelectList(db.CaseTypes, "Id", "Name");
            ViewBag.ClinicId = new SelectList(db.Clinics, "Id", "Name");
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClinicId,CaseTypeId,StartTime,EndTime")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Cases.Add(@case);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CaseTypeId = new SelectList(db.CaseTypes, "Id", "Name", @case.CaseTypeId);
            ViewBag.ClinicId = new SelectList(db.Clinics, "Id", "Name", @case.ClinicId);
            return View(@case);
        }

        // GET: Cases/Edit/5
        [Authorize(Roles = "GP")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaseTypeId = new SelectList(db.CaseTypes, "Id", "Name", @case.CaseTypeId);
            ViewBag.ClinicId = new SelectList(db.Clinics, "Id", "Name", @case.ClinicId);
            return View(@case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClinicId,CaseTypeId,StartTime,EndTime")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@case).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CaseTypeId = new SelectList(db.CaseTypes, "Id", "Name", @case.CaseTypeId);
            ViewBag.ClinicId = new SelectList(db.Clinics, "Id", "Name", @case.ClinicId);
            return View(@case);
        }

        // GET: Cases/Delete/5
        [Authorize(Roles = "GP")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Case @case = db.Cases.Find(id);
            db.Cases.Remove(@case);
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
