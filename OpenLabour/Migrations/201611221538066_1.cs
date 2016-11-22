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
                "dbo.AssetTypes",
                c => new
                    {
                        AssetID = c.Int(nullable: false, identity: true),
                        AssectTypeName = c.String(),
                        CreatedByUserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AssetID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUserID, cascadeDelete: true)
                .Index(t => t.CreatedByUserID);
            
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
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .ForeignKey("dbo.Countries", t => t.CountryID)
                .ForeignKey("dbo.EventMasters", t => t.ParentID)
                .ForeignKey("dbo.LocalPlaces", t => t.LocalPlaceID)
                .ForeignKey("dbo.PostOffices", t => t.PostOfficeID)
                .ForeignKey("dbo.States", t => t.StateID)
                .Index(t => t.ParentID)
                .Index(t => t.CreatedByUserID)
                .Index(t => t.CategoryID)
                .Index(t => t.CityID)
                .Index(t => t.StateID)
                .Index(t => t.CountryID)
                .Index(t => t.AreaID)
                .Index(t => t.PostOfficeID)
                .Index(t => t.LocalPlaceID);
            
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
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
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
                "dbo.JobEngagements",
                c => new
                    {
                        JobEngID = c.Int(nullable: false, identity: true),
                        JobDescription = c.String(),
                        ConfirationCount = c.Int(nullable: false),
                        JobTitle = c.String(),
                        JobDetails = c.String(),
                        OrgID = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.JobEngID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Organisations", t => t.OrgID, cascadeDelete: true)
                .Index(t => t.OrgID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Organisations",
                c => new
                    {
                        OrganisationID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Brief = c.String(),
                        Description = c.String(),
                        IdentificationNumber = c.String(),
                        IdentificationType = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        GoogleMaps = c.String(),
                        IsVerfied = c.Boolean(),
                        OwnerID = c.String(),
                        IsBranch = c.Boolean(),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.OrganisationID)
                .ForeignKey("dbo.Organisations", t => t.ParentID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        JobTypeID = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        Active = c.Boolean(),
                        JobParentID = c.Int(),
                    })
                .PrimaryKey(t => t.JobTypeID)
                .ForeignKey("dbo.JobTypes", t => t.JobParentID)
                .Index(t => t.JobParentID);
            
            CreateTable(
                "dbo.OrganisationAssets",
                c => new
                    {
                        UserAssetID = c.Int(nullable: false, identity: true),
                        AssetTitle = c.String(),
                        AssetDetails = c.String(),
                        PhoneNumber = c.String(),
                        VehicleNumber = c.String(),
                        InstitutionNumber = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        OrganisationID = c.Int(nullable: false),
                        AssetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAssetID)
                .ForeignKey("dbo.AssetTypes", t => t.AssetID, cascadeDelete: true)
                .ForeignKey("dbo.Organisations", t => t.OrganisationID, cascadeDelete: true)
                .Index(t => t.OrganisationID)
                .Index(t => t.AssetID);
            
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
                "dbo.SubsriptionToUsers",
                c => new
                    {
                        UserSubsriptionID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SubscribedByUserID = c.String(),
                        SubscribedOnUserID = c.String(nullable: false, maxLength: 128),
                        Active = c.Boolean(),
                        SubscribedDate = c.DateTime(nullable: false),
                        ApplicationUserSubscribedOn_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserSubsriptionID)
                .ForeignKey("dbo.AspNetUsers", t => t.SubscribedOnUserID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserSubscribedOn_Id)
                .Index(t => t.SubscribedOnUserID)
                .Index(t => t.ApplicationUserSubscribedOn_Id);
            
            CreateTable(
                "dbo.UserAssets",
                c => new
                    {
                        UserAssetID = c.Int(nullable: false, identity: true),
                        AssetTitle = c.String(),
                        AssetDetails = c.String(),
                        PhoneNumber = c.String(),
                        VehicleNumber = c.String(),
                        IdentificationNumber = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        AssetTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAssetID)
                .ForeignKey("dbo.AssetTypes", t => t.AssetTypeID, cascadeDelete: true)
                .Index(t => t.AssetTypeID);
            
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        UserImageID = c.Int(nullable: false, identity: true),
                        ImageThumpNailUrl = c.String(),
                        ImageLargeUrl = c.String(),
                        ImageDesc = c.String(),
                        IsActive = c.Boolean(),
                        UploadedDate = c.DateTime(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserImageID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
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
                "dbo.UserAssetVerfications",
                c => new
                    {
                        UserAssetVerifyID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        VerficationDate = c.DateTime(nullable: false),
                        UserAssetsID = c.Int(nullable: false),
                        VerifiedByUserID = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserAssetVerifyID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.UserAssets", t => t.UserAssetsID, cascadeDelete: true)
                .Index(t => t.UserAssetsID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserAssetVerificationDocuments",
                c => new
                    {
                        UserAssetVerificationSupportDocID = c.Int(nullable: false, identity: true),
                        FileUrl = c.String(),
                        Description = c.String(),
                        UserAssetVerificationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAssetVerificationSupportDocID)
                .ForeignKey("dbo.UserAssetVerfications", t => t.UserAssetVerificationID, cascadeDelete: true)
                .Index(t => t.UserAssetVerificationID);
            
            CreateTable(
                "dbo.SubscriptionToOrganisations",
                c => new
                    {
                        OrganisationSubscriptionID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SubscribedByUserID = c.String(nullable: false, maxLength: 128),
                        SubscribedOnOrganisationID = c.Int(nullable: false),
                        Active = c.Boolean(),
                        SubscribedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrganisationSubscriptionID)
                .ForeignKey("dbo.AspNetUsers", t => t.SubscribedByUserID, cascadeDelete: true)
                .ForeignKey("dbo.Organisations", t => t.SubscribedOnOrganisationID, cascadeDelete: true)
                .Index(t => t.SubscribedByUserID)
                .Index(t => t.SubscribedOnOrganisationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubscriptionToOrganisations", "SubscribedOnOrganisationID", "dbo.Organisations");
            DropForeignKey("dbo.SubscriptionToOrganisations", "SubscribedByUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAssetVerificationDocuments", "UserAssetVerificationID", "dbo.UserAssetVerfications");
            DropForeignKey("dbo.UserAssetVerfications", "UserAssetsID", "dbo.UserAssets");
            DropForeignKey("dbo.UserAssetVerfications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserImageStores", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserImages", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAssets", "AssetTypeID", "dbo.AssetTypes");
            DropForeignKey("dbo.SubsriptionToUsers", "ApplicationUserSubscribedOn_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubsriptionToUsers", "SubscribedOnUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrganisationAssets", "OrganisationID", "dbo.Organisations");
            DropForeignKey("dbo.OrganisationAssets", "AssetID", "dbo.AssetTypes");
            DropForeignKey("dbo.JobTypes", "JobParentID", "dbo.JobTypes");
            DropForeignKey("dbo.JobEngagements", "OrgID", "dbo.Organisations");
            DropForeignKey("dbo.Organisations", "ParentID", "dbo.Organisations");
            DropForeignKey("dbo.JobEngagements", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentReplyMasters", "ParentID", "dbo.CommentReplyMasters");
            DropForeignKey("dbo.CommentReplyMasters", "CommentedByID", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentMasters", "EventID", "dbo.EventMasters");
            DropForeignKey("dbo.EventMasters", "StateID", "dbo.States");
            DropForeignKey("dbo.States", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.EventMasters", "PostOfficeID", "dbo.PostOffices");
            DropForeignKey("dbo.EventMasters", "LocalPlaceID", "dbo.LocalPlaces");
            DropForeignKey("dbo.EventMasters", "ParentID", "dbo.EventMasters");
            DropForeignKey("dbo.EventMasters", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.EventMasters", "CityID", "dbo.Cities");
            DropForeignKey("dbo.EventMasters", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.EventMasters", "AreaID", "dbo.Areas");
            DropForeignKey("dbo.EventMasters", "CreatedByUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentMasters", "CommentedByID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "CreatedByUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AssetTypes", "CreatedByUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.SubscriptionToOrganisations", new[] { "SubscribedOnOrganisationID" });
            DropIndex("dbo.SubscriptionToOrganisations", new[] { "SubscribedByUserID" });
            DropIndex("dbo.UserAssetVerificationDocuments", new[] { "UserAssetVerificationID" });
            DropIndex("dbo.UserAssetVerfications", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserAssetVerfications", new[] { "UserAssetsID" });
            DropIndex("dbo.UserImageStores", new[] { "UserID" });
            DropIndex("dbo.UserImages", new[] { "UserID" });
            DropIndex("dbo.UserAssets", new[] { "AssetTypeID" });
            DropIndex("dbo.SubsriptionToUsers", new[] { "ApplicationUserSubscribedOn_Id" });
            DropIndex("dbo.SubsriptionToUsers", new[] { "SubscribedOnUserID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrganisationAssets", new[] { "AssetID" });
            DropIndex("dbo.OrganisationAssets", new[] { "OrganisationID" });
            DropIndex("dbo.JobTypes", new[] { "JobParentID" });
            DropIndex("dbo.Organisations", new[] { "ParentID" });
            DropIndex("dbo.JobEngagements", new[] { "UserID" });
            DropIndex("dbo.JobEngagements", new[] { "OrgID" });
            DropIndex("dbo.CommentReplyMasters", new[] { "ParentID" });
            DropIndex("dbo.CommentReplyMasters", new[] { "CommentedByID" });
            DropIndex("dbo.States", new[] { "CountryID" });
            DropIndex("dbo.EventMasters", new[] { "LocalPlaceID" });
            DropIndex("dbo.EventMasters", new[] { "PostOfficeID" });
            DropIndex("dbo.EventMasters", new[] { "AreaID" });
            DropIndex("dbo.EventMasters", new[] { "CountryID" });
            DropIndex("dbo.EventMasters", new[] { "StateID" });
            DropIndex("dbo.EventMasters", new[] { "CityID" });
            DropIndex("dbo.EventMasters", new[] { "CategoryID" });
            DropIndex("dbo.EventMasters", new[] { "CreatedByUserID" });
            DropIndex("dbo.EventMasters", new[] { "ParentID" });
            DropIndex("dbo.CommentMasters", new[] { "CommentedByID" });
            DropIndex("dbo.CommentMasters", new[] { "EventID" });
            DropIndex("dbo.Categories", new[] { "CreatedByUserID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AssetTypes", new[] { "CreatedByUserID" });
            DropTable("dbo.SubscriptionToOrganisations");
            DropTable("dbo.UserAssetVerificationDocuments");
            DropTable("dbo.UserAssetVerfications");
            DropTable("dbo.UserImageStores");
            DropTable("dbo.UserImages");
            DropTable("dbo.UserAssets");
            DropTable("dbo.SubsriptionToUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrganisationAssets");
            DropTable("dbo.JobTypes");
            DropTable("dbo.Organisations");
            DropTable("dbo.JobEngagements");
            DropTable("dbo.CommentReplyMasters");
            DropTable("dbo.States");
            DropTable("dbo.PostOffices");
            DropTable("dbo.LocalPlaces");
            DropTable("dbo.Countries");
            DropTable("dbo.EventMasters");
            DropTable("dbo.CommentMasters");
            DropTable("dbo.Cities");
            DropTable("dbo.Categories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AssetTypes");
            DropTable("dbo.Areas");
        }
    }
}
