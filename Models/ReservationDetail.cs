using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Models
{
    public class ReservationDetail
    {
        public int ReservationDetailId { get; set; }

        public int ReservationId { get; set; }
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public Product Product { get; set; }

        public Reservation Reservation { get; set; }


    }
}
