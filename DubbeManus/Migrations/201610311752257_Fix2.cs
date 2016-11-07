namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ScriptLines", "SeriesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScriptLines", "SeriesId", c => c.Int(nullable: false));
        }
    }
}
