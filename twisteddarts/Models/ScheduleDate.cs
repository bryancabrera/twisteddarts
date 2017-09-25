using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwistedDarts.Models
{
    public class ScheduleDate
    {
        public int ScheduleDateID { get; set; }
        public DateTime GameDate { get; set; }
        public int ScheduleID { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}