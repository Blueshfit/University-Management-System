using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Models;
using Vereyon.Web;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class ResultsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Results
        public async Task<ActionResult> Index()
        {
            var results = db.Results.Include(r => r.Course).Include(r => r.Grade).Include(r => r.Student);
            return View(await results.ToListAsync());
        }

        

        // GET: Results/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeLetter");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ResultId,StudentId,StudentName,Email,Department,CourseId,GradeId")] Result result)
        {
            if (ModelState.IsValid)
            {
                if (IsGraded(result))
                {
                    FlashMessage.Danger("Student is Already graded");
                    return RedirectToAction("Create");
                }

                db.Results.Add(result);
                await db.SaveChangesAsync();
                FlashMessage.Confirmation("Student result saved successfully");
                return RedirectToAction("Create");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", result.CourseId);
            ViewBag.GradeId = new SelectList(db.Grades, "GradeId", "GradeLetter", result.GradeId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo", result.StudentId);
            return View(result);
        }

        public bool IsGraded(Result result)
        {
            var gradedCourses = db.Results.ToList();

            if (gradedCourses.Any(c => c.CourseId.ToString() == result.CourseId.ToString()))
            {
                return true;
            }
            return false;
        }

        public ActionResult ViewResult()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo");
            return View();
        }

        public JsonResult GetStudentByStudentId(int studentId)
        {
            var student = db.Students.FirstOrDefault(s => s.StudentId == studentId);
            return Json(student);
        }

        public JsonResult GetEnrolledCoursesByStudentId(int studentId)
        {
            var courses = db.Enrolls.Where(e => e.StudentId == studentId).ToList();
            return Json(courses);
        }

        

        // GET: Results/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = await db.Results.FindAsync(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Result result = await db.Results.FindAsync(id);
            db.Results.Remove(result);
            await db.SaveChangesAsync();
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
