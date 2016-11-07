namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Div : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Gender", c => c.String());
            AddColumn("dbo.Characters", "Comment", c => c.String());
            AddColumn("dbo.Characters", "MainCharacter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Characters", "Comments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characters", "Comments", c => c.String());
            DropColumn("dbo.Characters", "MainCharacter");
            DropColumn("dbo.Characters", "Comment");
            DropColumn("dbo.Characters", "Gender");
        }
    }
}
