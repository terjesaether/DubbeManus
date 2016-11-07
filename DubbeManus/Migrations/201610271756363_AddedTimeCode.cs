namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTimeCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScriptLines", "TimeCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScriptLines", "TimeCode");
        }
    }
}
