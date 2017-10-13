using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwistedDarts.DAL;
using TwistedDarts.Models;
namespace TwistedDarts.ViewModels
{
    public class MatchViewModel
    {
        public int GameMatchID { get; set; }
        public Match Match { get; set; }
        public string MatchName { get; set; }
        public virtual IList<MatchSet> MatchSets { get; set; }
        public int HomeTeamID { get; set; }
        public virtual Team HomeTeam { get; set; }
        public int AwayTeamID { get; set; }
        public virtual Team AwayTeam { get; set; }
    }
}