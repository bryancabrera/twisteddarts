using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public class GameResult
    {
        public int GameResultID { get; set; }
        public int GameID { get; set; }
        public int WinningTeamID { get; set; }
    }
}