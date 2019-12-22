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
    public class AssignCoursesController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: AssignCourses
        public async Task<ActionResult> Index()
        {
            var assignCourses = db.AssignCourses.Include(a => a.Course).Include(a => a.Department).Include(a => a.Teacher);
            return View(await assignCourses.ToListAsync());
        }

        // GET: AssignCourses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignCourse assignCourse = await db.AssignCourses.FindAsync(id);
            if (assignCourse == null)
            {
                return HttpNotFound();
            }
            return View(assignCourse);
        }

        // GET: AssignCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName");
            return View();
        }

        // POST: AssignCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AssignId,DepartmentId,TeacherId,CreditToBeTaken,RemainingCredit,CourseId,CourseName,CourseCredit")] AssignCourse assignCourse)
        {
            if (ModelState.IsValid)
            {
                if (IsAssigned(assignCourse))
                {
                    FlashMessage.Danger("This Course is already assigned!");
                    return RedirectToAction("Create");
                }

                db.AssignCourses.Add(assignCourse);
                await db.SaveChangesAsync();
                FlashMessage.Confirmation("Course assigned to Teacher successfully");
                return RedirectToAction("Create");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", assignCourse.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", assignCourse.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", assignCourse.TeacherId);
            return View(assignCourse);
        }

        public bool IsAssigned(AssignCourse assign)
        {
            //var assignedCourses = db.AssignCourses.ToList();

            //if (assignedCourses.Any(c => (c.CourseId.ToString() == assign.CourseId.ToString()) && (c.TeacherId.ToString() == assign.TeacherId.ToString())))
            //{
            //    return true;
            //}

            var assignedCourses = db.AssignCourses.ToList();

            if (assignedCourses.Any(c => (c.CourseId == assign.CourseId)))
            {
                return true;
            }

            return false;
        }


        public JsonResult GetTeachersByDepartmentId(int departmentId)
        {
            var teachers = db.Teachers.Where(t => t.DepartmentId == departmentId).ToList();
            return Json(teachers);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            var courses = db.Courses.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(courses);
        }

        public JsonResult GetTeacherById(int teacherId)
        {
            var teacher = db.Teachers.FirstOrDefault(t => t.TeacherId == teacherId);
            return Json(teacher);
        }

        public JsonResult GetCourseById(int courseId)
        {
            var course = db.Courses.FirstOrDefault(c => c.CourseId == courseId);
            return Json(course);
        }

        

        // GET: AssignCourses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignCourse assignCourse = await db.AssignCourses.FindAsync(id);
            if (assignCourse == null)
            {
                return HttpNotFound();
            }
            return View(assignCourse);
        }

        // POST: AssignCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AssignCourse assignCourse = await db.AssignCourses.FindAsync(id);
            db.AssignCourses.Remove(assignCourse);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public ActionResult ViewCourseStatistics()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View("ViewCourseStatistics");
        }
        public ActionResult GetCourseStatistics(int deptId)
        {
            var courses = db.AssignCourses.Where(t => t.DepartmentId == deptId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
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
