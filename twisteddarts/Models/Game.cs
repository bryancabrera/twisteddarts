using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace TwistedDarts.Models
{
    public enum GameName { Three01, Four01, Five01, Six01, Cricket};
    public enum GameFormat {Singles=1, Doubles=2}

    
    public class Game

    {
        public int GameID { get; set; }
        public GameName GameName { get; set; }
        public GameFormat GameFormat { get; set; }
        public int MatchID { get; set; }
        public ICollection<Person> Players { get; set; }
        //public int HomeTeamID { get; set; }
        //public int AwayTeamID { get; set; }
        public Int16 PointValue {
            get {
                return (short)GameFormat;
                }
        }
        public bool IsForfeit { get; set; }
        public Int16 GameSequence { get; set; }

        public virtual Match Match { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }

    }
}