using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public class MatchSet
    {
        public int MatchSetID { get; set; }
        public Int16 SetSequence { get; set; }
        public short HomeTeamTotal { get; set; }
        public short AwayTeamTotal { get; set; }

        public virtual IList<Game> Games { get; set; }

        public int MatchID { get; set; }
        public virtual Match Match{ get; set; }

    }
}