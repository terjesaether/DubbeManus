using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DubbeManus.Models
{
    public interface IScriptLine
    {
        int CharacterId { get; set; }
        Character Character { get; set; }
        string ScriptLineText { get; set; }
        string TimeCode { get; set; }
        List<Character> AllSeriesCharacters { get; set; }

    }
}