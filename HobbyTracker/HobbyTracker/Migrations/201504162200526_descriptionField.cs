namespace HobbyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class descriptionField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Communities", "DescriptionField", c => c.String());
            DropColumn("dbo.Communities", "testField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Communities", "testField", c => c.String());
            DropColumn("dbo.Communities", "DescriptionField");
        }
    }
}
