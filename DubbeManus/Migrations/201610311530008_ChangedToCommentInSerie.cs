namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedToCommentInSerie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "Comment", c => c.String());
            DropColumn("dbo.Series", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Series", "Number", c => c.String());
            DropColumn("dbo.Series", "Comment");
        }
    }
}
