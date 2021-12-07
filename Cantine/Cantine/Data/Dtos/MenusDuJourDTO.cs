using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Dtos
{
    class MenusDuJourDTOIn
    {
        public DateTime DateDuJour { get; set; }
        public List<MenusDTOIn> Menus { get; set; }
    }

    class MenusDuJourDTOOut
    {
        public DateTime DateDuJour { get; set; }
        public List<MenusDTOIn> Menus { get; set; }
    }
}
