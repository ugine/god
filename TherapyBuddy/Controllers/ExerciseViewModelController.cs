using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TherapyBuddy.Models;

namespace TherapyBuddy.Controllers
{
    public class ExerciseViewModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: ExerciseViewModel
        public ActionResult Index()
        {
            List<ExerciseViewModel> evmLIst = new List<ExerciseViewModel>();
            int a = 0;
            List<Exercise> exercise = db.Exercises.ToList();
            foreach (var item in exercise)
            {
                ExerciseViewModel evm = new ExerciseViewModel();
                a = a + 1;
                evm.ExerciseViewModelID = a;
                evm.ExerciseRegion = db.ExerciseRegions.Find(item.ExerciseRegionID);
                evm.ExerciseDescription = item.Description;
                evm.ExerciseType = db.ExerciseTypes.Find(item.ExerciseTypeID);
                int ExerciseID = item.ExerciseID;
                ExerciseVideo ev = db.ExerciseVideos.Where(m => m.ExerciseID == ExerciseID).SingleOrDefault();
                evm.VideoURL = ev.VideoURL;
                evm.ImageURL = "";
                evm.Exercise = item.Name;
                evmLIst.Add(evm);

            }
            return View(evmLIst);
        }

        // GET: ExerciseViewModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<ExerciseViewModel> evmLIst = new List<ExerciseViewModel>();
            int a = 0;
            List<Exercise> exercise = db.Exercises.ToList();
            foreach (var item in exercise)
            {
                ExerciseViewModel evm = new ExerciseViewModel();
                a = a + 1;
                evm.ExerciseViewModelID = a;
                evm.ExerciseRegion = db.ExerciseRegions.Find(item.ExerciseRegionID);
                evm.ExerciseDescription = item.Description;
                evm.ExerciseType = db.ExerciseTypes.Find(item.ExerciseTypeID);
                int ExerciseID = item.ExerciseID;
                ExerciseVideo ev = db.ExerciseVideos.Where(m => m.ExerciseID == ExerciseID).SingleOrDefault();
                evm.VideoURL = ev.VideoURL;
                evm.ImageURL = "";
                evm.Exercise = item.Name;
                evmLIst.Add(evm);

            }
            ExerciseViewModel ex = new ExerciseViewModel();
            foreach (var item in evmLIst)
            {
                int exID = item.ExerciseViewModelID;
                if (exID == id)
                {
                    ex.ExerciseRegion = db.ExerciseRegions.Find(item.ExerciseRegion.ExerciseRegionID);
                    ex.ExerciseDescription = item.ExerciseDescription;
                    ex.ExerciseType = db.ExerciseTypes.Find(item.ExerciseType.ExerciseTypeID);
                    Exercise e = db.Exercises.Where(m => m.Name == item.Exercise).SingleOrDefault(); 
                    ExerciseVideo ev = db.ExerciseVideos.Where(m => m.ExerciseID == e.ExerciseID).SingleOrDefault();
                    ex.VideoURL = ev.VideoURL;
                    ex.ImageURL = "";
                    ex.Exercise = item.Exercise;
                }
            }
                return View(ex);
        }

        // GET: ExerciseViewModel/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseRegion = db.ExerciseRegions.ToList();
            ViewBag.ExerciseType = db.ExerciseTypes.ToList();
            return View();
        }

        // POST: ExerciseViewModel/Create
        [HttpPost]
        public ActionResult Create(ExerciseViewModel exerciseViewModel)
        {
            if (ModelState.IsValid)
            {
                Exercise ex = new Exercise();
                ex.ExerciseRegionID = exerciseViewModel.ExerciseRegionID;
                ex.ExerciseTypeID = exerciseViewModel.ExerciseTypeID;
                ex.Name = exerciseViewModel.Exercise;
                ex.Description = exerciseViewModel.ExerciseDescription;
                db.Exercises.Add(ex);
                db.SaveChanges();

                ExerciseVideo ev = new ExerciseVideo();
                ev.ExerciseID = ex.ExerciseID;
                ev.VideoURL = exerciseViewModel.VideoURL;
                db.ExerciseVideos.Add(ev);
                db.SaveChanges();

                ExerciseImage eI = new ExerciseImage();
                eI.ExerciseID = ex.ExerciseID;
                eI.ImageURL = exerciseViewModel.ImageURL;
                db.ExerciseImages.Add(eI);
                db.SaveChanges();
                TempData["Message"] = "Successfully created exercise - " + ex.Name;
                return RedirectToAction("Index", "ExerciseViewModel");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int? ExerciseViewModelID)
        {
            if (ExerciseViewModelID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<ExerciseViewModel> evmLIst = new List<ExerciseViewModel>();
            int a = 0;
            List<Exercise> exercise = db.Exercises.ToList();
            foreach (var item in exercise)
            {
                ExerciseViewModel evm = new ExerciseViewModel();
                a = a + 1;
                evm.ExerciseViewModelID = a;
                evm.ExerciseRegion = db.ExerciseRegions.Find(item.ExerciseRegionID);
                evm.ExerciseDescription = item.Description;
                evm.ExerciseType = db.ExerciseTypes.Find(item.ExerciseTypeID);
                evm.ExerciseID = item.ExerciseID;
                int ExerciseID = item.ExerciseID;
                ExerciseVideo ev = db.ExerciseVideos.Where(m => m.ExerciseID == item.ExerciseID).SingleOrDefault();
                evm.VideoURL = ev.VideoURL;
                evm.ImageURL = "";
                evm.Exercise = item.Name;
                evmLIst.Add(evm);

            }
            ExerciseViewModel ex = new ExerciseViewModel();
            Exercise e = new Exercise();
            foreach (var item in evmLIst)
            {
                int exID = item.ExerciseViewModelID;
                if (exID == ExerciseViewModelID)
                {
                    ex.ExerciseRegion = db.ExerciseRegions.Find(item.ExerciseRegion.ExerciseRegionID);
                    ex.ExerciseRegionID = ex.ExerciseRegion.ExerciseRegionID;
                    ex.ExerciseDescription = item.ExerciseDescription;
                    ex.ExerciseType = db.ExerciseTypes.Find(item.ExerciseType.ExerciseTypeID);
                    ex.ExerciseTypeID = ex.ExerciseType.ExerciseTypeID;
                    ex.ExerciseID = item.ExerciseID;
                    e = db.Exercises.Where(m => m.Name == item.Exercise).Single();
                    ExerciseVideo ev = db.ExerciseVideos.Where(m => m.ExerciseID == e.ExerciseID).SingleOrDefault();
                    ex.VideoURL = ev.VideoURL;
                    ex.ImageURL = "";
                    ex.Exercise = item.Exercise;
                }
            }
            ViewBag.ExerciseRegion = db.ExerciseRegions.ToList();
            ViewBag.ExerciseType = db.ExerciseTypes.ToList();
            return View(ex);
        }

        // POST: ExerciseViewModel/Edit/5
        [HttpPost]
        public ActionResult Edit(ExerciseViewModel exerciseViewModel)
        {
            if (ModelState.IsValid)
            {
                Exercise exercise = db.Exercises.SingleOrDefault(p => p.ExerciseID == exerciseViewModel.ExerciseID);

                exercise.Name = exerciseViewModel.Exercise;
                exercise.ExerciseRegionID = exerciseViewModel.ExerciseRegionID;
                exercise.ExerciseTypeID = exerciseViewModel.ExerciseTypeID;
                db.Entry(exercise).State = EntityState.Modified;
                db.SaveChanges();

                ExerciseVideo exVid = db.ExerciseVideos.SingleOrDefault(p => p.ExerciseID == exerciseViewModel.ExerciseID);
                db.Entry(exVid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

    }
}
