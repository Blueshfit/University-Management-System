namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notmapped : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AssignCourses", "CreditToBeTaken");
            DropColumn("dbo.AssignCourses", "RemainingCredit");
            DropColumn("dbo.AssignCourses", "CourseName");
            DropColumn("dbo.AssignCourses", "CourseCredit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssignCourses", "CourseCredit", c => c.String());
            AddColumn("dbo.AssignCourses", "CourseName", c => c.String());
            AddColumn("dbo.AssignCourses", "RemainingCredit", c => c.String());
            AddColumn("dbo.AssignCourses", "CreditToBeTaken", c => c.String());
        }
    }
}
