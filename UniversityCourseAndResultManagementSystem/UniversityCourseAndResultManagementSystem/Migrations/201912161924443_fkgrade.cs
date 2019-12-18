namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkgrade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrolls", "GradeId", "dbo.Grades");
            DropIndex("dbo.Enrolls", new[] { "GradeId" });
            DropColumn("dbo.Enrolls", "GradeId");
            DropColumn("dbo.Enrolls", "IsEnrolled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enrolls", "IsEnrolled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Enrolls", "GradeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Enrolls", "GradeId");
            AddForeignKey("dbo.Enrolls", "GradeId", "dbo.Grades", "GradeId");
        }
    }
}
