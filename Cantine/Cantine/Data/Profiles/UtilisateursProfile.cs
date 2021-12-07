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
    class UtilisateursProfile : Profile
    {
        public UtilisateursProfile()
        {
            CreateMap<Utilisateur, UtilisateursDTOIn>();
            CreateMap<UtilisateursDTOIn, Utilisateur>();
        }
    }
}
