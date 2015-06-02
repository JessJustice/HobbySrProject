namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ratings2RatingsBoogaloo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectionItems", "Rating", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CollectionItems", "Rating");
        }
    }
}
