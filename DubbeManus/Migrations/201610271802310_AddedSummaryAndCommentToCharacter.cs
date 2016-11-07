namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSummaryAndCommentToCharacter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Summary", c => c.String());
            AddColumn("dbo.Characters", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "Comments");
            DropColumn("dbo.Characters", "Summary");
        }
    }
}
