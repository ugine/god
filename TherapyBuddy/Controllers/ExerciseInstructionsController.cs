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
    public class ExerciseInstructionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExerciseInstructions
        public ActionResult Index()
        {
            var exerciseInstructions = db.ExerciseInstructions.Include(e => e.Assignment);
            return View(exerciseInstructions.ToList());
        }

        // GET: ExerciseInstructions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseInstruction exerciseInstruction = db.ExerciseInstructions.Find(id);
            if (exerciseInstruction == null)
            {
                return HttpNotFound();
            }
            return View(exerciseInstruction);
        }

        // GET: ExerciseInstructions/Create
        public ActionResult Create()
        {
            ViewBag.AssignmentID = new SelectList(db.Assignments, "AssignmentID", "AssignmentID");
            return View();
        }

        // POST: ExerciseInstructions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExerciseInstructionID,Number_Of_Reps,Frequency_Per_Day,Reps_Completed,Remark,AssignmentID")] ExerciseInstruction exerciseInstruction)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseInstructions.Add(exerciseInstruction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssignmentID = new SelectList(db.Assignments, "AssignmentID", "AssignmentID", exerciseInstruction.AssignmentID);
            return View(exerciseInstruction);
        }

        // GET: ExerciseInstructions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseInstruction exerciseInstruction = db.ExerciseInstructions.Find(id);
            if (exerciseInstruction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssignmentID = new SelectList(db.Assignments, "AssignmentID", "AssignmentID", exerciseInstruction.AssignmentID);
            return View(exerciseInstruction);
        }

        // POST: ExerciseInstructions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExerciseInstructionID,Number_Of_Reps,Frequency_Per_Day,Reps_Completed,Remark,AssignmentID")] ExerciseInstruction exerciseInstruction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseInstruction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignmentID = new SelectList(db.Assignments, "AssignmentID", "AssignmentID", exerciseInstruction.AssignmentID);
            return View(exerciseInstruction);
        }

        // GET: ExerciseInstructions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseInstruction exerciseInstruction = db.ExerciseInstructions.Find(id);
            if (exerciseInstruction == null)
            {
                return HttpNotFound();
            }
            return View(exerciseInstruction);
        }

        // POST: ExerciseInstructions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseInstruction exerciseInstruction = db.ExerciseInstructions.Find(id);
            db.ExerciseInstructions.Remove(exerciseInstruction);
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
