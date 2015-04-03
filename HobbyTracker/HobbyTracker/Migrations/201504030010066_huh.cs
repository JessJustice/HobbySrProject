namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class huh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Collection_CollectionID", c => c.Int());
            CreateIndex("dbo.Items", "Collection_CollectionID");
            AddForeignKey("dbo.Items", "Collection_CollectionID", "dbo.Collections", "CollectionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Collection_CollectionID", "dbo.Collections");
            DropIndex("dbo.Items", new[] { "Collection_CollectionID" });
            DropColumn("dbo.Items", "Collection_CollectionID");
        }
    }
}
