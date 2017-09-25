using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    
    public class GamePlayer
    {
        public int GamePlayerID { get; set; }
        public int PlayerMembshipID { get; set; }
        //public GameResult GameResult { get; set; }
        public Result Result { get; set; }
        public virtual IList<AllStarPoint> AllStarPoints { get; set; }
        public short PlayerSequence { get; set; }
        public int GameID { get; set; }
        public virtual Game Game { get; set; }

        public virtual List<GameResult> GameResults { get; set; }
    }
}