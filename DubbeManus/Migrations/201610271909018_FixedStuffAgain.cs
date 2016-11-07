namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedStuffAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Episodes", "SeriesId", "dbo.Series");
            DropIndex("dbo.Episodes", new[] { "SeriesId" });
            RenameColumn(table: "dbo.Episodes", name: "SeriesId", newName: "Series_SeriesId");
            AddColumn("dbo.ScriptLines", "Episode_EpisodeId", c => c.Int());
            AlterColumn("dbo.Episodes", "Series_SeriesId", c => c.Int());
            CreateIndex("dbo.Episodes", "Series_SeriesId");
            CreateIndex("dbo.ScriptLines", "Episode_EpisodeId");
            AddForeignKey("dbo.ScriptLines", "Episode_EpisodeId", "dbo.Episodes", "EpisodeId");
            AddForeignKey("dbo.Episodes", "Series_SeriesId", "dbo.Series", "SeriesId");
            DropColumn("dbo.ScriptLines", "SeriesId");
            DropColumn("dbo.ScriptLines", "EpisodeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScriptLines", "EpisodeId", c => c.Int(nullable: false));
            AddColumn("dbo.ScriptLines", "SeriesId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Episodes", "Series_SeriesId", "dbo.Series");
            DropForeignKey("dbo.ScriptLines", "Episode_EpisodeId", "dbo.Episodes");
            DropIndex("dbo.ScriptLines", new[] { "Episode_EpisodeId" });
            DropIndex("dbo.Episodes", new[] { "Series_SeriesId" });
            AlterColumn("dbo.Episodes", "Series_SeriesId", c => c.Int(nullable: false));
            DropColumn("dbo.ScriptLines", "Episode_EpisodeId");
            RenameColumn(table: "dbo.Episodes", name: "Series_SeriesId", newName: "SeriesId");
            CreateIndex("dbo.Episodes", "SeriesId");
            AddForeignKey("dbo.Episodes", "SeriesId", "dbo.Series", "SeriesId", cascadeDelete: true);
        }
    }
}
