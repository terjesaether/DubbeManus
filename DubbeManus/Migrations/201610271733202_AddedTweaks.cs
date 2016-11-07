namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTweaks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Character_CharacterId = c.Int(),
                    })
                .PrimaryKey(t => t.ActorId)
                .ForeignKey("dbo.Characters", t => t.Character_CharacterId)
                .Index(t => t.Character_CharacterId);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        OrigName = c.String(),
                        LocalName = c.String(),
                        CurrentActor_ActorId = c.Int(),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.Actors", t => t.CurrentActor_ActorId)
                .Index(t => t.CurrentActor_ActorId);
            
            CreateTable(
                "dbo.Episodes",
                c => new
                    {
                        EpisodeId = c.Int(nullable: false, identity: true),
                        OrigName = c.String(),
                        LocalName = c.String(),
                        Summary = c.String(),
                        Series_SeriesId = c.Int(),
                    })
                .PrimaryKey(t => t.EpisodeId)
                .ForeignKey("dbo.Series", t => t.Series_SeriesId)
                .Index(t => t.Series_SeriesId);
            
            CreateTable(
                "dbo.ScriptLines",
                c => new
                    {
                        ScriptLineId = c.Int(nullable: false, identity: true),
                        SeriesId = c.Int(nullable: false),
                        EpisodeId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        ScriptLineText = c.String(),
                    })
                .PrimaryKey(t => t.ScriptLineId);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        SeriesId = c.Int(nullable: false, identity: true),
                        OrigName = c.String(),
                        LocalName = c.String(),
                        Number = c.String(),
                        Summary = c.String(),
                        EpisodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeriesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Episodes", "Series_SeriesId", "dbo.Series");
            DropForeignKey("dbo.Characters", "CurrentActor_ActorId", "dbo.Actors");
            DropForeignKey("dbo.Actors", "Character_CharacterId", "dbo.Characters");
            DropIndex("dbo.Episodes", new[] { "Series_SeriesId" });
            DropIndex("dbo.Characters", new[] { "CurrentActor_ActorId" });
            DropIndex("dbo.Actors", new[] { "Character_CharacterId" });
            DropTable("dbo.Series");
            DropTable("dbo.ScriptLines");
            DropTable("dbo.Episodes");
            DropTable("dbo.Characters");
            DropTable("dbo.Actors");
        }
    }
}
