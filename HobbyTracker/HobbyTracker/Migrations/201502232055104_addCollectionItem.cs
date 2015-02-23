namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCollectionItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectionItem",
                c => new
                    {
                        CollectionID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        CollectionItemID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CollectionItemID)
                .ForeignKey("dbo.Collection", t => t.CollectionID, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.CollectionID)
                .Index(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectionItem", "ItemID", "dbo.Item");
            DropForeignKey("dbo.CollectionItem", "CollectionID", "dbo.Collection");
            DropIndex("dbo.CollectionItem", new[] { "ItemID" });
            DropIndex("dbo.CollectionItem", new[] { "CollectionID" });
            DropTable("dbo.CollectionItem");
        }
    }
}
