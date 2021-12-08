using AutoMapper;
using Cantine.Data;
using Cantine.Data.Dtos;
using Cantine.Data.Models;
using Cantine.Data.Profiles;
using Cantine.Data.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Controllers
{
    class ElevesController : ControllerBase
    {

        private readonly ElevesServices _service;
        private readonly IMapper _mapper;

        public ElevesController(CantineContext _context)
        {
            _service = new ElevesServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ElevesProfile>();

            });
            _mapper = config.CreateMapper();
        }

        //GET api/Eleves
        [HttpGet]
        public IEnumerable<ElevesDTOOut> GetAllEleves()
        {
            IEnumerable<Eleve> listeEleves = _service.GetAllEleves();
            return _mapper.Map<IEnumerable<ElevesDTOOut>>(listeEleves);
        }

        //GET api/Eleves/{i}
        [HttpGet("{id}", Name = "GetEleveById")]
        public ElevesDTOOut GetEleveById(int id)
        {
            Eleve commandItem = _service.GetEleveById(id);
            if (commandItem != null)
            {
                return _mapper.Map<ElevesDTOOut>(commandItem);
            }
            return null;
        }

        //POST api/Eleves
        [HttpPost]
        public void CreateEleve(ElevesDTOIn objIn)
        {
            Eleve obj = _mapper.Map<Eleve>(objIn);
            _service.AddEleve(obj);
            
        }

        //POST api/Eleves/{id}
        [HttpPut("{id}")]
        public bool UpdateEleve(int id, ElevesDTOIn obj)
        {
            Eleve objFromRepo = _service.GetEleveById(id);
            if (objFromRepo == null)
            {
                return false;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateEleve(objFromRepo);
            return true;
        }

        
        //DELETE api/Eleves/{id}
        [HttpDelete("{id}")]
        public bool DeleteEleve(int id)
        {
            Eleve obj = _service.GetEleveById(id);
            if (obj == null)
            {
                return false;
            }
            _service.DeleteEleve(obj);
            return true;
        }


    }
}
