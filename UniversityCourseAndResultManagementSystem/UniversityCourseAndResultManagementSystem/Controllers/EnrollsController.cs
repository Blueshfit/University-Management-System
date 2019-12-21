﻿using System;
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
    public class EnrollsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Enrolls
        public async Task<ActionResult> Index()
        {
            var enrolls = db.Enrolls.Include(e => e.Course).Include(e => e.Student);
            return View(await enrolls.ToListAsync());
        }

        

        // GET: Enrolls/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo");
            return View();
        }

        // POST: Enrolls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EnrollId,StudentId,StudentName,Email,Department,CourseId,Date")] Enroll enroll)
        {
            if (ModelState.IsValid)
            {
                if (IsEnrolled(enroll))
                {
                    FlashMessage.Danger("Course Already enrolled");
                    return RedirectToAction("Create");
                }

                db.Enrolls.Add(enroll);
                await db.SaveChangesAsync();
                FlashMessage.Confirmation("Course enrolled successfully");
                return RedirectToAction("Create");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", enroll.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo", enroll.StudentId);
            return View(enroll);
        }


        public bool IsEnrolled(Enroll enroll)
        {
            var enrolledCourses = db.Enrolls.ToList();
            
            if(enrolledCourses.Any(c => c.CourseId.ToString() == enroll.CourseId.ToString())){
                return true;
            }
            return false;
        }

        public JsonResult GetStudentByStudentId(int studentId)
        {
            var student = db.Students.FirstOrDefault(s => s.StudentId == studentId);
            return Json(student);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            var courses = db.Courses.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(courses);
        }

        
        // GET: Enrolls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enroll enroll = await db.Enrolls.FindAsync(id);
            if (enroll == null)
            {
                return HttpNotFound();
            }
            return View(enroll);
        }

        // POST: Enrolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Enroll enroll = await db.Enrolls.FindAsync(id);
            db.Enrolls.Remove(enroll);
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
