using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwistedDarts.Models;

namespace TwistedDarts.ViewModels
{
    public class MatchSetViewModel
    {
        public int MatchSetID { get; set; }
        public short MatchSetSequence { get; set; }
        public short HomeTeamScore { get; set; }
        public short AwayTeamScore { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}