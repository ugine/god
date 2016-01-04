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
    public class PublicModulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PublicModules
        public ActionResult Index()
        {
            List<ExerciseVideo> exerciseVideoList = db.ExerciseVideos.ToList();
            List<PublicModule> publicModuleList = new List<PublicModule>();
            ViewBag.ExerciseArea = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "Name");
            ViewBag.ExerciseRegion = new SelectList(db.ExerciseRegions, "ExerciseRegionID", "Name");
            foreach (ExerciseVideo e in exerciseVideoList)
            {
                PublicModule publicmodule = new PublicModule();
                Exercise exercise = db.Exercises.Find(e.ExerciseID);
                ExerciseType exerciseType = db.ExerciseTypes.Find(exercise.ExerciseTypeID);
                ExerciseRegion exerciseRegion = db.ExerciseRegions.Find(exercise.ExerciseRegionID);
                publicmodule.VideoURL = e.VideoURL;
                publicmodule.ExerciseName = exercise.Name;
                publicmodule.ExerciseRegion = exerciseRegion.Name;
                publicmodule.ExerciseType = exerciseType.Name;
                publicModuleList.Add(publicmodule);
            }
            return View(publicModuleList);
        }

        public ActionResult retrieveBySelected(int exerciseRegionID, int exerciseTypeID)
        {
            ExerciseVideo exerciseVideo = new ExerciseVideo();
            List<Exercise> list = db.Exercises.ToList();
            PublicModule publicmod = new PublicModule();
            foreach (Exercise e in list)
            {
                if (e.ExerciseTypeID == exerciseTypeID && e.ExerciseRegionID == exerciseRegionID)
                {
                    exerciseVideo = db.ExerciseVideos.Where(m => m.ExerciseID == e.ExerciseID).SingleOrDefault();
                    Exercise exercise = db.Exercises.Find(exerciseVideo.ExerciseID);
                    ExerciseType exerciseType = db.ExerciseTypes.Find(exercise.ExerciseTypeID);
                    ExerciseRegion exerciseRegion = db.ExerciseRegions.Find(exercise.ExerciseRegionID);
                    publicmod.VideoURL = exerciseVideo.VideoURL;
                    publicmod.ExerciseName = exercise.Name;
                    publicmod.ExerciseRegion = exerciseRegion.Name;
                    publicmod.ExerciseType = exerciseType.Name;
                }
            }
            return Json(publicmod, JsonRequestBehavior.AllowGet);
        }
    }
}
