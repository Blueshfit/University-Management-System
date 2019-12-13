namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allocUp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Allocations", "CourseId", c => c.Int());
            CreateIndex("dbo.Allocations", "DepartmentId");
            CreateIndex("dbo.Allocations", "CourseId");
            AddForeignKey("dbo.Allocations", "CourseId", "dbo.Courses", "CourseId");
            AddForeignKey("dbo.Allocations", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Allocations", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Allocations", "CourseId", "dbo.Courses");
            DropIndex("dbo.Allocations", new[] { "CourseId" });
            DropIndex("dbo.Allocations", new[] { "DepartmentId" });
            AlterColumn("dbo.Allocations", "CourseId", c => c.Int(nullable: false));
        }
    }
}
