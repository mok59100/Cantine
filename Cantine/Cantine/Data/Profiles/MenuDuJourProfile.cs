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
    class MenuDuJourProfile : Profile
    {
        public MenuDuJourProfile()
        {
            CreateMap<MenuDuJour,MenuDuJourDTOIn>();
            CreateMap<MenuDuJourDTOIn,MenuDuJour >();
            CreateMap<MenuDuJour, MenuDuJourDTOOut>();
            CreateMap<MenuDuJourDTOOut, MenuDuJour>();
        }

    }
}
