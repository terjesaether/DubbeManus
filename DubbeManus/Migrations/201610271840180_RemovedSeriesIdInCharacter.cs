namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedSeriesIdInCharacter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "SeriesId", "dbo.Series");
            DropIndex("dbo.Characters", new[] { "SeriesId" });
            RenameColumn(table: "dbo.Characters", name: "SeriesId", newName: "Series_SeriesId");
            AlterColumn("dbo.Characters", "Series_SeriesId", c => c.Int());
            CreateIndex("dbo.Characters", "Series_SeriesId");
            AddForeignKey("dbo.Characters", "Series_SeriesId", "dbo.Series", "SeriesId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "Series_SeriesId", "dbo.Series");
            DropIndex("dbo.Characters", new[] { "Series_SeriesId" });
            AlterColumn("dbo.Characters", "Series_SeriesId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Characters", name: "Series_SeriesId", newName: "SeriesId");
            CreateIndex("dbo.Characters", "SeriesId");
            AddForeignKey("dbo.Characters", "SeriesId", "dbo.Series", "SeriesId", cascadeDelete: true);
        }
    }
}
