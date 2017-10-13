using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public class MatchUp
    {
        public int MatchUpID { get; set; }

        public int HomeTeamID { get; set; }

        [ForeignKey("HomeTeamID")]
        public virtual Team HomeTeam { get; set; }

        public int AwayTeamID { get; set; }

        [ForeignKey("AwayTeamID")]
        public virtual Team AwayTeam { get; set; }

        public int ScheduleDateID { get; set; }

    }
}