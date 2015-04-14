namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Communities", "testField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Communities", "testField");
        }
    }
}
