using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DubbeManus.Models;
using System.Collections;

namespace DubbeManus.Controllers
{
    public class ScriptLinesController : Controller
    {
        private NordubbContext _db = new NordubbContext();

        // GET: ScriptLines
        public ActionResult Index(string EpisodeId, string ChosenSeriesId)
        {
            ChosenSeriesId = "1";
            EpisodeId = "1";
            int seriesId = Convert.ToInt32(ChosenSeriesId);
            int epId = Convert.ToInt32(EpisodeId);
            //var series = _db.Series.Find(seriesId);

            var vm = new EditScriptViewModels(seriesId, epId);

            

            return View(vm);
        }

        

        // GET: ScriptLines/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptLine scriptLine = await _db.ScriptLines.FindAsync(id);
            if (scriptLine == null)
            {
                return HttpNotFound();
            }
            return View(scriptLine);
        }

        // GET: ScriptLines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScriptLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ScriptLineId,SeriesId,EpisodeId,CharacterId,ScriptLineText,TimeCode")] ScriptLine scriptLine)
        {
            if (ModelState.IsValid)
            {
                _db.ScriptLines.Add(scriptLine);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(scriptLine);
        }

        // GET: ScriptLines/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptLine scriptLine = await _db.ScriptLines.FindAsync(id);
            if (scriptLine == null)
            {
                return HttpNotFound();
            }
            return View(scriptLine);
        }

        // POST: ScriptLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ScriptLineId,SeriesId,EpisodeId,CharacterId,ScriptLineText,TimeCode")] ScriptLine scriptLine)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(scriptLine).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(scriptLine);
        }

        // GET: ScriptLines/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptLine scriptLine = await _db.ScriptLines.FindAsync(id);
            if (scriptLine == null)
            {
                return HttpNotFound();
            }
            return View(scriptLine);
        }

        // POST: ScriptLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ScriptLine scriptLine = await _db.ScriptLines.FindAsync(id);
            _db.ScriptLines.Remove(scriptLine);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
