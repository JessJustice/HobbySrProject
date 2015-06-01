namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wtf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CollectionItems", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CollectionItems", "Rating", c => c.Int(nullable: false));
        }
    }
}
