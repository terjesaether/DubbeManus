using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DubbeManus.Models
{
    public class ScriptLine : IScriptLine
    {
        private NordubbContext _db = new NordubbContext();
        public ScriptLine(int seriesId)
        {
            AllSeriesCharacters = _db.Series.Find(seriesId).Characters.ToList();
        }
        public ScriptLine()
        {

        }

        [Key]
        public int ScriptLineId { get; set; }

        //public int SeriesId { get; set; }
        //public int EpisodeId { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public string ScriptLineText { get; set; }
        public string TimeCode { get; set; }
        public virtual List<Character> AllSeriesCharacters { get; set; }


    }
}