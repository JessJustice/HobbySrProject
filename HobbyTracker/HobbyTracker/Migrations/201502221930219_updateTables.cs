namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collection",
                c => new
                    {
                        CollectionID = c.Int(nullable: false, identity: true),
                        CollectionName = c.String(),
                        UserID = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CollectionID)
                .ForeignKey("dbo.Genre", t => t.GenreID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            AddColumn("dbo.Item", "ItemName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collection", "UserID", "dbo.User");
            DropForeignKey("dbo.Collection", "GenreID", "dbo.Genre");
            DropIndex("dbo.Collection", new[] { "GenreID" });
            DropIndex("dbo.Collection", new[] { "UserID" });
            DropColumn("dbo.Item", "ItemName");
            DropTable("dbo.User");
            DropTable("dbo.Genre");
            DropTable("dbo.Collection");
        }
    }
}
