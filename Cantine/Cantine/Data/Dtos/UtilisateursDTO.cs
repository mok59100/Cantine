using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Dtos
{
    public partial class UtilisateursDTOIn
    {
   
        public int TypeUtilisateur { get; set; }
        public string Login { get; set; }
        public string MotDePasse { get; set; }
    }
}

