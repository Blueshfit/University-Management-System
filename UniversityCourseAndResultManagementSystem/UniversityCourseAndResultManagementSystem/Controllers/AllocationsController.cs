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

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class AllocationsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Allocations
        public async Task<ActionResult> Index()
        {
            var allocations = db.Allocations.Include(a => a.Course).Include(a => a.Day).Include(a => a.Department).Include(a => a.Room);
            return View(await allocations.ToListAsync());
        }


        // GET: Allocations/Create
        public ActionResult Create()
        {
            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayName");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNo");
            return View();
        }

        // POST: Allocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Allocation allocation)
        {
            if (ModelState.IsValid)
            {
                db.Allocations.Add(allocation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayName", allocation.DayId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", allocation.DepartmentId);
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNo", allocation.RoomId);
            return View(allocation);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            var courses = db.Courses.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(courses);
        }


       

        // GET: Allocations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocation allocation = await db.Allocations.FindAsync(id);
            if (allocation == null)
            {
                return HttpNotFound();
            }
            return View(allocation);
        }

        // POST: Allocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Allocation allocation = await db.Allocations.FindAsync(id);
            db.Allocations.Remove(allocation);
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
