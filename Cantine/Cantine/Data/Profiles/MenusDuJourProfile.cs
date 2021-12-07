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
    class MenusDuJourProfile : Profile
    {
        public MenusDuJourProfile()
        {
            CreateMap<MenuDuJour,MenusDuJourDTOIn>();
            CreateMap<MenusDuJourDTOIn,MenuDuJour >();
            CreateMap<MenuDuJour, MenusDuJourDTOOut>();
            CreateMap<MenusDuJourDTOOut, MenuDuJour>();
        }

    }
}
