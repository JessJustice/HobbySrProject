namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Collection", "GenreID", "dbo.Genre");
            DropForeignKey("dbo.Collection", "User_UserID", "dbo.User");
            DropForeignKey("dbo.Item", "Collection_CollectionID", "dbo.Collection");
            DropForeignKey("dbo.Item", "UserID", "dbo.User");
            DropIndex("dbo.Collection", new[] { "GenreID" });
            DropIndex("dbo.Collection", new[] { "User_UserID" });
            DropIndex("dbo.Item", new[] { "UserID" });
            DropIndex("dbo.Item", new[] { "Collection_CollectionID" });
            DropColumn("dbo.Item", "ItemName");
            DropColumn("dbo.Item", "CollectionID");
            DropColumn("dbo.Item", "UserID");
            DropColumn("dbo.Item", "Collection_CollectionID");
            DropTable("dbo.Collection");
            DropTable("dbo.Genre");
            DropTable("dbo.User");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.Collection",
                c => new
                    {
                        CollectionID = c.Int(nullable: false, identity: true),
                        CollectionName = c.String(),
                        CollectionDescription = c.String(),
                        GenreID = c.Int(nullable: false),
                        UerID = c.Int(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.CollectionID);
            
            AddColumn("dbo.Item", "Collection_CollectionID", c => c.Int());
            AddColumn("dbo.Item", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Item", "CollectionID", c => c.String());
            AddColumn("dbo.Item", "ItemName", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "Collection_CollectionID");
            CreateIndex("dbo.Item", "UserID");
            CreateIndex("dbo.Collection", "User_UserID");
            CreateIndex("dbo.Collection", "GenreID");
            AddForeignKey("dbo.Item", "UserID", "dbo.User", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Item", "Collection_CollectionID", "dbo.Collection", "CollectionID");
            AddForeignKey("dbo.Collection", "User_UserID", "dbo.User", "UserID");
            AddForeignKey("dbo.Collection", "GenreID", "dbo.Genre", "GenreID", cascadeDelete: true);
        }
    }
}
