using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Dtos
{
    class ReservationsMenusDTOIn
    {
        public int IdMenu { get; set; }
        public int IdReservation { get; set; }
    }

    class ReservationsMenusDTOOut
    {
        public string LibelleMenu { get; set; }
        public string Entree { get; set; }
        public string Plat { get; set; }
        public string Dessert { get; set; }
        public int Prix { get; set; }
    }
}
