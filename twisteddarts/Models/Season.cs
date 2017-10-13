using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public class Season
    {
        public int SeasonID { get; set; }
        public string SeasonName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime RegistrationStartDate { get; set; }

        [Required]
        public DateTime RegistrationCloseDate { get; set; }

        //public virtual PlayerPhase Roster { get; set; }
        // public ICollection<DateTime> BlackoutDays { get; set; }
        // public IList<Schedule> Schedules { get; set; }
        //public virtual List<Team> Team { get; set; }

    }
}