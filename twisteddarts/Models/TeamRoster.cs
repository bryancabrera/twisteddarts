using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public class TeamRoster
    {
        public int TeamRosterID { get; set; }     
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public int TeamID { get; set; }
        public virtual Team Team { get; set; }

        //public int PlayerMembershipID { get; set; }
        public int? SeasonID { get; set; }
        public virtual Season Season { get; set; }


        //public int ScheduleID { get; set; }
       // public virtual Schedule Schedule { get; set; }

        public virtual List<PlayerMembership> PlayerMemberships { get; set; }
    }
}