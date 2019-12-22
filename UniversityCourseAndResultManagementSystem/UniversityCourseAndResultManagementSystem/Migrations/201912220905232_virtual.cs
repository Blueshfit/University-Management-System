namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _virtual : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "CreditToBeTaken", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "CreditToBeTaken", c => c.String(nullable: false));
        }
    }
}
