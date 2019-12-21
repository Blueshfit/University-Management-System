namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Allocations", new[] { "DepartmentId" });
            AlterColumn("dbo.Allocations", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Allocations", "DepartmentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Allocations", new[] { "DepartmentId" });
            AlterColumn("dbo.Allocations", "DepartmentId", c => c.Int());
            CreateIndex("dbo.Allocations", "DepartmentId");
        }
    }
}
