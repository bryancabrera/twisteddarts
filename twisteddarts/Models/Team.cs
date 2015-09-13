using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public int EstablishmentID { get; set; }
        public DayOfWeek PlayDay { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual Establishment Establishment { get; set; }
        
    }
}