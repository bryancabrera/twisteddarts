using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public class Conference
    {
        public int ConferenceID { get; set; }
        public string ConferenceName { get; set; }

        public int TeamID { get; set; }
        public virtual IList<Team> Teams { get; set; }

    }
}