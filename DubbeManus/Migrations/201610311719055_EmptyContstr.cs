namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyContstr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScriptLines", "SeriesId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScriptLines", "SeriesId");
        }
    }
}
