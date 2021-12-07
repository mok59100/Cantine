﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Cantine.Data.Models
{
    public partial class Reservationsmenu
    {
        public int IdReservationMenu { get; set; }
        public int? IdMenu { get; set; }
        public int? IdReservation { get; set; }

        public virtual Menus IdMenuNavigation { get; set; }
        public virtual Reservations IdReservationNavigation { get; set; }
    }
}
