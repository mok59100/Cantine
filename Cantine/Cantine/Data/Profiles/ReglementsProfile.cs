using Cantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cantine.Data.Dtos.ReglementsDTO;
using AutoMapper;
 
namespace Cantine.Data.Profiles
{
    class ReglementsProfile : Profile
    {
        public ReglementsProfile()
        {
            CreateMap<Reglement, ReglementsDTOIn>();
            CreateMap<ReglementsDTOIn, Reglement>();

            CreateMap<Reglement, ReglementsDTOOutUtilisateur>();
            CreateMap<ReglementsDTOOutUtilisateur, Reglement>();

            CreateMap<Reglement, ReglementsDTOOutAdmin>();
            CreateMap<ReglementsDTOOutAdmin, Reglement>();

        }
    }
}
