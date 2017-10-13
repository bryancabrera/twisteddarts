using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwistedDarts.Models;
using TwistedDarts.DAL;
using TwistedDarts.ViewModels;

namespace TwistedDarts.Controllers
{
    public class JoinTeamController : Controller
    {

        private TwistedDartsContext db = new TwistedDartsContext();
        // GET: JoinTeam
        [Route("JoinTeam/{teamID}/{seasonID}")]
        public ActionResult Index(int teamID, int seasonID)


        {
            //var team = db.Teams.Single(t => t.TeamID == teamID);

            ViewBag.PersonID = PopulatePeople(teamID: teamID, seasonID: seasonID);


            var viewModel = new JoinTeamViewModel
            {
                People = db.People.OrderBy(n => n.FirstName).ThenBy(n => n.LastName).ToList(),
                Team = db.Teams.Single(t => t.TeamID == teamID),
                Players = db.PlayerPhase
                    .Where(p => p.TeamID == teamID && p.SeasonID == seasonID)
                    .OrderBy(p => p.Role)
                    .ThenBy(p => p.Person.FirstName)
                    .ToList(),
                SeasonName = db.Seasons.Where(s => s.SeasonID == seasonID).Select(s => s.SeasonName).First(),
                SeasonID = seasonID
            };

            return View(viewModel);
        }

        [Route("JoinTeam/{teamID}/{seasonID}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(JoinTeamViewModel model)
        {
            //var isInTeamQuery = db.PlayerPhase.FirstOrDefault(p => p.PersonID == model.PersonID && p.SeasonID == model.SeasonID);
            //if (isInTeamQuery != null)
            //    return View(model);



            if (ModelState.IsValid)
            {
                PlayerPhase playerPhase = new PlayerPhase
                {
                    TeamID = model.Team.TeamID,
                    PersonID = model.PersonID,
                    SeasonID = model.SeasonID,
                    Role = Role.Player,
                    SkillLevel = SkillLevel.Beginner
                };
                db.PlayerPhase.Add(playerPhase);
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { teamID = model.Team.TeamID, seasonID = model.SeasonID });

            // return View();

        }
        private SelectList PopulatePeople(int teamID, int seasonID, object selectedPerson = null)
        {
            var currentTeam = db.PlayerPhase
                .Where(p => p.TeamID == teamID && p.SeasonID == seasonID).Select(p => p.PersonID);

            var PeopleQuery = db.People.OrderBy(p => p.FirstName).ThenBy(p => p.LastName).Where(p => !currentTeam.Contains(p.PersonID));
            return new SelectList(PeopleQuery, nameof(Person.PersonID), nameof(Person.FullName), selectedPerson);
        }
    }
}