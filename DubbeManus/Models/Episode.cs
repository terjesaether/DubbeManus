using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DubbeManus.Models
{
    public class Episode
    {
        public Episode()
        {
            Characters = new List<Character>();
            ScriptLines = new List<ScriptLine>();
        }
        [Key]
        public int EpisodeId { get; set; }
        public int SeriesId { get; set; }
        public string OrigName { get; set; }
        public string LocalName { get; set; }
        public string Summary { get; set; }
        public virtual List<Character> Characters { get; set; }
        public virtual List<ScriptLine> ScriptLines { get; set; }
    }
}