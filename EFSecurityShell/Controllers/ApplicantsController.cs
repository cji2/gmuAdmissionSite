using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFSecurityShell.Models;

namespace EFSecurityShell.Controllers
{
    public class ApplicantsController : Controller
    {
        private ApplicantDbContext db = new ApplicantDbContext();

        // GET: Applicants
        public ActionResult Index(string search)
        {
            var applicants = from a in db.Applicants
                             select a;

            if (!String.IsNullOrEmpty(search))
            {
                applicants = applicants.Where(s => s.LastName.Contains(search) || s.SocialSecurityNo.Contains(search));
            }
            return View(applicants);
        }

        // GET: Applicants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,MiddleName,LastName,CreateTime,SocialSecurityNo,Email,HomePhone,CellPhone,Street,City,State,Zip,DOB,Gender,SchoolName,SchoolCity,GraduationDate,GPA,MathScore,VerbalScore,TotalScore,PAOfInterest,EnrollmentSemester,EnrollmentYear,EnrollmentDecision")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                // Verify that the SSN isn't already in the database.
                Applicant matchingApplicant = db.Applicants.Where(cm =>
                string.Compare(cm.SocialSecurityNo, applicant.SocialSecurityNo, true) == 0).FirstOrDefault();

                if (applicant == null)
                {
                    return HttpNotFound();
                }

                if (matchingApplicant != null)
                {
                    ModelState.AddModelError("SocialSecurityNo",
                                      "Social Security Number should be unique.");
                    return View(applicant);
                }

                applicant.TotalScore = applicant.MathScore + applicant.VerbalScore;

                if (applicant.GPA < 3)
                {
                    ModelState.AddModelError("GPA", "Minimum Qualitification for GPA is 3.0");
                    return View(applicant);
                }

                if (applicant.TotalScore < 1001)
                {
                    ModelState.AddModelError("VerbalScore", "Combined SAT Score should be more than 1000.");
                    return View(applicant);
                }

                db.Applicants.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,CreateTime,SocialSecurityNo,Email,HomePhone,CellPhone,Street,City,State,Zip,DOB,Gender,SchoolName,SchoolCity,GraduationDate,GPA,MathScore,VerbalScore,TotalScore,PAOfInterest,EnrollmentSemester,EnrollmentYear,EnrollmentDecision")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            db.Applicants.Remove(applicant);
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
