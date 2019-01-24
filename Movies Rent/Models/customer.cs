using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Movies_Rent.Controllers;

namespace Movies_Rent.Models
{
    public class customer
    {
        public int id { get; set; }

        [Required]
        [StringLength(225)]
        public string name { get; set; }

        [Display(Name ="Date of Birth")]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewLetter { get; set; }

        public MemberShipType MemberShipType  { get; set; }

        [Display(Name = "Member")]
        [Min18YearIfAMember]
        public byte MemberShipTypeId { get; set; }
    }
}