namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenreToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "GenreID", c => c.Int());
            CreateIndex("dbo.Items", "GenreID");
            AddForeignKey("dbo.Items", "GenreID", "dbo.Genres", "GenreID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "GenreID", "dbo.Genres");
            DropIndex("dbo.Items", new[] { "GenreID" });
            DropColumn("dbo.Items", "GenreID");
        }
    }
}
