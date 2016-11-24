namespace OpenLabour.Migrations.ContextA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserContacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        ContactInfo = c.String(),
                        ContactTypeID = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeID, cascadeDelete: true)
                .Index(t => t.ContactTypeID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        ContactTypeID = c.Int(nullable: false, identity: true),
                        ContactTypeName = c.String(),
                        Decription = c.String(),
                        ValidationRules = c.String(),
                    })
                .PrimaryKey(t => t.ContactTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserContacts", "ContactTypeID", "dbo.ContactTypes");
            DropForeignKey("dbo.UserContacts", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.UserContacts", new[] { "UserID" });
            DropIndex("dbo.UserContacts", new[] { "ContactTypeID" });
            DropTable("dbo.ContactTypes");
            DropTable("dbo.UserContacts");
        }
    }
}
