namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assign : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignCourses",
                c => new
                    {
                        AssignId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        CreditToBeTaken = c.String(),
                        RemainingCredit = c.String(),
                        CourseId = c.Int(nullable: false),
                        CourseName = c.String(),
                        Credit = c.String(),
                    })
                .PrimaryKey(t => t.AssignId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AssignCourses");
        }
    }
}
