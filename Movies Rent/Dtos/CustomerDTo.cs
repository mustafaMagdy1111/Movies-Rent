using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Movies_Rent.Controllers;
using Movies_Rent.Models; 
namespace Movies_Rent.Dtos
{
    public class CustomerDTo
    {
        public int id { get; set; }

        [Required]
        [StringLength(225)]
        public string name { get; set; }

        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewLetter { get; set; }
        public MemberShipTypeDto MemberShipType { get; set; }

        // [Min18YearIfAMember]
        public byte MemberShipTypeId { get; set; }
    }
}