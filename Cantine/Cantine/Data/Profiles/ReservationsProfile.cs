using AutoMapper;
using Cantine.Data.Dtos;
using Cantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Profiles
{
    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
            {
                CreateMap<Reservations, ReservationsDTOIn>();
                CreateMap<ReservationsDTOIn, Reservations>();
                CreateMap<Reservations, ReservationsDTOOutUtilisateur>();
                CreateMap<ReservationsDTOOutUtilisateur, Reservations>();
            
                CreateMap<Reservations, ReservationsDTOOutAdmin>();
                CreateMap<ReservationsDTOOutAdmin, Reservations>();
                CreateMap<Reservations, ReservationsDTOOutReglement>();
                CreateMap<ReservationsDTOOutReglement, Reservations>();

            }
    }
}
