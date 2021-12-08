using AutoMapper;
using Cantine.Data.Dtos;
using Cantine.Data.Models;
using Cantine.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Controllers
{
    class UtilisateursController : ControllerBase
    {

        private readonly UtilisateursServices _service;
        private readonly IMapper _mapper;

        public UtilisateursController(UtilisateursServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Utilisateurs
        [HttpGet]
        public IEnumerable<UtilisateursDTOIn> GetAllUtilisateurs()
        {
            IEnumerable<Utilisateur> listeUtilisateurs = _service.GetAllUtilisateurs();
            return _mapper.Map<IEnumerable<UtilisateursDTOIn>>(listeUtilisateurs);
        }

        //GET api/Utilisateurs/{i}
        [HttpGet("{id}", Name = "GetUtilisateurById")]
        public UtilisateursDTOIn GetUtilisateurById(int id)
        {
            Utilisateur commandItem = _service.GetUtilisateurById(id);
            if (commandItem != null)
            {
                return _mapper.Map<UtilisateursDTOIn>(commandItem);
            }
            return null;
        }

        public UtilisateursDTOIn GetUtilisateurByLoginEtMotDePasse(string login, string mdp)
        {
            Utilisateur commandItem = _service.GetUtilisateurByLoginEtMotDePasse(login,mdp);
            if (commandItem != null)
            {
                return _mapper.Map<UtilisateursDTOIn>(commandItem);
            }
            return null;
        }

        //POST api/Utilisateurs
        [HttpPost]
        public void CreateUtilisateur(UtilisateursDTOIn objIn)
        {
            Utilisateur obj = _mapper.Map<Utilisateur>(objIn);
            _service.AddUtilisateur(obj);
        }

        //POST api/Utilisateurs/{id}
        [HttpPut("{id}")]
        public bool UpdateUtilisateur(int id, UtilisateursDTOIn obj)
        {
            Utilisateur objFromRepo = _service.GetUtilisateurById(id);
            if (objFromRepo == null)
            {
                return false;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateUtilisateur(objFromRepo);
            return true;
        }

        

        //DELETE api/Utilisateurs/{id}
        [HttpDelete("{id}")]
        public bool DeleteUtilisateur(int id)
        {
            Utilisateur obj = _service.GetUtilisateurById(id);
            if (obj == null)
            {
                return false;
            }
            _service.DeleteUtilisateur(obj);
            return true;
        }


    }
}
