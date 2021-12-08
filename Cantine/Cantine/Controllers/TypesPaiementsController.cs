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
    class TypesPaiementsController: ControllerBase
    {

        private readonly TypesPaiementsServices _service;
        private readonly IMapper _mapper;

        public TypesPaiementsController(TypesPaiementsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/TypesPaiements
        [HttpGet]
        public IEnumerable<TypesPaiementsDTOIn> GetAllTypesPaiements()
        {
            IEnumerable<TypePaiement> listeTypesPaiements = _service.GetAllTypesPaiements();
            return _mapper.Map<IEnumerable<TypesPaiementsDTOIn>>(listeTypesPaiements);
        }

        //GET api/TypesPaiements/{i}
        [HttpGet("{id}", Name = "GetTypePaiementById")]
        public TypesPaiementsDTOIn GetTypePaiementById(int id)
        {
            TypePaiement commandItem = _service.GetTypePaiementById(id);
            if (commandItem != null)
            {
                return _mapper.Map<TypesPaiementsDTOIn>(commandItem);
            }
            return null;
        }

        //POST api/TypesPaiements
        [HttpPost]
        public void CreateTypePaiement(TypePaiement obj)
        {
            _service.AddTypePaiement(obj);  
        }

        //POST api/TypesPaiements/{id}
        [HttpPut("{id}")]
        public bool  UpdateTypePaiement(int id, TypesPaiementsDTOIn obj)
        {
            TypePaiement objFromRepo = _service.GetTypePaiementById(id);
            if (objFromRepo == null)
            {
                return false;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateTypePaiement(objFromRepo);
            return true;
        }


        //DELETE api/TypesPaiements/{id}
        [HttpDelete("{id}")]
        public bool DeleteTypePaiement(int id)
        {
            TypePaiement obj = _service.GetTypePaiementById(id);
            if (obj == null)
            {
                return false;
            }
            _service.DeleteTypePaiement(obj);
            return true;
        }


    }
}
