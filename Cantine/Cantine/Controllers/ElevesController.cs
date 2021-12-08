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

namespace Cantine.Controllers
{
    class ElevesController : ControllerBase
    {

        private readonly ElevesServices _service;
        private readonly IMapper _mapper;

        public ElevesController(ElevesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Eleves
        [HttpGet]
        public ActionResult<IEnumerable<ElevesDTOOut>> GetAllEleves()
        {
            IEnumerable<Eleve> listeEleves = _service.GetAllEleves();
            return Ok(_mapper.Map<IEnumerable<ElevesDTOOut>>(listeEleves));
        }

        //GET api/Eleves/{i}
        [HttpGet("{id}", Name = "GetEleveById")]
        public ActionResult<ElevesDTOOut> GetEleveById(int id)
        {
            Eleve commandItem = _service.GetEleveById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<ElevesDTOOut>(commandItem));
            }
            return NotFound();
        }

        //POST api/Eleves
        [HttpPost]
        public ActionResult<ElevesDTOIn> CreateEleve(Eleve obj)
        {
            _service.AddEleve(obj);
            return CreatedAtRoute(nameof(GetEleveById), new { Id = obj.IdUtilisateur}, obj);
        }

        //POST api/Eleves/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEleve(int id, ElevesDTOIn obj)
        {
            Eleve objFromRepo = _service.GetEleveById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateEleve(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/Eleves/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialEleveUpdate(int id, JsonPatchDocument<Eleve> patchDoc)
        {
            Eleve objFromRepo = _service.GetEleveById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            Eleve objToPatch = _mapper.Map<Eleve>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateEleve(objFromRepo);
            return NoContent();
        }

        //DELETE api/Eleves/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEleve(int id)
        {
            Eleve obj = _service.GetEleveById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteEleve(obj);
            return NoContent();
        }


    }
}
