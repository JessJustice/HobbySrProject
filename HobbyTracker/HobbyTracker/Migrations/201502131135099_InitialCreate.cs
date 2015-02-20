namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        itemID = c.Int(nullable: false, identity: true),
                        itemDesc = c.String(),
                    })
                .PrimaryKey(t => t.itemID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Item");
        }
    }
}
