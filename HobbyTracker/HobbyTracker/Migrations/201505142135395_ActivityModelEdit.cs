namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityModelEdit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Activities", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "Email", c => c.String(nullable: false));
        }
    }
}
