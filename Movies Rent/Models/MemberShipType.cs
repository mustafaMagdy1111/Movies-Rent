using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies_Rent.Controllers;
using Movies_Rent.Models;
namespace Movies_Rent.Controllers
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationMonth { get; set; }
        public byte DiscountRate { get; set; }
    }
}