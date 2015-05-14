namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsUserNameToActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "UserName");
        }
    }
}
