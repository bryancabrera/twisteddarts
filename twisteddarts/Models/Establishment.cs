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
        public Address Address { get; set; }
        //public int PersonID { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
        public virtual Person Manager { get; set; }
    }
}