namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gradeFKup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrolls", "GradeId", c => c.Int(nullable: false));
            AddColumn("dbo.Enrolls", "IsEnrolled", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Enrolls", "GradeId");
            AddForeignKey("dbo.Enrolls", "GradeId", "dbo.Grades", "GradeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrolls", "GradeId", "dbo.Grades");
            DropIndex("dbo.Enrolls", new[] { "GradeId" });
            DropColumn("dbo.Enrolls", "IsEnrolled");
            DropColumn("dbo.Enrolls", "GradeId");
        }
    }
}
