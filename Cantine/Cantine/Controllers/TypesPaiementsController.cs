using AutoMapper;
using Cantine.Data;
using Cantine.Data.Dtos;
using Cantine.Data.Models;
using Cantine.Data.Profiles;
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

        public TypesPaiementsController(CantineContext _context)
        {
            _service = new TypesPaiementsServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TypesPaiementsProfile>();
            });
            _mapper = config.CreateMapper();
        }

        //GET api/TypesPaiements
        [HttpGet]
        public IEnumerable<TypesPaiementsDTOIn> GetAllTypesPaiements()
        {
            IEnumerable<TypePaiement> listeTypesPaiements = _service.GetAllTypePaiements();
            return _mapper.Map<IEnumerable<TypesPaiementsDTOIn>>(listeTypesPaiements);
        }

        //GET api/TypesPaiements/{i}
        [HttpGet("{id}", Name = "GetTypePaiementById")]
        public TypesPaiementsDTOIn GetTypePaiementById(int id)
        {
            TypePaiement commandItem = _service.GetTypePaiementsById(id);
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
            _service.AddTypePaiements(obj);  
        }

        //POST api/TypesPaiements/{id}
        [HttpPut("{id}")]
        public bool  UpdateTypePaiement(int id, TypesPaiementsDTOIn obj)
        {
            TypePaiement objFromRepo = _service.GetTypePaiementsById(id);
            if (objFromRepo == null)
            {
                return false;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateTypePaiements(objFromRepo);
            return true;
        }


        //DELETE api/TypesPaiements/{id}
        [HttpDelete("{id}")]
        public bool DeleteTypePaiement(int id)
        {
            TypePaiement obj = _service.GetTypePaiementsById(id);
            if (obj == null)
            {
                return false;
            }
            _service.DeleteTypePaiements(obj);
            return true;
        }


    }
}
