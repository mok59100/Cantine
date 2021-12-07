using System;
using System.Collections.Generic;

#nullable disable

namespace Cantine.Data.Models
{
    public partial class TypePaiement
    {
        public TypePaiement()
        {
            Reglements = new HashSet<Reglement>();
        }

        public int IdTypePaiement { get; set; }
        public string LibelleTypePaiement { get; set; }

        public virtual ICollection<Reglement> Reglements { get; set; }
    }
}
