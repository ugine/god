using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TherapyBuddy.Models;

namespace TherapyBuddy.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExerciseRegionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExerciseRegions
        public ActionResult Index()
        {
            return View(db.ExerciseRegions.ToList());
        }

        // GET: ExerciseRegions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseRegion exerciseRegion = db.ExerciseRegions.Find(id);
            if (exerciseRegion == null)
            {
                return HttpNotFound();
            }
            return View(exerciseRegion);
        }

        // GET: ExerciseRegions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExerciseRegions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExerciseRegionID,Name")] ExerciseRegion exerciseRegion)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseRegions.Add(exerciseRegion);
                db.SaveChanges();
                TempData["Message"] = "Successfully created Exercise Region -" + exerciseRegion.Name;
                return RedirectToAction("Index");
            }

            return View(exerciseRegion);
        }

        // GET: ExerciseRegions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseRegion exerciseRegion = db.ExerciseRegions.Find(id);
            if (exerciseRegion == null)
            {
                return HttpNotFound();
            }
            return View(exerciseRegion);
        }

        // POST: ExerciseRegions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExerciseRegionID,Name")] ExerciseRegion exerciseRegion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseRegion).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Successfully editted Exercise Region -" + exerciseRegion.Name;
                return RedirectToAction("Index");
            }
            return View(exerciseRegion);
        }

        // GET: ExerciseRegions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseRegion exerciseRegion = db.ExerciseRegions.Find(id);
            if (exerciseRegion == null)
            {
                return HttpNotFound();
            }
            return View(exerciseRegion);
        }

        // POST: ExerciseRegions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseRegion exerciseRegion = db.ExerciseRegions.Find(id);
            db.ExerciseRegions.Remove(exerciseRegion);
            db.SaveChanges();
            TempData["Message"] = "Successfully deleted Exercise Region -" + exerciseRegion.Name;
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
