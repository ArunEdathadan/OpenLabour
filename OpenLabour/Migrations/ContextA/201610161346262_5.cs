namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaID = c.Int(nullable: false, identity: true),
                        AreaName = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(),
                        EventID = c.Int(nullable: false),
                        CreatedByUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AreaID)
                .ForeignKey("dbo.EventMasters", t => t.EventID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id)
                .Index(t => t.EventID)
                .Index(t => t.CreatedByUser_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        MyProperty = c.String(),
                        EventID = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.EventMasters", t => t.EventID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.EventID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.EventMasters",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Details = c.String(),
                        Title = c.String(),
                        SmallDescription = c.String(),
                        MetaTags = c.String(),
                        MetaDescription = c.String(),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(),
                        CreatedByUser_Id = c.String(maxLength: 128),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id)
                .ForeignKey("dbo.EventMasters", t => t.EventID)
                .Index(t => t.CreatedByUser_Id)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        Description = c.String(),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryID)
                .ForeignKey("dbo.EventMasters", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.LocalPlaces",
                c => new
                    {
                        LocalPlaceID = c.Int(nullable: false, identity: true),
                        LocalPlaceName = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(),
                        CreatedByUser_Id = c.String(maxLength: 128),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocalPlaceID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id)
                .ForeignKey("dbo.EventMasters", t => t.EventID)
                .Index(t => t.CreatedByUser_Id)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.PostOffices",
                c => new
                    {
                        PostOfficeID = c.Int(nullable: false, identity: true),
                        PostOfficeName = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(),
                        CreatedByUser_Id = c.String(maxLength: 128),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostOfficeID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id)
                .ForeignKey("dbo.EventMasters", t => t.EventID)
                .Index(t => t.CreatedByUser_Id)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        SateName = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(),
                        CreatedByUser_Id = c.String(maxLength: 128),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id)
                .ForeignKey("dbo.EventMasters", t => t.EventID)
                .Index(t => t.CreatedByUser_Id)
                .Index(t => t.EventID);
            
            AddColumn("dbo.AspNetUsers", "ParentUserID", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Areas", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventMasters", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.States", "EventID", "dbo.EventMasters");
            DropForeignKey("dbo.States", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostOffices", "EventID", "dbo.EventMasters");
            DropForeignKey("dbo.PostOffices", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocalPlaces", "EventID", "dbo.EventMasters");
            DropForeignKey("dbo.LocalPlaces", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Countries", "EventID", "dbo.EventMasters");
            DropForeignKey("dbo.Cities", "EventID", "dbo.EventMasters");
            DropForeignKey("dbo.Cities", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "EventID", "dbo.EventMasters");
            DropForeignKey("dbo.Areas", "EventID", "dbo.EventMasters");
            DropIndex("dbo.States", new[] { "EventID" });
            DropIndex("dbo.States", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.PostOffices", new[] { "EventID" });
            DropIndex("dbo.PostOffices", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.LocalPlaces", new[] { "EventID" });
            DropIndex("dbo.LocalPlaces", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Countries", new[] { "EventID" });
            DropIndex("dbo.Cities", new[] { "EventID" });
            DropIndex("dbo.Cities", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.EventMasters", new[] { "UserID" });
            DropIndex("dbo.Categories", new[] { "UserID" });
            DropIndex("dbo.Categories", new[] { "EventID" });
            DropIndex("dbo.Areas", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Areas", new[] { "EventID" });
            DropColumn("dbo.AspNetUsers", "ParentUserID");
            DropTable("dbo.States");
            DropTable("dbo.PostOffices");
            DropTable("dbo.LocalPlaces");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.EventMasters");
            DropTable("dbo.Categories");
            DropTable("dbo.Areas");
        }
    }
}
