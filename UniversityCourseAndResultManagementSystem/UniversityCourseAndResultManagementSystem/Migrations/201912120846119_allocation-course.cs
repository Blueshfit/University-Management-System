namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allocationcourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Allocations", "CourseId", "dbo.Courses");
            DropIndex("dbo.Allocations", new[] { "CourseId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Allocations", "CourseId");
            AddForeignKey("dbo.Allocations", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
    }
}
