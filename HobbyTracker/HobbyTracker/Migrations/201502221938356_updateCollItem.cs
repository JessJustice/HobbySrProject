namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCollItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Collection", "ItemID", c => c.Int(nullable: false));
            AddColumn("dbo.Item", "Collection_CollectionID", c => c.Int());
            CreateIndex("dbo.Item", "Collection_CollectionID");
            AddForeignKey("dbo.Item", "Collection_CollectionID", "dbo.Collection", "CollectionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "Collection_CollectionID", "dbo.Collection");
            DropIndex("dbo.Item", new[] { "Collection_CollectionID" });
            DropColumn("dbo.Item", "Collection_CollectionID");
            DropColumn("dbo.Collection", "ItemID");
        }
    }
}
