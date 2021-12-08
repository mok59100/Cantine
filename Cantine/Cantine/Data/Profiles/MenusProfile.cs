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
    public class MenusProfile : Profile
    {
        public MenusProfile()
            {

               CreateMap<Menu, MenusDTOIn>();
               CreateMap<MenusDTOIn, Menu>();
            CreateMap<Menu, MenusDTOOutData>();
            CreateMap<MenusDTOOutData, Menu>();

        }












    }
}
