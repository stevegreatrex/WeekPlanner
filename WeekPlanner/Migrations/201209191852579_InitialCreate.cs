namespace WeekPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlannerSegments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Start = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restrictions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Color = c.String(),
                        PlannerSegment_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlannerSegments", t => t.PlannerSegment_Id)
                .Index(t => t.PlannerSegment_Id);
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Restrictions", new[] { "PlannerSegment_Id" });
            DropForeignKey("dbo.Restrictions", "PlannerSegment_Id", "dbo.PlannerSegments");
            DropTable("dbo.Activities");
            DropTable("dbo.Restrictions");
            DropTable("dbo.PlannerSegments");
        }
    }
}
