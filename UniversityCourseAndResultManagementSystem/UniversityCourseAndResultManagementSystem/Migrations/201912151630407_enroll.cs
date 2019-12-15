namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enroll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrolls",
                c => new
                    {
                        EnrollId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        StudentName = c.String(),
                        Email = c.String(),
                        Department = c.String(),
                        CourseId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrolls", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrolls", "CourseId", "dbo.Courses");
            DropIndex("dbo.Enrolls", new[] { "CourseId" });
            DropIndex("dbo.Enrolls", new[] { "StudentId" });
            DropTable("dbo.Enrolls");
        }
    }
}
