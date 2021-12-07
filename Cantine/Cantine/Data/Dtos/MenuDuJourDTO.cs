using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Dtos
{
    class MenuDuJourDTOIn
    {
        public DateTime DateDuJour { get; set; }
        public List<MenusDTOIn> Menus { get; set; }
    }

    class MenuDuJourDTOOut
    {
        public DateTime DateDuJour { get; set; }
        public List<MenusDTOIn> Menus { get; set; }
    }
}
