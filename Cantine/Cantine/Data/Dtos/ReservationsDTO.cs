using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Dtos
{

    class ReservationsDTOIn
    {
        public DateTime  DateReservation { get; set; }

        public DateTime Repas { get; set; }

        public int IdUtilisateur { get; set; }

    }
    class ReservationsDTOOutUtilisateur
    {
        public DateTime DateReservation { get; set; }

        public DateTime Repas { get; set; }

         Liste<ReservationsMenusDTOOut> Resa { get; set; }

    }

     class ReservationsDTOOutAdmin
    {
    public DateTime DateReservation { get; set; }

    public DateTime Repas { get; set; }

    Liste<ReservationsMenusDTOOut> { get; set; }

    public ElevesDTOOut student { get; set; }

    }

    class ReservationsDTOOutReglement
    {
    public DateTime DateReservation { get; set; }

    public DateTime Repas { get; set; }



    }

}
