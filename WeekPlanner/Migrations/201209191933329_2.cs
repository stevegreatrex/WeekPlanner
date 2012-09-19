namespace WeekPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Days", "Week_Id", "dbo.Weeks");
            DropForeignKey("dbo.TimeSlots", "Day_Id", "dbo.Days");
            DropIndex("dbo.Days", new[] { "Week_Id" });
            DropIndex("dbo.TimeSlots", new[] { "Day_Id" });
            AlterColumn("dbo.Days", "Week_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.TimeSlots", "Day_Id", c => c.Guid(nullable: false));
            AddForeignKey("dbo.Days", "Week_Id", "dbo.Weeks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TimeSlots", "Day_Id", "dbo.Days", "Id", cascadeDelete: true);
            CreateIndex("dbo.Days", "Week_Id");
            CreateIndex("dbo.TimeSlots", "Day_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TimeSlots", new[] { "Day_Id" });
            DropIndex("dbo.Days", new[] { "Week_Id" });
            DropForeignKey("dbo.TimeSlots", "Day_Id", "dbo.Days");
            DropForeignKey("dbo.Days", "Week_Id", "dbo.Weeks");
            AlterColumn("dbo.TimeSlots", "Day_Id", c => c.Guid());
            AlterColumn("dbo.Days", "Week_Id", c => c.Guid());
            CreateIndex("dbo.TimeSlots", "Day_Id");
            CreateIndex("dbo.Days", "Week_Id");
            AddForeignKey("dbo.TimeSlots", "Day_Id", "dbo.Days", "Id");
            AddForeignKey("dbo.Days", "Week_Id", "dbo.Weeks", "Id");
        }
    }
}
