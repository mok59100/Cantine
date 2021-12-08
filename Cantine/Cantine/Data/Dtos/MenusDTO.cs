using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Dtos
{
    public class MenusDTOIn
    {
        public string LibelleMenu { get; set; }
        public string Entree { get; set; }
        public string Plat { get; set; }
        public string Dessert { get; set; }

        public double Prix { get; set; }
    }

    public class MenusDTOOutData
    {
        public int IdMenu { get; set; }
        public string LibelleMenu { get; set; }
        public string Entree { get; set; }
        public string Plat { get; set; }
        public string Dessert { get; set; }

        public double Prix { get; set; }
    }
}
