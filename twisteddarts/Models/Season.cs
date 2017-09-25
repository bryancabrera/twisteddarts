using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public class Season
    {
        public int SeasonID { get; set; }
        public string SeasonName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //public virtual PlayerPhase Roster { get; set; }
        // public ICollection<DateTime> BlackoutDays { get; set; }
        // public IList<Schedule> Schedules { get; set; }
        //public virtual List<Team> Team { get; set; }

    }
}