using System;
using System.ComponentModel.DataAnnotations;

namespace TwistedDarts.Models
{
    public enum GameCategory
    {
        [Display(Name = "01")]
        O1 = 1,
        [Display(Name = "Cricket")]
        Cricket = 2
    }
    public enum GameName
    {
        [Display(Name = "301")]
        Three01,
        [Display(Name = "401")]
        Four01,
        [Display(Name = "501")]
        Five01,
        [Display(Name = "601")]
        Six01,
        [Display(Name = "Cricket")]
        Cricket
    };
    public enum GameFormat : Int16 { Singles = 1, Doubles = 2, Triples = 3 }


    public class Game

    {
        public int GameID { get; set; }
        public GameName GameName { get; set; }
        public GameFormat GameFormat { get; set; }
        //public ICollection<PlayerPhase> Players { get; set; }
        public Int16 PointValue
        {
            get
            {
                return (short)GameFormat;
            }
        }

        public Int16 GameSequence { get; set; }

        public int MatchSetID { get; set; }
        public virtual MatchSet MatchSet { get; set; }

    }
}