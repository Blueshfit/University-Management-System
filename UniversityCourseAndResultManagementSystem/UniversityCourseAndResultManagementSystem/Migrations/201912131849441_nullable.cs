namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Allocations", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Allocations", new[] { "DepartmentId" });
            AlterColumn("dbo.Allocations", "DepartmentId", c => c.Int());
            CreateIndex("dbo.Allocations", "DepartmentId");
            AddForeignKey("dbo.Allocations", "DepartmentId", "dbo.Departments", "DepartmentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Allocations", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Allocations", new[] { "DepartmentId" });
            AlterColumn("dbo.Allocations", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Allocations", "DepartmentId");
            AddForeignKey("dbo.Allocations", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
    }
}
