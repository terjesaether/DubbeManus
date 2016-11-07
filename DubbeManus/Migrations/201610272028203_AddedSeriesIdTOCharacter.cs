namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeriesIdTOCharacter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "Series_SeriesId", "dbo.Series");
            DropIndex("dbo.Characters", new[] { "Series_SeriesId" });
            RenameColumn(table: "dbo.Characters", name: "Series_SeriesId", newName: "SeriesId");
            AlterColumn("dbo.Characters", "SeriesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Characters", "SeriesId");
            AddForeignKey("dbo.Characters", "SeriesId", "dbo.Series", "SeriesId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "SeriesId", "dbo.Series");
            DropIndex("dbo.Characters", new[] { "SeriesId" });
            AlterColumn("dbo.Characters", "SeriesId", c => c.Int());
            RenameColumn(table: "dbo.Characters", name: "SeriesId", newName: "Series_SeriesId");
            CreateIndex("dbo.Characters", "Series_SeriesId");
            AddForeignKey("dbo.Characters", "Series_SeriesId", "dbo.Series", "SeriesId");
        }
    }
}
