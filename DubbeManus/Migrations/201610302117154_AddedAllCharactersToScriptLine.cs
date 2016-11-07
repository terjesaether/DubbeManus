namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAllCharactersToScriptLine : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ScriptLines", "CharacterId", "dbo.Characters");
            DropIndex("dbo.ScriptLines", new[] { "CharacterId" });
            AddColumn("dbo.Characters", "ScriptLine_ScriptLineId", c => c.Int());
            AddColumn("dbo.ScriptLines", "Character_CharacterId", c => c.Int());
            CreateIndex("dbo.Characters", "ScriptLine_ScriptLineId");
            CreateIndex("dbo.ScriptLines", "Character_CharacterId");
            AddForeignKey("dbo.Characters", "ScriptLine_ScriptLineId", "dbo.ScriptLines", "ScriptLineId");
            AddForeignKey("dbo.ScriptLines", "Character_CharacterId", "dbo.Characters", "CharacterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScriptLines", "Character_CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Characters", "ScriptLine_ScriptLineId", "dbo.ScriptLines");
            DropIndex("dbo.ScriptLines", new[] { "Character_CharacterId" });
            DropIndex("dbo.Characters", new[] { "ScriptLine_ScriptLineId" });
            DropColumn("dbo.ScriptLines", "Character_CharacterId");
            DropColumn("dbo.Characters", "ScriptLine_ScriptLineId");
            CreateIndex("dbo.ScriptLines", "CharacterId");
            AddForeignKey("dbo.ScriptLines", "CharacterId", "dbo.Characters", "CharacterId", cascadeDelete: true);
        }
    }
}
