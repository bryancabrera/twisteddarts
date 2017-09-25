using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwistedDarts.DAL;
using TwistedDarts.Models;

namespace TwistedDarts.Controllers
{
    public class PlayerPhasesController : Controller
    {
        private TwistedDartsContext db = new TwistedDartsContext();

        // GET: PlayerPhases
        public ActionResult Index()
        {
            var playerPhase = db.PlayerPhase.Include(p => p.Person).Include(p => p.Season).Include(p => p.Team);
            return View(playerPhase.ToList());
        }

        // GET: PlayerPhases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerPhase playerPhase = db.PlayerPhase.Find(id);
            if (playerPhase == null)
            {
                return HttpNotFound();
            }
            return View(playerPhase);
        }

        // GET: PlayerPhases/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "FirstName");
            ViewBag.PlayerPhaseID = new SelectList(db.Seasons, "SeasonID", "SeasonName");
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name");
            PopulateSeasonDropDownList();
            return View();
        }

        // POST: PlayerPhases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerPhaseID,Role,SkillLevel,StartDate,EndDate,TeamID,PersonID,SeasonID")] PlayerPhase playerPhase)
        {
            try { 
            if (ModelState.IsValid)
            {
                db.PlayerPhase.Add(playerPhase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
}
            catch(RetryLimitExceededException /*dex*/)
            {
                //Log error with dex
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "FirstName", playerPhase.PersonID);
            ViewBag.PlayerPhaseID = new SelectList(db.Seasons, "SeasonID", "SeasonName", playerPhase.PlayerPhaseID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", playerPhase.TeamID);
            PopulateSeasonDropDownList(playerPhase.SeasonID);
            return View(playerPhase);
        }
            

        // GET: PlayerPhases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerPhase playerPhase = db.PlayerPhase.Find(id);
            if (playerPhase == null)
            {
                return HttpNotFound();
            }
            PopulateSeasonDropDownList(playerPhase.SeasonID);
            PopulatePlayerDropDownList(playerPhase.PersonID);
            //ViewBag.PersonID = new SelectList(db.People, "PersonID", "FirstName", playerPhase.PersonID);
            //ViewBag.PlayerPhaseID = new SelectList(db.Seasons, "SeasonID", "SeasonName", playerPhase.PlayerPhaseID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", playerPhase.TeamID);
            
            return View(playerPhase);
        }

        // POST: PlayerPhases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerPhaseID,Role,SkillLevel,StartDate,EndDate,TeamID,PersonID,SeasonID")] PlayerPhase playerPhase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerPhase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.PersonID = new SelectList(db.People, "PersonID", "FirstName", playerPhase.PersonID);
            //ViewBag.PlayerPhaseID = new SelectList(db.Seasons, "SeasonID", "SeasonName", playerPhase.PlayerPhaseID);
            PopulatePlayerDropDownList(playerPhase.PersonID);
            PopulateSeasonDropDownList(playerPhase.SeasonID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "Name", playerPhase.TeamID);
            return View(playerPhase);
        }

        // GET: PlayerPhases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerPhase playerPhase = db.PlayerPhase.Find(id);
            if (playerPhase == null)
            {
                return HttpNotFound();
            }
            return View(playerPhase);
        }

        // POST: PlayerPhases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerPhase playerPhase = db.PlayerPhase.Find(id);
            db.PlayerPhase.Remove(playerPhase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private void PopulateSeasonDropDownList(object selectedSeason = null)
        {
            var SeasonQuery = from s in db.Seasons
                              orderby s.SeasonName
                              select s;
            ViewBag.SeasonID = new SelectList(SeasonQuery, "SeasonID", "SeasonName", selectedSeason);

        }
        private void PopulatePlayerDropDownList(object selectedPlayer = null)
        {
            var PlayerQuery = from p in db.People
                              orderby p.FirstName
                              select p;
            ViewBag.PersonID = new SelectList((from p in PlayerQuery.ToList()
                                               select new
                                               {
                                                   PersonID = p.PersonID,
                                                   Name = p.FirstName + " " + p.LastName
                                               }), "PersonID", "Name");


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
