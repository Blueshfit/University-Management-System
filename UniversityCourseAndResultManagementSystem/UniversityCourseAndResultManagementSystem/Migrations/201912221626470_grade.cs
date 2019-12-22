namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrolls", "Result_ResultId", c => c.Int());
            CreateIndex("dbo.Enrolls", "Result_ResultId");
            AddForeignKey("dbo.Enrolls", "Result_ResultId", "dbo.Results", "ResultId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrolls", "Result_ResultId", "dbo.Results");
            DropIndex("dbo.Enrolls", new[] { "Result_ResultId" });
            DropColumn("dbo.Enrolls", "Result_ResultId");
        }
    }
}
