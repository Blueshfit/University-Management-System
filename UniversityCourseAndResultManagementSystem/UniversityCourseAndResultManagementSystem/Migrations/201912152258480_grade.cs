namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                    })
                .PrimaryKey(t => t.GradeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Grades");
        }
    }
}
