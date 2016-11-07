using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DubbeManus.Models
{
    public class EditScriptViewModels
    {
        private NordubbContext _db = new NordubbContext();
        public EditScriptViewModels()
        {
            Characters = new List<Character>();
            ScriptLines = new List<ScriptLine>();
            ListOfCharactersPerLine = new List<List<SelectListItem>>();
        }


        public EditScriptViewModels(int seriesId, int epId)
        {
            Series = _db.Series.Find(seriesId);
            Episode = _db.Episodes.Find(epId);

            Characters = Series.Characters.ToList();

            ScriptLines = Episode.ScriptLines.ToList();
            ScriptLinesMVC = FillScriptLinesMVC(ScriptLines, seriesId, epId);


        }
        public List<ScriptLine> ScriptLines { get; set; }
        public List<ScriptLineMVC> ScriptLinesMVC { get; set; }
        public List<List<SelectListItem>> ListOfCharactersPerLine { get; set; }
        public Series Series { get; set; }
        public Episode Episode { get; set; }
        public List<Character> Characters { get; set; }
        public List<SelectListItem> CharacterList { get; set; }



        public List<ScriptLineMVC> FillScriptLinesMVC(List<ScriptLine> list, int seriesId, int epId)
        {
            var listMVC = new List<ScriptLineMVC>();

            foreach (var item in list)
            {
                var scriptLineMVC = new ScriptLineMVC();
                scriptLineMVC.Character = _db.Characters.Find(item.CharacterId);
                scriptLineMVC.CharacterId = item.CharacterId;
                scriptLineMVC.ScriptLineId = item.ScriptLineId;
                scriptLineMVC.ScriptLineText = item.ScriptLineText;
                scriptLineMVC.TimeCode = item.TimeCode;
                scriptLineMVC.AllSeriesCharacters = _db.Characters.Where(c => c.SeriesId == seriesId).ToList();
                scriptLineMVC.CharactersSelectList = GetCharactersSelectList(scriptLineMVC.CharacterId, scriptLineMVC.AllSeriesCharacters);

                listMVC.Add(scriptLineMVC);
            }

            return listMVC;
        }

        public List<SelectListItem> GetCharactersSelectList(int CharacterId, List<Character> AllSeriesCharacters)
        {
            var charList = new List<SelectListItem>();
            int i = 1;
            foreach (var c in AllSeriesCharacters)
            {
                var list = new SelectListItem
                {
                    Value = c.CharacterId.ToString(),
                    Text = c.LocalName,
                    Selected = c.CharacterId == CharacterId
                };
                charList.Add(list);
                i++;
            }
            return charList;
        }

    }

    // ==== ScriptLineMVC ====

    public class ScriptLineMVC : IScriptLine
    {
        private NordubbContext _db = new NordubbContext();
        public ScriptLineMVC()
        {

        }

        public int ScriptLineId { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public string ScriptLineText { get; set; }
        public string TimeCode { get; set; }
        public List<Character> AllSeriesCharacters { get; set; }
        public List<SelectListItem> CharactersSelectList { get; set; }


    }
}