namespace FinalAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixData : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Bookings");
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClinicId = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinics", t => t.ClinicId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ClinicId);
            
            AddPrimaryKey("dbo.Bookings", new[] { "CaseId", "UserId" });
            DropColumn("dbo.Bookings", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Ratings", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "ClinicId", "dbo.Clinics");
            DropIndex("dbo.Ratings", new[] { "ClinicId" });
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropPrimaryKey("dbo.Bookings");
            DropTable("dbo.Ratings");
            AddPrimaryKey("dbo.Bookings", "Id");
        }
    }
}
