using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies_Rent.Models;
using Movies_Rent.Controllers;

namespace Movies_Rent.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MemberShipType> MembershipTypes { get; set; }
        public customer Customer { get; set; }
    }
}