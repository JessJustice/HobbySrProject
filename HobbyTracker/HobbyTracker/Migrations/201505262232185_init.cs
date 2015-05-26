namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        ActName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        CommunityID = c.Int(nullable: false),
                        UserName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ActivityID)
                .ForeignKey("dbo.Communities", t => t.CommunityID, cascadeDelete: true)
                .Index(t => t.CommunityID);
            
            CreateTable(
                "dbo.Communities",
                c => new
                    {
                        CommunityID = c.Int(nullable: false, identity: true),
                        CommunityName = c.String(nullable: false),
                        CommunityLocation = c.String(),
                        CommunityLoc = c.String(),
                        DescriptionField = c.String(),
                    })
                .PrimaryKey(t => t.CommunityID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        TextInput = c.String(),
                        CommunityID = c.Int(nullable: false),
                        CommentUser = c.String(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Communities", t => t.CommunityID, cascadeDelete: true)
                .Index(t => t.CommunityID);
            
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.CollectionItems",
                c => new
                    {
                        CollectionID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        CollectionItemID = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        IOwn = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CollectionItemID)
                .ForeignKey("dbo.Collections", t => t.CollectionID, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CollectionID)
                .Index(t => t.ItemID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        CollectionID = c.Int(nullable: false, identity: true),
                        CollectionName = c.String(nullable: false),
                        GenreID = c.Int(nullable: false),
                        Private = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CollectionID)
                .ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.GenreID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemDesc = c.String(),
                        GenreID = c.Int(),
                        Collection_CollectionID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Collections", t => t.Collection_CollectionID)
                .ForeignKey("dbo.Genres", t => t.GenreID)
                .Index(t => t.GenreID)
                .Index(t => t.Collection_CollectionID);
            
            CreateTable(
                "dbo.NewUserModels",
                c => new
                    {
                        NewUserModelID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.NewUserModelID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CollectionItems", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CollectionItems", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Items", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.Items", "Collection_CollectionID", "dbo.Collections");
            DropForeignKey("dbo.CollectionItems", "CollectionID", "dbo.Collections");
            DropForeignKey("dbo.Collections", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Collections", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.Comments", "CommunityID", "dbo.Communities");
            DropForeignKey("dbo.Activities", "CommunityID", "dbo.Communities");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Items", new[] { "Collection_CollectionID" });
            DropIndex("dbo.Items", new[] { "GenreID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Collections", new[] { "User_Id" });
            DropIndex("dbo.Collections", new[] { "GenreID" });
            DropIndex("dbo.CollectionItems", new[] { "User_Id" });
            DropIndex("dbo.CollectionItems", new[] { "ItemID" });
            DropIndex("dbo.CollectionItems", new[] { "CollectionID" });
            DropIndex("dbo.Comments", new[] { "CommunityID" });
            DropIndex("dbo.Activities", new[] { "CommunityID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.NewUserModels");
            DropTable("dbo.Items");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Genres");
            DropTable("dbo.Collections");
            DropTable("dbo.CollectionItems");
            DropTable("dbo.Administrators");
            DropTable("dbo.Comments");
            DropTable("dbo.Communities");
            DropTable("dbo.Activities");
        }
    }
}
