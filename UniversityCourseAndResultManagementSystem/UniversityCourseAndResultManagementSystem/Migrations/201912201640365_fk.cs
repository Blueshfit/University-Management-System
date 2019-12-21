namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Enrolls", new[] { "StudentId" });
            RenameColumn(table: "dbo.Enrolls", name: "StudentId", newName: "Student_StudentId");
            AlterColumn("dbo.Enrolls", "Student_StudentId", c => c.Int());
            CreateIndex("dbo.Enrolls", "Student_StudentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Enrolls", new[] { "Student_StudentId" });
            AlterColumn("dbo.Enrolls", "Student_StudentId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Enrolls", name: "Student_StudentId", newName: "StudentId");
            CreateIndex("dbo.Enrolls", "StudentId");
        }
    }
}
