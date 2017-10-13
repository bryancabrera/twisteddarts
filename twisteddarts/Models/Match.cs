using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public enum MatchType { Regular = 1, Playoff = 2, Tournament = 3 }
    public class Match
    {
        public int MatchID { get; set; }
        public string MatchName { get; set; }

        public int ScheduleDateID { get; set; }
        [Display(Name = "Scheduled Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual ScheduleDate ScheduledDate { get; set; }
        public MatchType Type { get; set; }
        [Display(Name = "Rescheduled Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AltDateTime { get; set; }

        [Display(Name = "Actual Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ActualDateTime { get; set; }
        public short PointTotal { get; set; }

        public int EstablishmentID { get; set; }
        public virtual Establishment Establishment { get; set; }

        public int HomeTeamID { get; set; }
        [ForeignKey("HomeTeamID")]
        public virtual Team HomeTeam { get; set; }

        public int AwayTeamID { get; set; }
        [ForeignKey("AwayTeamID")]
        public virtual Team AwayTeam { get; set; }

        public int SeasonID { get; set; }
        public Season Season { get; set; }
        public bool IsForfeit { get; set; } = false;
        //public Int16? HomeScore { get; }
        //public Int16? AwayScore { get; }

        //public virtual IList<Game> Games { get; set; }

        public virtual IList<MatchSet> MatchSets { get; set; }

        [Display(Name ="Home Team Score")]

        public int HomeTeamScore => this.MatchSets.Sum(m => m.HomeTeamTotal);

        [Display(Name = "Away Team Score")]
        public int AwayTeamScore => this.MatchSets.Sum(m => m.AwayTeamTotal);
     

    }
}