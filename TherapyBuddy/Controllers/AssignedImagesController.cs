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
    public class AssignedImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AssignedImages
        public ActionResult Index()
        {
            var assignedImages = db.AssignedImages.Include(a => a.ExerciseImage).Include(a => a.ExerciseInstruction);
            return View(assignedImages.ToList());
        }

        // GET: AssignedImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedImage assignedImage = db.AssignedImages.Find(id);
            if (assignedImage == null)
            {
                return HttpNotFound();
            }
            return View(assignedImage);
        }

        // GET: AssignedImages/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseImageID = new SelectList(db.ExerciseImages, "ExerciseImageID", "ImageURL");
            ViewBag.ExerciseInstructionID = new SelectList(db.ExerciseInstructions, "ExerciseInstructionID", "Remark");
            return View();
        }

        // POST: AssignedImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignedImageID,ExerciseInstructionID,ExerciseImageID")] AssignedImage assignedImage)
        {
            if (ModelState.IsValid)
            {
                db.AssignedImages.Add(assignedImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseImageID = new SelectList(db.ExerciseImages, "ExerciseImageID", "ImageURL", assignedImage.ExerciseImageID);
            ViewBag.ExerciseInstructionID = new SelectList(db.ExerciseInstructions, "ExerciseInstructionID", "Remark", assignedImage.ExerciseInstructionID);
            return View(assignedImage);
        }

        // GET: AssignedImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedImage assignedImage = db.AssignedImages.Find(id);
            if (assignedImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseImageID = new SelectList(db.ExerciseImages, "ExerciseImageID", "ImageURL", assignedImage.ExerciseImageID);
            ViewBag.ExerciseInstructionID = new SelectList(db.ExerciseInstructions, "ExerciseInstructionID", "Remark", assignedImage.ExerciseInstructionID);
            return View(assignedImage);
        }

        // POST: AssignedImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignedImageID,ExerciseInstructionID,ExerciseImageID")] AssignedImage assignedImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignedImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseImageID = new SelectList(db.ExerciseImages, "ExerciseImageID", "ImageURL", assignedImage.ExerciseImageID);
            ViewBag.ExerciseInstructionID = new SelectList(db.ExerciseInstructions, "ExerciseInstructionID", "Remark", assignedImage.ExerciseInstructionID);
            return View(assignedImage);
        }

        // GET: AssignedImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedImage assignedImage = db.AssignedImages.Find(id);
            if (assignedImage == null)
            {
                return HttpNotFound();
            }
            return View(assignedImage);
        }

        // POST: AssignedImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignedImage assignedImage = db.AssignedImages.Find(id);
            db.AssignedImages.Remove(assignedImage);
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
