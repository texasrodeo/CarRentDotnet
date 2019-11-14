using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentDotnet.Models
{
    public class Contract
    {
        public int Id { get; set; }

       // public int ClientId { get; set; }

        public int CarId { get; set; }

        //public int AdminId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Boolean IsApproved { get; set; }
    }
}