namespace FinalAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGPs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GPs",
                c => new
                    {
                        GPId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Specialist = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GPId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GPs");
        }
    }
}
