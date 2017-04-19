namespace GamesStudios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelsvalues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "Name", c => c.String());
            AddColumn("dbo.Genre", "Name", c => c.String());
            DropColumn("dbo.Game", "Name");
            DropColumn("dbo.Game", "Surname");
            DropColumn("dbo.Game", "number_on_shirt");
            DropColumn("dbo.Genre", "Name");
            DropColumn("dbo.Genre", "doc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genre", "doc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genre", "Name", c => c.String());
            AddColumn("dbo.Game", "number_on_shirt", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "Surname", c => c.String());
            AddColumn("dbo.Game", "Name", c => c.String());
            DropColumn("dbo.Genre", "Name");
            DropColumn("dbo.Game", "Name");
        }
    }
}
