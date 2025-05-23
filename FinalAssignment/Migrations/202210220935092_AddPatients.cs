﻿namespace FinalAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}
