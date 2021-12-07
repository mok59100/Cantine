using System;
using System.Collections.Generic;

#nullable disable

namespace Cantine.Data.Models
{
    public partial class Reglement
    {
        public int IdReglement { get; set; }
        public int? IdUtilisateur { get; set; }
        public int? IdTypePaiement { get; set; }
        public int? IdReservation { get; set; }
        public DateTime DateReglement { get; set; }

        public virtual Reservation IdReservationNavigation { get; set; }
        public virtual Typepaiement IdTypePaiementNavigation { get; set; }
        public virtual Eleve IdUtilisateurNavigation { get; set; }
    }
}
