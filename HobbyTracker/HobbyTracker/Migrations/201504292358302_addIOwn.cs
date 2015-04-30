namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIOwn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectionItems", "IOwn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CollectionItems", "IOwn");
        }
    }
}
