namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCharacterTOScriptLine : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ScriptLines", "CharacterId");
            AddForeignKey("dbo.ScriptLines", "CharacterId", "dbo.Characters", "CharacterId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScriptLines", "CharacterId", "dbo.Characters");
            DropIndex("dbo.ScriptLines", new[] { "CharacterId" });
        }
    }
}
