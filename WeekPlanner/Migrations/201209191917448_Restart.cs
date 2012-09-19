namespace WeekPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Week_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Weeks", t => t.Week_Id)
                .Index(t => t.Week_Id);
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restrictions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Days", new[] { "Week_Id" });
            DropForeignKey("dbo.Days", "Week_Id", "dbo.Weeks");
            DropTable("dbo.Restrictions");
            DropTable("dbo.Activities");
            DropTable("dbo.Days");
            DropTable("dbo.Weeks");
        }
    }
}
