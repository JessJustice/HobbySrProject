namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixActivityEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "Email");
        }
    }
}
