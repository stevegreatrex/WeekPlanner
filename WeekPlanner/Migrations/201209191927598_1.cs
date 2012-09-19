namespace WeekPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeSlots",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false),
                        Day_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Days", t => t.Day_Id)
                .Index(t => t.Day_Id);
            
            AddColumn("dbo.Activities", "TimeSlot_Id", c => c.Guid());
            AddColumn("dbo.Restrictions", "TimeSlot_Id", c => c.Guid());
            AddForeignKey("dbo.Restrictions", "TimeSlot_Id", "dbo.TimeSlots", "Id");
            AddForeignKey("dbo.Activities", "TimeSlot_Id", "dbo.TimeSlots", "Id");
            CreateIndex("dbo.Restrictions", "TimeSlot_Id");
            CreateIndex("dbo.Activities", "TimeSlot_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Activities", new[] { "TimeSlot_Id" });
            DropIndex("dbo.Restrictions", new[] { "TimeSlot_Id" });
            DropIndex("dbo.TimeSlots", new[] { "Day_Id" });
            DropForeignKey("dbo.Activities", "TimeSlot_Id", "dbo.TimeSlots");
            DropForeignKey("dbo.Restrictions", "TimeSlot_Id", "dbo.TimeSlots");
            DropForeignKey("dbo.TimeSlots", "Day_Id", "dbo.Days");
            DropColumn("dbo.Restrictions", "TimeSlot_Id");
            DropColumn("dbo.Activities", "TimeSlot_Id");
            DropTable("dbo.TimeSlots");
        }
    }
}
