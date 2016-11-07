using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DubbeManus.Models
{
    public class NordubbContext : DbContext
    {
        public NordubbContext() : base("DefaultConnection")
        {
            //Database.SetInitializer<NordubbContext>(new CreateDatabaseIfNotExists<NordubbContext>());
            Database.SetInitializer<NordubbContext>(new DropCreateDatabaseIfModelChanges<NordubbContext>());
            //Database.SetInitializer<NordubbContext>(new DropCreateDatabaseAlways<NordubbContext>());

        }

        public DbSet<Series> Series { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ScriptLine> ScriptLines { get; set; }
    }
}