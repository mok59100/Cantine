using AutoMapper;
using Cantine.Data.Dtos;
using Cantine.Data.Models;
using Cantine.Data.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cantine.Data.Dtos.ReglementsDTO;

namespace Cantine.Controllers
{
    class ReglementsController : ControllerBase
    {

        private readonly ReglementsServices _service;
        private readonly IMapper _mapper;

        public ReglementsController(ReglementsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Reglements
        [HttpGet]
        public IEnumerable<ReglementsDTOOutUtilisateur> GetAllReglements()
        {
            IEnumerable<Reglement> listeReglements = _service.GetAllReglements();
            return _mapper.Map<IEnumerable<ReglementsDTOOutUtilisateur>>(listeReglements);
        }

        //GET api/Reglements/{i}
        [HttpGet("{id}", Name = "GetReglementById")]
        public ReglementsDTOOutAdmin GetReglementById(int id)
        {
            Reglement commandItem = _service.GetReglementById(id);
            if (commandItem != null)
            {
                return _mapper.Map<ReglementsDTOOutAdmin>(commandItem);
            }
            return null;
        }

        [HttpGet("{idUtilisateur}", Name = "GetReglementsByEleves")]
        public IEnumerable<ReglementsDTOOutAdmin> GetReglementByEleves(int idUtilisateur)
        {
            IEnumerable<Reglement> listeReglements = _service.GetReglementsByEleves(idUtilisateur);
            return _mapper.Map<IEnumerable<ReglementsDTOOutAdmin>>(listeReglements);
        }

        [HttpGet("{idReservation}", Name = "GetReglementsByReservations")]
        public IEnumerable<ReglementsDTOOutAdmin> GetReglementByReservations(int idReservation)
        {
            IEnumerable<Reglement> listeReglements = _service.GetReglementsByReservations(idReservation);
            return _mapper.Map<IEnumerable<ReglementsDTOOutAdmin>>(listeReglements);
        }

        //POST api/Reglements
        [HttpPost]
        public void CreateReglement(Reglement obj)
        {
            _service.AddReglement(obj);
        }

        //POST api/Reglements/{id}
        [HttpPut("{id}")]
        public bool UpdateReglement(int id, ReglementsDTOIn obj)
        {
            Reglement objFromRepo = _service.GetReglementById(id);
            if (objFromRepo == null)
            {
                return false;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateReglement(objFromRepo);
            return true;
        }

        //DELETE api/Reglements/{id}
        [HttpDelete("{id}")]
        public bool DeleteReglement(int id)
        {
            Reglement obj = _service.GetReglementById(id);
            if (obj == null)
            {
                return false;
            }
            _service.DeleteReglement(obj);
            return true;
        }


    }
}
