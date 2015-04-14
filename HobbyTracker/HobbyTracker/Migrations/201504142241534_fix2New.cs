namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2New : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectionItems", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Items", "GenreID", c => c.Int());
            AddColumn("dbo.Communities", "CommunityLoc", c => c.String());
            AddColumn("dbo.Communities", "testField", c => c.String());
            CreateIndex("dbo.CollectionItems", "User_Id");
            CreateIndex("dbo.Items", "GenreID");
            AddForeignKey("dbo.Items", "GenreID", "dbo.Genres", "GenreID");
            AddForeignKey("dbo.CollectionItems", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectionItems", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Items", "GenreID", "dbo.Genres");
            DropIndex("dbo.Items", new[] { "GenreID" });
            DropIndex("dbo.CollectionItems", new[] { "User_Id" });
            DropColumn("dbo.Communities", "testField");
            DropColumn("dbo.Communities", "CommunityLoc");
            DropColumn("dbo.Items", "GenreID");
            DropColumn("dbo.CollectionItems", "User_Id");
        }
    }
}
