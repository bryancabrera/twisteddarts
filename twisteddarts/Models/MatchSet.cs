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
        public ICollection<Game> Games { get; set; }
    }
}