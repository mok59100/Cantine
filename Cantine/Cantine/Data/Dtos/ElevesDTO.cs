using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Dtos
{
    public partial class EleveDTOIn
    {
        
        
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Classe { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string Adresse { get; set; }
        public string Mail { get; set; }
       
    }

    public partial class EleveDTOOut
    {

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Classe { get; set; }
       

    }
}
