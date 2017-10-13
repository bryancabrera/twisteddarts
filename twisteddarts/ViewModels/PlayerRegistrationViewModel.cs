using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwistedDarts.ViewModels
{
    public class PlayerRegistrationViewModel

    {
        [Required]
        [StringLength(50)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Intial")]
        [StringLength(1)]
        public string MiddleInitial { get; set; }

        [StringLength(20)]
        public string NickName { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string TelephoneNumber { get; set; }

        [Required]
        public string TeamName { get; set; }
        public int TeamID { get; set; }

        [Required]
        public string PlayerType { get; set; }
    }
}