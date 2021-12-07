using System;
using System.Collections.Generic;

#nullable disable

namespace Cantine.Data.Models
{
    public partial class Utilisateur
    {
        public int IdUtilisateur { get; set; }
        public int TypeUtilisateur { get; set; }
        public string Login { get; set; }
        public string MotDePasse { get; set; }
    }
}
