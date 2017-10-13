using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TwistedDarts.Models;

namespace TwistedDarts.ViewModels
{
    public class JoinTeamViewModel
    {

        public int TeamID { get; set; }

        [Display(Name = "Team Name")]
        public Team Team { get; set; }

        public int SeasonID { get; set; }
        public string SeasonName { get; set; }


        [Display(Name = "Players")]
        public IEnumerable<Person> People { get; set; }
        public int PersonID { get; set; }

        [Display(Name = "Existing Players")]
        public IEnumerable<PlayerPhase> Players { get; set; }

    }
}