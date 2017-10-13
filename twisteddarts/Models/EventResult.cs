using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public abstract class EventResult
    {
        public int EventResultID { get; set; }

        public int? ParentID { get; set; }

        [ForeignKey("ParentID")]
        public EventResult Parent { get; set; }
                                           //public Result Result { get; set; }


        public DateTime SubmissionDate { get; set; }
        public DateTime? LastRevisionDate { get; set; }

        //integrate with login
        //public Person SubmissionPerson { get; set; }
        public bool IsFinal { get; set; }
        public bool MatchesOpponent { get; set; }
        public bool IsApproved { get; set; }

        public short HomeTeamScore { get; set; }
        public short AwayTeamScore { get; set; }

        public short Sequence { get; set; }

        public int WinningTeamID { get; set; }

        [ForeignKey("WinningTeamID")]
        public virtual Team WinningTeam { get; set; }

        public int SubmittingTeamID { get; set; }

        [ForeignKey("SubmittingTeamID")]
        public virtual Team SubmittingTeam { get; set; }
    }
}