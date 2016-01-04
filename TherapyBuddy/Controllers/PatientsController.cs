using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TherapyBuddy.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace TherapyBuddy.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patients
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager < ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get <ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,Patient_Email,Name,Password,Phone_Number,Gender,Date_Of_Birth,Feedback_Allowed,Total_Points")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PatientID,Patient_Email,Name,Password,Phone_Number,Gender,Date_Of_Birth")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                Patient findPatient = db.Patients.SingleOrDefault(p => p.Patient_Email == patient.Patient_Email);

                findPatient.Patient_Email = patient.Patient_Email;
                findPatient.Name = patient.Name;
                findPatient.Password = patient.Password;
                findPatient.Phone_Number = patient.Phone_Number;
                findPatient.Gender = patient.Gender;
                findPatient.Date_Of_Birth = patient.Date_Of_Birth;
                db.Entry(findPatient).State = EntityState.Modified;
                db.SaveChanges();
                var user = await UserManager.FindByNameAsync(patient.Patient_Email);
                var token = UserManager.GeneratePasswordResetToken(user.Id);
                var result = await UserManager.ResetPasswordAsync(user.Id, token, patient.Password);
                if (result.Succeeded)
                {
                    var result2 = await SignInManager.PasswordSignInAsync(findPatient.Patient_Email, findPatient.Password, false, shouldLockout: false);
                    return RedirectToAction("Index", "Home");
                }

              

            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
