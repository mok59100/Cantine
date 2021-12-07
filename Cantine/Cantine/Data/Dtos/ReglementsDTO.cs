using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Dtos
{
    class ReglementsDTO
    {
        
        public partial class ReglementsDTOIn
        {
         
            public int? IdUtilisateur { get; set; }
            public int? IdReservation { get; set; }
            public int? IdTypePaiement { get; set; }           
            public DateTime DateReglement { get; set; }
        }

        public partial class ReglementsDTOOutUtilisateur
        {
            
            public TypesPaiementsDTOIn TypePaiements { get; set; }
            public ReservationsDTOOutReglement ReservationsAvecReglement { get; set; }
            public DateTime DateReglement { get; set; }
        }

        public partial class ReglementsDTOOutAdmin
        {

            public ElevesDTOOut Eleves { get; set; }
            public TypesPaiementsDTOIn TypePaiements { get; set; }
            public ReservationsDTOOutReglement ReservationsAvecReglement { get; set; }
            public DateTime DateReglement { get; set; }
        }
    }
}
