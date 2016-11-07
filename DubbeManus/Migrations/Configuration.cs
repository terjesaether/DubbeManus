namespace DubbeManus.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<DubbeManus.Models.NordubbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DubbeManus.Models.NordubbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Series.AddOrUpdate(
              p => p.OrigName,
              new Models.Series
              {
                  OrigName = "Dora the Explorer",
                  LocalName = "Dora Utforskeren",
                  Characters = new List<Models.Character>
              {
                  new Models.Character { OrigName = "Dora", LocalName = "Dora" },
                  new Models.Character { OrigName = "The Map", LocalName = "Kartet" },
                  new Models.Character { OrigName = "Backpack", LocalName = "Ryggsekk" },
                  new Models.Character { OrigName = "Diego", LocalName = "Diego" }
              },
                  Episodes = new List<Models.Episode>
                  {
                      new Models.Episode
                    {
                  OrigName = "Dora finds the Map",
                  LocalName = "Dora finner Kartet",
                  ScriptLines = new List<Models.ScriptLine>
              {
                  new Models.ScriptLine() { ScriptLineText = "Bla bla bla", CharacterId = 1, TimeCode = "00.01.01.12"  },
                  new Models.ScriptLine() { ScriptLineText = "Bla bla bla bla bli bol", CharacterId = 2, TimeCode = "00.01.01.15" },
                  new Models.ScriptLine() { ScriptLineText = "Hei! Åssen gårde", CharacterId= 3, TimeCode = "00.02.02.16" },
                  new Models.ScriptLine() { ScriptLineText = "Dora, du er en babe!", CharacterId= 2, TimeCode = "00.02.02.16" },
                  new Models.ScriptLine() { ScriptLineText = "Hei! Åssen gårde med deg", CharacterId= 4, TimeCode = "00.02.02.16" }

              }
                      },

                  new Models.Episode { OrigName = "The Map finds Dora", LocalName = "Kartet finner Dora" },
                  new Models.Episode { OrigName = "Dora gets lost", LocalName = "Dora går seg vill" }
              }
              },

                  new Models.Series { OrigName = "Puss in Boots", LocalName = "Pus i støvler" },
                  new Models.Series { OrigName = "Trollhunter", LocalName = "Trolljegeren" }
            );
        }



    }
}
