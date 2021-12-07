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
    class ElevesProfile : Profile
    {
        public ElevesProfile()
        {
            CreateMap<Eleve, ElevesDTOIn>();
            CreateMap<ElevesDTOIn, Eleve>();

            CreateMap<Eleve, ElevesDTOOut>();
            CreateMap<ElevesDTOOut, Eleve>();

          
        }
       
    }
}
