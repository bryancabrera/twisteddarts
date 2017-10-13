using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwistedDarts.DAL;
using TwistedDarts.Models;
using TwistedDarts.ViewModels;

namespace TwistedDarts.Controllers
{
    public class MatchScoreController : Controller
    {
        private TwistedDartsContext db = new TwistedDartsContext();
        private MatchViewModel mvm = new MatchViewModel();
        // GET: MatchScore
        public ActionResult Index(int id)
        {
            var MatchQuery = db.Matches
                
                //.Include(m => m.MatchSets
                //.Select(g => g.Games
                //.Select(r => r.PlayerResults
                //.Select(p => p.PlayerPhase.Person)))
                //)
                .Where(i => i.MatchID == id);

            mvm.Match = MatchQuery.SingleOrDefault();
            ViewBag.HomeTeamID = PopulateTeam(mvm.Match.HomeTeamID, mvm.Match.HomeTeamID);
            ViewBag.AWayTeamID = PopulateTeam(mvm.Match.AwayTeamID, mvm.Match.AwayTeamID);

           // ViewBag.AwayTeamID = new SelectList(db.Matches.Select(t => t.AwayTeam.PlayerPhase), "PlayerPhaseID", "FullName");
            // mvm.HomeTeam = MatchQuery.Select(h => h.HomeTeam).Include(p => p.PlayerPhase.Select(ps => ps.Person)).SingleOrDefault();
            return View(mvm);
        }
        private SelectList PopulateTeam(int? teamID = null, object selectedSeason = null)
        {
            var TeamQuery = db.PlayerPhase.Where(p => p.TeamID == teamID).Include
                (p => p.Person).OrderBy(p => p.Person.FirstName);
            List<PlayerPhase> team = TeamQuery.ToList();

        
            //    (from pp in db.PlayerPhase
            //                   join p in db.People on pp.PersonID equals p.PersonID
            //                   where pp.TeamID == teamID
            //                   select pp
            //                   )
            //                  ;
            return new SelectList(TeamQuery, nameof(PlayerPhase.PlayerPhaseID), nameof(PlayerPhase.PlayerName), selectedSeason);

        }

    }
}