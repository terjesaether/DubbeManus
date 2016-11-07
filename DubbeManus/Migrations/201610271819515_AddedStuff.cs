namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "SeriesId", c => c.Int(nullable: false));
            AddColumn("dbo.Characters", "Episode_EpisodeId", c => c.Int());
            CreateIndex("dbo.Characters", "SeriesId");
            CreateIndex("dbo.Characters", "Episode_EpisodeId");
            AddForeignKey("dbo.Characters", "Episode_EpisodeId", "dbo.Episodes", "EpisodeId");
            AddForeignKey("dbo.Characters", "SeriesId", "dbo.Series", "SeriesId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "SeriesId", "dbo.Series");
            DropForeignKey("dbo.Characters", "Episode_EpisodeId", "dbo.Episodes");
            DropIndex("dbo.Characters", new[] { "Episode_EpisodeId" });
            DropIndex("dbo.Characters", new[] { "SeriesId" });
            DropColumn("dbo.Characters", "Episode_EpisodeId");
            DropColumn("dbo.Characters", "SeriesId");
        }
    }
}
