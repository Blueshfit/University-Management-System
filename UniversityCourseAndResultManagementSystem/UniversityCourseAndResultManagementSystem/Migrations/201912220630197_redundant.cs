namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redundant : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Results", "StudentName");
            DropColumn("dbo.Results", "Email");
            DropColumn("dbo.Results", "Department");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Results", "Department", c => c.String());
            AddColumn("dbo.Results", "Email", c => c.String());
            AddColumn("dbo.Results", "StudentName", c => c.String());
        }
    }
}
