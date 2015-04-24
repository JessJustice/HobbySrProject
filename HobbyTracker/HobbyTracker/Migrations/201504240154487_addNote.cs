namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectionItems", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CollectionItems", "Note");
        }
    }
}
