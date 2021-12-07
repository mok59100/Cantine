using System;
using System.Collections.Generic;

#nullable disable

namespace Cantine.Data.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            Reglements = new HashSet<Reglement>();
            Reservationsmenus = new HashSet<ReservationsMenu>();
        }

        public int IdReservation { get; set; }
        public DateTime DateReservation { get; set; }
        public DateTime DateRepas { get; set; }
        public int IdUtilisateur { get; set; }

        public virtual Eleve IdUtilisateurNavigation { get; set; }
        public virtual ICollection<Reglement> Reglements { get; set; }
        public virtual ICollection<ReservationsMenu> Reservationsmenus { get; set; }
    }
}
