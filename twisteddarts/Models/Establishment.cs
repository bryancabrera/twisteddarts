using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace TwistedDarts.Models
{
    public class Establishment
    {
        public int EstablishmentID { get; set; }
        public string EstablishmentName { get; set; }
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        //public int PersonID { get; set; }

        public virtual IList<Team> Teams { get; set; }
        //public virtual Person Manager { get; set; }
    }
}