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
    public class AssignedVideosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AssignedVideos
        public ActionResult Index()
        {
            var assignedVideos = db.AssignedVideos.Include(a => a.ExerciseInstruction).Include(a => a.ExerciseVideo);
            return View(assignedVideos.ToList());
        }

        // GET: AssignedVideos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedVideo assignedVideo = db.AssignedVideos.Find(id);
            if (assignedVideo == null)
            {
                return HttpNotFound();
            }
            return View(assignedVideo);
        }

        // GET: AssignedVideos/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseInstructionID = new SelectList(db.ExerciseInstructions, "ExerciseInstructionID", "Remark");
            ViewBag.ExerciseVideoID = new SelectList(db.ExerciseVideos, "ExerciseVideoID", "VideoURL");
            return View();
        }

        // POST: AssignedVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignedVideoID,ExerciseInstructionID,ExerciseVideoID")] AssignedVideo assignedVideo)
        {
            if (ModelState.IsValid)
            {
                db.AssignedVideos.Add(assignedVideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseInstructionID = new SelectList(db.ExerciseInstructions, "ExerciseInstructionID", "Remark", assignedVideo.ExerciseInstructionID);
            ViewBag.ExerciseVideoID = new SelectList(db.ExerciseVideos, "ExerciseVideoID", "VideoURL", assignedVideo.ExerciseVideoID);
            return View(assignedVideo);
        }

        // GET: AssignedVideos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedVideo assignedVideo = db.AssignedVideos.Find(id);
            if (assignedVideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseInstructionID = new SelectList(db.ExerciseInstructions, "ExerciseInstructionID", "Remark", assignedVideo.ExerciseInstructionID);
            ViewBag.ExerciseVideoID = new SelectList(db.ExerciseVideos, "ExerciseVideoID", "VideoURL", assignedVideo.ExerciseVideoID);
            return View(assignedVideo);
        }

        // POST: AssignedVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignedVideoID,ExerciseInstructionID,ExerciseVideoID")] AssignedVideo assignedVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignedVideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseInstructionID = new SelectList(db.ExerciseInstructions, "ExerciseInstructionID", "Remark", assignedVideo.ExerciseInstructionID);
            ViewBag.ExerciseVideoID = new SelectList(db.ExerciseVideos, "ExerciseVideoID", "VideoURL", assignedVideo.ExerciseVideoID);
            return View(assignedVideo);
        }

        // GET: AssignedVideos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedVideo assignedVideo = db.AssignedVideos.Find(id);
            if (assignedVideo == null)
            {
                return HttpNotFound();
            }
            return View(assignedVideo);
        }

        // POST: AssignedVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignedVideo assignedVideo = db.AssignedVideos.Find(id);
            db.AssignedVideos.Remove(assignedVideo);
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
