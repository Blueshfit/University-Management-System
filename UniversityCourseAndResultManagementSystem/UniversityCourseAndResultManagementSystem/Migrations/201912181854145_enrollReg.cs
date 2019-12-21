namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enrollReg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrolls", "RegNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrolls", "RegNo");
        }
    }
}
