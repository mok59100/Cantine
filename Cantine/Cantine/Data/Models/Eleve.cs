using System;
using System.Collections.Generic;

#nullable disable

namespace Cantine.Data.Models
{
    public partial class Eleve
    {
        public Eleve()
        {
            Reglements = new HashSet<Reglement>();
            Reservations = new HashSet<Reservation>();
        }

        public int IdUtilisateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Classe { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string Adresse { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<Reglement> Reglements { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
