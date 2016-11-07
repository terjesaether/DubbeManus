namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedEpisodeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Episodes", "Series_SeriesId", "dbo.Series");
            DropIndex("dbo.Episodes", new[] { "Series_SeriesId" });
            RenameColumn(table: "dbo.Episodes", name: "Series_SeriesId", newName: "SeriesId");
            AlterColumn("dbo.Episodes", "SeriesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Episodes", "SeriesId");
            AddForeignKey("dbo.Episodes", "SeriesId", "dbo.Series", "SeriesId", cascadeDelete: true);
            DropColumn("dbo.Series", "EpisodeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Series", "EpisodeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Episodes", "SeriesId", "dbo.Series");
            DropIndex("dbo.Episodes", new[] { "SeriesId" });
            AlterColumn("dbo.Episodes", "SeriesId", c => c.Int());
            RenameColumn(table: "dbo.Episodes", name: "SeriesId", newName: "Series_SeriesId");
            CreateIndex("dbo.Episodes", "Series_SeriesId");
            AddForeignKey("dbo.Episodes", "Series_SeriesId", "dbo.Series", "SeriesId");
        }
    }
}
