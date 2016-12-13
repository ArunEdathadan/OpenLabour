namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserVehicleVerifications",
                c => new
                    {
                        UserVehicleVerificationID = c.Int(nullable: false, identity: true),
                        UserVehicleID = c.Int(nullable: false),
                        Description = c.String(),
                        VerficationDate = c.DateTime(nullable: false),
                        VerifiedByUserID = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserVehicleVerificationID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.UserVehicles", t => t.UserVehicleID, cascadeDelete: true)
                .Index(t => t.UserVehicleID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserVehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        OwnerID = c.String(),
                        Name = c.String(),
                        NumberPlate = c.String(),
                        Model = c.String(),
                        Color = c.String(),
                        ChasisNumber = c.String(),
                        EngineNumber = c.String(),
                        VehicleTypeID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeID, cascadeDelete: true)
                .Index(t => t.VehicleTypeID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserVechicleVerificationDocuments",
                c => new
                    {
                        UserVehicleVerificationSupportDocID = c.Int(nullable: false, identity: true),
                        UserVehicleVerificationID = c.Int(nullable: false),
                        FileUrl = c.String(),
                        Description = c.String(),
                        IsTrue = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserVehicleVerificationSupportDocID)
                .ForeignKey("dbo.UserVehicleVerifications", t => t.UserVehicleVerificationID, cascadeDelete: true)
                .Index(t => t.UserVehicleVerificationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserVechicleVerificationDocuments", "UserVehicleVerificationID", "dbo.UserVehicleVerifications");
            DropForeignKey("dbo.UserVehicleVerifications", "UserVehicleID", "dbo.UserVehicles");
            DropForeignKey("dbo.UserVehicles", "VehicleTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.UserVehicles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserVehicleVerifications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserVechicleVerificationDocuments", new[] { "UserVehicleVerificationID" });
            DropIndex("dbo.UserVehicles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserVehicles", new[] { "VehicleTypeID" });
            DropIndex("dbo.UserVehicleVerifications", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserVehicleVerifications", new[] { "UserVehicleID" });
            DropTable("dbo.UserVechicleVerificationDocuments");
            DropTable("dbo.UserVehicles");
            DropTable("dbo.UserVehicleVerifications");
        }
    }
}
