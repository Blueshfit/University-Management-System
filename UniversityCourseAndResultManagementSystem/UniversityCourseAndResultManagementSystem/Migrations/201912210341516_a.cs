namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Allocations", new[] { "CourseId" });
            AlterColumn("dbo.Allocations", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Allocations", "CourseId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Allocations", new[] { "CourseId" });
            AlterColumn("dbo.Allocations", "CourseId", c => c.Int());
            CreateIndex("dbo.Allocations", "CourseId");
        }
    }
}
