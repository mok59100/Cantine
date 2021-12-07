﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Cantine.Data.Models
{
    public partial class Reservations
    {
        public Reservations()
        {
            Reglements = new HashSet<Reglement>();
            Reservationsmenus = new HashSet<Reservationsmenu>();
        }

        public int IdReservation { get; set; }
        public DateTime DateReservation { get; set; }
        public DateTime DateRepas { get; set; }
        public int IdUtilisateur { get; set; }

        public virtual Eleve IdUtilisateurNavigation { get; set; }
        public virtual ICollection<Reglement> Reglements { get; set; }
        public virtual ICollection<Reservationsmenu> Reservationsmenus { get; set; }
    }
}