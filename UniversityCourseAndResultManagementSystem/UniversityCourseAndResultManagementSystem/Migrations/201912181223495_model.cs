namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Allocations", "Status", c => c.String());
            AddColumn("dbo.Courses", "AssignTo", c => c.String());
            AddColumn("dbo.Courses", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Teachers", "RemainingCredit", c => c.Double(nullable: false));
            AddColumn("dbo.Enrolls", "EnrollDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Enrolls", "GradeLetter", c => c.String());
            AddColumn("dbo.Enrolls", "IsEnroll", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Courses", "Credit", c => c.Double(nullable: false));
            AlterColumn("dbo.AssignCourses", "CreditToBeTaken", c => c.Double(nullable: false));
            AlterColumn("dbo.AssignCourses", "RemainingCredit", c => c.Double(nullable: false));
            AlterColumn("dbo.Teachers", "Email", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Teachers", "CreditToBeTaken", c => c.Double(nullable: false));
            DropColumn("dbo.AssignCourses", "CourseName");
            DropColumn("dbo.AssignCourses", "CourseCredit");
            DropColumn("dbo.Enrolls", "StudentName");
            DropColumn("dbo.Enrolls", "Email");
            DropColumn("dbo.Enrolls", "Department");
            DropColumn("dbo.Enrolls", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enrolls", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Enrolls", "Department", c => c.String());
            AddColumn("dbo.Enrolls", "Email", c => c.String());
            AddColumn("dbo.Enrolls", "StudentName", c => c.String());
            AddColumn("dbo.AssignCourses", "CourseCredit", c => c.String());
            AddColumn("dbo.AssignCourses", "CourseName", c => c.String());
            AlterColumn("dbo.Teachers", "CreditToBeTaken", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Email", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.AssignCourses", "RemainingCredit", c => c.String());
            AlterColumn("dbo.AssignCourses", "CreditToBeTaken", c => c.String());
            AlterColumn("dbo.Courses", "Credit", c => c.Single(nullable: false));
            DropColumn("dbo.Enrolls", "IsEnroll");
            DropColumn("dbo.Enrolls", "GradeLetter");
            DropColumn("dbo.Enrolls", "EnrollDate");
            DropColumn("dbo.Teachers", "RemainingCredit");
            DropColumn("dbo.Courses", "Status");
            DropColumn("dbo.Courses", "AssignTo");
            DropColumn("dbo.Allocations", "Status");
        }
    }
}
