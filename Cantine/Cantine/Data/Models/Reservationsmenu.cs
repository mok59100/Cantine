using System;
using System.Collections.Generic;

#nullable disable

namespace Cantine.Data.Models
{
    public partial class ReservationsMenu
    {
        public int IdReservationMenu { get; set; }
        public int? IdMenu { get; set; }
        public int? IdReservation { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Reservation IdReservationNavigation { get; set; }
    }
}
