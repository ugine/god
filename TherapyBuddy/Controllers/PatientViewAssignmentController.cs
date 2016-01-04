using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TherapyBuddy.Models;

namespace TherapyBuddy.Controllers
{
    public class PatientViewAssignmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: PatientViewAssignment
        public ActionResult Index()
        {
            string username = System.Web.HttpContext.Current.User.Identity.Name;
            Patient findPatient = db.Patients.SingleOrDefault(p => p.Patient_Email == username);
            int patientID = findPatient.PatientID;

            Assignment assignment = db.Assignments.SingleOrDefault(a => a.PatientID == patientID);

            Therapist therapist = db.Therapists.SingleOrDefault(t => t.TherapistID == assignment.TherapistID);
            ExerciseInstruction eI = db.ExerciseInstructions.SingleOrDefault(e => e.AssignmentID == assignment.AssignmentID);

            AssignedVideo aV = db.AssignedVideos.SingleOrDefault(a => a.ExerciseInstructionID == eI.ExerciseInstructionID);
            ExerciseVideo eV = db.ExerciseVideos.SingleOrDefault(e => e.ExerciseVideoID == aV.ExerciseVideoID);
            Exercise exercise = db.Exercises.SingleOrDefault(e => e.ExerciseID == eV.ExerciseID);
            ExerciseRegion region = db.ExerciseRegions.SingleOrDefault(c => c.ExerciseRegionID == exercise.ExerciseRegionID);

            ViewBag.assignment = assignment.AssignmentID;
            ViewBag.therapist = therapist.Name;
            ViewBag.Number_Of_Reps = eI.Number_Of_Reps;
            ViewBag.Frequency_Per_Day = eI.Frequency_Per_Day;
            ViewBag.Remark = eI.Remark;
            ViewBag.eV = eV.VideoURL;
            ViewBag.exerciseName = exercise.Name;
            ViewBag.cat = region.Name;

            return View();
        }
      
        }
 }