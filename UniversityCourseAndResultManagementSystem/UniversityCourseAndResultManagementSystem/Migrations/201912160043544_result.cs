namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class result : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        StudentName = c.String(),
                        Email = c.String(),
                        Department = c.String(),
                        CourseId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Grades", t => t.GradeId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.GradeId);
            
            AddColumn("dbo.Grades", "GradeLetter", c => c.String());
            DropColumn("dbo.Grades", "GradeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grades", "GradeName", c => c.String());
            DropForeignKey("dbo.Results", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Results", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Results", "CourseId", "dbo.Courses");
            DropIndex("dbo.Results", new[] { "GradeId" });
            DropIndex("dbo.Results", new[] { "CourseId" });
            DropIndex("dbo.Results", new[] { "StudentId" });
            DropColumn("dbo.Grades", "GradeLetter");
            DropTable("dbo.Results");
        }
    }
}
