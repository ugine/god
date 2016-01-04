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
    public class ExerciseVideosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExerciseVideos
        public ActionResult Index()
        {
            var exerciseVideos = db.ExerciseVideos.Include(e => e.Exercise);
            return View(exerciseVideos.ToList());
        }

        // GET: ExerciseVideos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseVideo exerciseVideo = db.ExerciseVideos.Find(id);
            if (exerciseVideo == null)
            {
                return HttpNotFound();
            }
            return View(exerciseVideo);
        }

        // GET: ExerciseVideos/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "Name");
            return View();
        }

        // POST: ExerciseVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExerciseVideoID,VideoURL,ExerciseID")] ExerciseVideo exerciseVideo)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseVideos.Add(exerciseVideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "Name", exerciseVideo.ExerciseID);
            return View(exerciseVideo);
        }

        // GET: ExerciseVideos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseVideo exerciseVideo = db.ExerciseVideos.Find(id);
            if (exerciseVideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "Name", exerciseVideo.ExerciseID);
            return View(exerciseVideo);
        }

        // POST: ExerciseVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExerciseVideoID,VideoURL,ExerciseID")] ExerciseVideo exerciseVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseVideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "Name", exerciseVideo.ExerciseID);
            return View(exerciseVideo);
        }

        // GET: ExerciseVideos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseVideo exerciseVideo = db.ExerciseVideos.Find(id);
            if (exerciseVideo == null)
            {
                return HttpNotFound();
            }
            return View(exerciseVideo);
        }

        // POST: ExerciseVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseVideo exerciseVideo = db.ExerciseVideos.Find(id);
            db.ExerciseVideos.Remove(exerciseVideo);
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
