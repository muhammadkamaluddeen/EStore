using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class Reservation
    {

        [BindNever]
        public int ReservationId { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<ReservationDetail> ReservationDetails { get; set; }

        public decimal ReservationAmount { get; set; }
        public DateTime ReservationDate { get; set; }

    }
}
