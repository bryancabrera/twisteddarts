using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public class GameResult
    {
        public int GameResultID { get; set; }
        public Result Result { get; set; }

        public int WinningTeamID { get; set; }
        [ForeignKey("WinningTeamID")]
        public Team WinningTeam { get; set; }

        //public short PointsEarned { get; set; }
        public bool IsForfeit { get; set; }
        
        public int SubmissionTeamID { get; set; }
        [ForeignKey("SubmissionTeamID")]
        public virtual Team SubmissionTeam { get; set; }

        public int GameID { get; set; }
        public virtual Game Game { get; set; }

        //public int PlayerPhaseID { get; set; }
        //public virtual PlayerPhase PlayerPhase { get; set; }

        //public virtual IList<AllStarPoint> AllStarPoints { get; set; }

    }
}