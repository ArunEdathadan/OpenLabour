namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
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
                    })
                .PrimaryKey(t => t.AreaID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.EventMasters",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        TitleNative = c.String(),
                        Title = c.String(),
                        SmallDescriptionNative = c.String(),
                        SmallDescription = c.String(),
                        BigDescriptionNative = c.String(),
                        BigDescription = c.String(),
                        HtmlContent = c.String(),
                        MetaTags = c.String(),
                        MetaNative = c.String(),
                        MetaDescription = c.String(),
                        ParentID = c.Int(),
                        CreatedByUserID = c.String(maxLength: 128),
                        CategoryID = c.Int(),
                        CityID = c.Int(),
                        StateID = c.Int(),
                        CountryID = c.Int(),
                        AreaID = c.Int(),
                        PostOfficeID = c.Int(),
                        LocalPlaceID = c.Int(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUserID)
                .ForeignKey("dbo.Areas", t => t.AreaID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .ForeignKey("dbo.Countries", t => t.CountryID)
                .ForeignKey("dbo.EventMasters", t => t.ParentID)
                .ForeignKey("dbo.LocalPlaces", t => t.LocalPlaceID)
                .ForeignKey("dbo.PostOffices", t => t.PostOfficeID)
                .ForeignKey("dbo.States", t => t.StateID)
                .Index(t => t.ParentID)
                .Index(t => t.CreatedByUserID)
                .Index(t => t.CityID)
                .Index(t => t.StateID)
                .Index(t => t.CountryID)
                .Index(t => t.AreaID)
                .Index(t => t.PostOfficeID)
                .Index(t => t.LocalPlaceID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ParentUserID = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.LocalPlaces",
                c => new
                    {
                        LocalPlaceID = c.Int(nullable: false, identity: true),
                        LocalPlaceName = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.LocalPlaceID);
            
            CreateTable(
                "dbo.PostOffices",
                c => new
                    {
                        PostOfficeID = c.Int(nullable: false, identity: true),
                        PostOfficeName = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.PostOfficeID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        SateName = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.StateID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserImageStores",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageLoc = c.String(),
                        Description = c.String(),
                        ProfilePic = c.String(),
                        Active = c.Boolean(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.CommentMasters",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentDetails = c.String(),
                        UpVoteCount = c.Int(nullable: false),
                        DownVoteCount = c.Int(nullable: false),
                        CommentEmotion = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                        CommentedByID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.AspNetUsers", t => t.CommentedByID, cascadeDelete: true)
                .ForeignKey("dbo.EventMasters", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.CommentedByID);
            
            CreateTable(
                "dbo.CommentReplyMasters",
                c => new
                    {
                        CommentReplyID = c.Int(nullable: false, identity: true),
                        CommentDetail = c.String(),
                        CommentedByID = c.String(nullable: false, maxLength: 128),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentReplyID)
                .ForeignKey("dbo.AspNetUsers", t => t.CommentedByID, cascadeDelete: true)
                .ForeignKey("dbo.CommentReplyMasters", t => t.ParentID)
                .Index(t => t.CommentedByID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreatedByUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUserID)
                .Index(t => t.CreatedByUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "CreatedByUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentReplyMasters", "ParentID", "dbo.CommentReplyMasters");
            DropForeignKey("dbo.CommentReplyMasters", "CommentedByID", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentMasters", "EventID", "dbo.EventMasters");
            DropForeignKey("dbo.CommentMasters", "CommentedByID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserImageStores", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.EventMasters", "StateID", "dbo.States");
            DropForeignKey("dbo.EventMasters", "PostOfficeID", "dbo.PostOffices");
            DropForeignKey("dbo.EventMasters", "LocalPlaceID", "dbo.LocalPlaces");
            DropForeignKey("dbo.EventMasters", "ParentID", "dbo.EventMasters");
            DropForeignKey("dbo.EventMasters", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.EventMasters", "CityID", "dbo.Cities");
            DropForeignKey("dbo.EventMasters", "AreaID", "dbo.Areas");
            DropForeignKey("dbo.EventMasters", "CreatedByUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "CreatedByUserID" });
            DropIndex("dbo.CommentReplyMasters", new[] { "ParentID" });
            DropIndex("dbo.CommentReplyMasters", new[] { "CommentedByID" });
            DropIndex("dbo.CommentMasters", new[] { "CommentedByID" });
            DropIndex("dbo.CommentMasters", new[] { "EventID" });
            DropIndex("dbo.UserImageStores", new[] { "UserID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.EventMasters", new[] { "LocalPlaceID" });
            DropIndex("dbo.EventMasters", new[] { "PostOfficeID" });
            DropIndex("dbo.EventMasters", new[] { "AreaID" });
            DropIndex("dbo.EventMasters", new[] { "CountryID" });
            DropIndex("dbo.EventMasters", new[] { "StateID" });
            DropIndex("dbo.EventMasters", new[] { "CityID" });
            DropIndex("dbo.EventMasters", new[] { "CreatedByUserID" });
            DropIndex("dbo.EventMasters", new[] { "ParentID" });
            DropTable("dbo.Categories");
            DropTable("dbo.CommentReplyMasters");
            DropTable("dbo.CommentMasters");
            DropTable("dbo.UserImageStores");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.States");
            DropTable("dbo.PostOffices");
            DropTable("dbo.LocalPlaces");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.EventMasters");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Areas");
        }
    }
}
