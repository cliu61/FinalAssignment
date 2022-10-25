using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalAssignment.Models;
using Microsoft.AspNet.Identity;

namespace FinalAssignment.Controllers
{
    public class ClinicsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clinics
        public ActionResult Index()
        {
            return View(db.Clinics.ToList());     
        }

        // GET: Clinics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            clinic.Ratings = db.Ratings.Include("User").Where(r => r.ClinicId == clinic.Id).ToList();
            if (clinic.Ratings.Count != 0)
            {
                var total = 0;
                foreach (var rate in clinic.Ratings)
                {
                    total += rate.Rate;
                }
                clinic.AvgRating = (decimal)total / clinic.Ratings.Count;
            }
            return View(clinic);
        }

        // GET: Clinics/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
                return View();
        }

        // POST: Clinics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,ContactNumber")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                db.Clinics.Add(clinic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clinic);
        }

        // GET: Clinics/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // POST: Clinics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,ContactNumber")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clinic);
        }

        // GET: Clinics/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // POST: Clinics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clinic clinic = db.Clinics.Find(id);
            db.Clinics.Remove(clinic);
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

        public JsonResult GetClinics()
        {
            var clinics = db.Clinics.ToList();
            return new JsonResult { Data = clinics , JsonRequestBehavior = JsonRequestBehavior.AllowGet};

        }

        [HttpPost]
        [Authorize]
        public ActionResult RateClinic(int Id, string Comment, int Rate)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var rate = new Rating { ClinicId = Id, UserId = userId, Comment = Comment, Rate = Rate };
                db.Ratings.Add(rate);
                db.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return RedirectToAction($"Details/{Id}");
        }
    }
}
