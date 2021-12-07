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
                CreateMap<Reservation, ReservationsDTOIn>();
                CreateMap<ReservationsDTOIn, Reservation>();
                CreateMap<Reservation, ReservationsDTOOutUtilisateur>();
                CreateMap<ReservationsDTOOutUtilisateur, Reservation>();
            
                CreateMap<Reservation, ReservationsDTOOutAdmin>();
                CreateMap<ReservationsDTOOutAdmin, Reservation>();
                CreateMap<Reservation, ReservationsDTOOutReglement>();
                CreateMap<ReservationsDTOOutReglement, Reservation>();

            }
    }
}
