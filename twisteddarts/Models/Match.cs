using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public class Match
    {
        public int MatchID { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public DateTime? AltDateTime { get; set; }
        public DateTime? ActualDateTime { get; set; }
        public Establishment Establishment { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Season Season { get; set; }
        public bool IsForfeit { get; set; }
        public Int16? HomeScore { get; }
        public Int16? AwayScore { get; }

        public virtual ICollection<MatchSet> MatchSets { get; set; }

    }
}