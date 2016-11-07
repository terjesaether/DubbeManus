using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DubbeManus.Models
{
    public class Series
    {
        public Series()
        {
            Episodes = new List<Episode>();
            Characters = new List<Character>();
        }
        [Key]
        public int SeriesId { get; set; }
        public string OrigName { get; set; }
        public string LocalName { get; set; }
        public string Comment { get; set; }
        public string Summary { get; set; }
        public virtual List<Episode> Episodes { get; set; }
        public virtual List<Character> Characters { get; set; }

    }
}