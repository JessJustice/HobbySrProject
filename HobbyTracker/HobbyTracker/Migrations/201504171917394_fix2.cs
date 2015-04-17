namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        ActName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        WillAttend = c.Boolean(nullable: false),
                        Community_CommunityID = c.Int(),
                    })
                .PrimaryKey(t => t.ActivityID)
                .ForeignKey("dbo.Communities", t => t.Community_CommunityID)
                .Index(t => t.Community_CommunityID);
            
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        TextInput = c.String(),
                        CommunityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Communities", t => t.CommunityID, cascadeDelete: true)
                .Index(t => t.CommunityID);
            
            CreateTable(
                "dbo.Communities",
                c => new
                    {
                        CommunityID = c.Int(nullable: false, identity: true),
                        CommunityName = c.String(),
                        CommunityLocation = c.String(),
                        CommunityLoc = c.String(),
                        DescriptionField = c.String(),
                    })
                .PrimaryKey(t => t.CommunityID);
            
            CreateTable(
                "dbo.NewUserModels",
                c => new
                    {
                        NewUserModelID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.NewUserModelID);
            
            AddColumn("dbo.CollectionItems", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Items", "GenreID", c => c.Int());
            CreateIndex("dbo.CollectionItems", "User_Id");
            CreateIndex("dbo.Items", "GenreID");
            AddForeignKey("dbo.Items", "GenreID", "dbo.Genres", "GenreID");
            AddForeignKey("dbo.CollectionItems", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "CommunityID", "dbo.Communities");
            DropForeignKey("dbo.Activities", "Community_CommunityID", "dbo.Communities");
            DropForeignKey("dbo.CollectionItems", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Items", "GenreID", "dbo.Genres");
            DropIndex("dbo.Comments", new[] { "CommunityID" });
            DropIndex("dbo.Items", new[] { "GenreID" });
            DropIndex("dbo.CollectionItems", new[] { "User_Id" });
            DropIndex("dbo.Activities", new[] { "Community_CommunityID" });
            DropColumn("dbo.Items", "GenreID");
            DropColumn("dbo.CollectionItems", "User_Id");
            DropTable("dbo.NewUserModels");
            DropTable("dbo.Communities");
            DropTable("dbo.Comments");
            DropTable("dbo.Administrators");
            DropTable("dbo.Activities");
        }
    }
}
