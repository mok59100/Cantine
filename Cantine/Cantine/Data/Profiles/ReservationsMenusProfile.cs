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
    class ReservationsMenusProfile : Profile
    {
        public ReservationsMenusProfile()
        {
            CreateMap<ReservationMenu, ReservationsMenusDTOIn>();
            CreateMap<ReservationsMenusDTOIn, ReservationMenu>();
            CreateMap<ReservationMenu, ReservationsMenusDTOOut>().ForMember(menu => menu.LibelleMenu, o=>o.MapFrom(reservationMenu => reservationMenu.Menu.LibelleMenu)).ForMember(menu => menu.Entree, o => o.MapFrom(reservationMenu => reservationMenu.Menu.Entree)).ForMember(menu => menu.Plat, o => o.MapFrom(reservationMenu => reservationMenu.Menu.Plat)).ForMember(menu => menu.Dessert, o => o.MapFrom(reservationMenu => reservationMenu.Menu.Dessert)).ForMember(menu => menu.Prix, o => o.MapFrom(reservationMenu => reservationMenu.Menu.Prix));
        }
    }
}
