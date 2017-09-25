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
            var MatchQuery = db.Matches.Where(i => i.MatchID == id)
                .Include(m => m.MatchSets.Select(g => g.Games)).ToList();
            mvm.Match = MatchQuery.Single();

            return View(mvm);
        }
    }
}