using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace TwistedDarts.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string County { get; set; }
        public string Description { get; set; }
        //[ForeignKey("PersonID")]
        public virtual IList<Person> People { get; set; }
    }
}