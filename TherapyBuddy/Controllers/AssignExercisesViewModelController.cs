using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TherapyBuddy.Models;

namespace TherapyBuddy.Controllers
{
    public class AssignExercisesViewModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult AssignExercisesViewModel(int? pid)
        {
            List<AssignExercisesViewModel> assignEx = new List<AssignExercisesViewModel> { new AssignExercisesViewModel { AssignExercisesViewModelID = 0, ExerciseRegionID = 0, ExerciseTypeID = 0, ExerciseID = 0, ExerciseVideoID = 0, Number_Of_Reps = 0, Frequency_Per_Day = 0, Remark = "" } };
            ViewBag.ExerciseRegion = db.ExerciseRegions.ToList();
            ViewBag.ExerciseType = db.ExerciseTypes.ToList();
            ViewBag.Exercises = db.Exercises.ToList();
            ViewBag.PatientName = "for " + db.Patients.Find(pid).Name;
            return View(assignEx);
        }
        [HttpPost]
        public ActionResult AssignExercisesViewModel(List<AssignExercisesViewModel> aE, int pID)
        {
            if (ModelState.IsValid)
            {
                foreach(var i in aE)
                {
                    //create assignment
                    Assignment assignment = new Assignment();
                    assignment.Date_Assigned = DateTime.Now;
                    assignment.PatientID = pID;
                    Patient patient = db.Patients.Find(pID);
                    string email = User.Identity.GetUserName();
                    Therapist therapist = db.Therapists.SingleOrDefault(T => T.Email == email);
                    assignment.TherapistID = therapist.TherapistID;
                    db.Assignments.Add(assignment);
                    db.SaveChanges();


                    //create Exercise Instruction
                    ExerciseInstruction exerciseInstruction = new ExerciseInstruction();
                    exerciseInstruction.Number_Of_Reps = i.Number_Of_Reps;
                    exerciseInstruction.Frequency_Per_Day = i.Frequency_Per_Day;
                    exerciseInstruction.Remark = i.Remark;
                    exerciseInstruction.Reps_Completed = 0;
                    exerciseInstruction.AssignmentID = assignment.AssignmentID;
                    db.ExerciseInstructions.Add(exerciseInstruction);
                    db.SaveChanges();

                    //create assignedVideo
                    AssignedVideo assignedVideo = new AssignedVideo();
                    assignedVideo.ExerciseInstructionID = exerciseInstruction.ExerciseInstructionID;
                    ExerciseVideo eV = db.ExerciseVideos.SingleOrDefault(e => e.ExerciseID == i.ExerciseID);
                    assignedVideo.ExerciseVideoID = eV.ExerciseVideoID;
                    db.AssignedVideos.Add(assignedVideo);
                    db.SaveChanges();
                    return RedirectToAction("Index", "AssignExercisesViewModel");
                }

            }
            return View(aE);
        }
        // GET: Patients
        [Authorize(Roles = "Therapist")]
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        //[Authorize(Roles = "Therapist")]
        //public ActionResult AssignExercisesViewModel(int? pid)
        //{
        //    ViewBag.ExerciseRegion = db.ExerciseRegions.ToList();
        //    ViewBag.ExerciseType = db.ExerciseTypes.ToList();
        //    ViewBag.Exercises = db.Exercises.ToList();
        //    ViewBag.PatientName = "for " + db.Patients.Find(pid).Name;
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Therapist")]
        //public ActionResult AssignExercisesViewModel([Bind(Include = "AssignExercisesViewModelID,ExerciseRegionID,ExerciseTypeID,ExerciseID,ExerciseVideoID,Number_Of_Reps,Frequency_Per_Day,Remark")] AssignExercisesViewModel AssignExercise, int pID)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //create assignment
        //        Assignment assignment = new Assignment();
        //        assignment.Date_Assigned = DateTime.Now;
        //        assignment.PatientID = pID;
        //        Patient patient = db.Patients.Find(pID);
        //        System.Diagnostics.Debug.WriteLine(pID);
        //        string email = User.Identity.GetUserName();
        //        Therapist therapist = db.Therapists.SingleOrDefault(T => T.Email == email);
        //        assignment.TherapistID = therapist.TherapistID;
        //        db.Assignments.Add(assignment);
        //        db.SaveChanges();
               

        //        //create Exercise Instruction
        //        ExerciseInstruction exerciseInstruction = new ExerciseInstruction();
        //        exerciseInstruction.Number_Of_Reps = AssignExercise.Number_Of_Reps;
        //        exerciseInstruction.Frequency_Per_Day = AssignExercise.Frequency_Per_Day;
        //        exerciseInstruction.Remark = AssignExercise.Remark;
        //        exerciseInstruction.Reps_Completed = 0;
        //        exerciseInstruction.AssignmentID = assignment.AssignmentID;
        //        db.ExerciseInstructions.Add(exerciseInstruction);
        //        db.SaveChanges();

        //        //create assignedVideo
        //        AssignedVideo assignedVideo = new AssignedVideo();
        //        assignedVideo.ExerciseInstructionID = exerciseInstruction.ExerciseInstructionID;
        //        ExerciseVideo eV = db.ExerciseVideos.SingleOrDefault(e => e.ExerciseID == AssignExercise.ExerciseID);
        //        assignedVideo.ExerciseVideoID = eV.ExerciseVideoID;
        //        db.AssignedVideos.Add(assignedVideo);
        //        db.SaveChanges();
        //        TempData["Message"] = "Successfully Assigned videos to " + patient.Name;
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return RedirectToAction("Index", "Home");
        //}



    }
}
