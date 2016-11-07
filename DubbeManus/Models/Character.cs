using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DubbeManus.Models
{
    public class Character
    {
        public Character()
        {
            Actor = new List<Actor>();
        }
        [Key]
        public int CharacterId { get; set; }
        public int SeriesId { get; set; }
        public string OrigName { get; set; }
        public string LocalName { get; set; }
        public string Gender { get; set; }
        public string Summary { get; set; }
        public string Comment { get; set; }
        public bool MainCharacter { get; set; }
        public virtual List<Actor> Actor { get; set; }
        public Actor CurrentActor { get; set; }
    }
}