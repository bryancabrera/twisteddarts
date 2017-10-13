using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public enum Result { pending, win, loss }

    public class PlayerResult
    {
        public int PlayerResultID { get; set; }
        public int PlayerPhaseID { get; set; }
        public PlayerPhase PlayerPhase { get; set; }
        public short PlayerSequence { get; set; }
        public Result Result { get; set; }
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
        public int SubmittingTeamID { get; set; }
        [ForeignKey("SubmittingTeamID")]
        public Team SubmittingTeam { get; set; }

        public DateTime SubmissionDateTime { get; set; } = DateTime.Now;
    }
}