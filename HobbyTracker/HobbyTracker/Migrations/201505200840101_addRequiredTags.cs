namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequiredTags : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Communities", "CommunityName", c => c.String(nullable: false));
            AlterColumn("dbo.Collections", "CollectionName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Collections", "CollectionName", c => c.String());
            AlterColumn("dbo.Communities", "CommunityName", c => c.String());
        }
    }
}
