using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public DateTime JoinDate { get; set; }
        public DayOfWeek PlayDay { get; set; }
        public bool IsActive { get; set; }
        public int EstablishmentID { get; set; }
        public virtual Establishment Establishment { get; set; }
        public virtual IList<PlayerPhase> PlayerPhase { get; set; }
    }
}