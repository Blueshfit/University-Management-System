namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assign1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Allocations", "DayId", "dbo.Days");
            DropForeignKey("dbo.Allocations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            AddColumn("dbo.AssignCourses", "CourseCredit", c => c.String());
            CreateIndex("dbo.AssignCourses", "DepartmentId");
            CreateIndex("dbo.AssignCourses", "TeacherId");
            CreateIndex("dbo.AssignCourses", "CourseId");
            AddForeignKey("dbo.AssignCourses", "CourseId", "dbo.Courses", "CourseId");
            AddForeignKey("dbo.AssignCourses", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.AssignCourses", "TeacherId", "dbo.Teachers", "TeacherId");
            AddForeignKey("dbo.Allocations", "DayId", "dbo.Days", "DayId");
            AddForeignKey("dbo.Allocations", "RoomId", "dbo.Rooms", "RoomId");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters", "SemesterId");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations", "DesignationId");
            DropColumn("dbo.AssignCourses", "Credit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssignCourses", "Credit", c => c.String());
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Allocations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Allocations", "DayId", "dbo.Days");
            DropForeignKey("dbo.AssignCourses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.AssignCourses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AssignCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.AssignCourses", new[] { "CourseId" });
            DropIndex("dbo.AssignCourses", new[] { "TeacherId" });
            DropIndex("dbo.AssignCourses", new[] { "DepartmentId" });
            DropColumn("dbo.AssignCourses", "CourseCredit");
            AddForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations", "DesignationId", cascadeDelete: true);
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters", "SemesterId", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Allocations", "RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
            AddForeignKey("dbo.Allocations", "DayId", "dbo.Days", "DayId", cascadeDelete: true);
        }
    }
}
