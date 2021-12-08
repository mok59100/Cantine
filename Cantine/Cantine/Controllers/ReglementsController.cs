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
        public ActionResult<IEnumerable<ReglementsDTOOutUtilisateur>> GetAllReglements()
        {
            IEnumerable<Reglement> listeReglements = _service.GetAllReglements();
            return Ok(_mapper.Map<IEnumerable<ReglementsDTOOutUtilisateur>>(listeReglements));
        }

        //GET api/Reglements/{i}
        [HttpGet("{id}", Name = "GetReglementById")]
        public ActionResult<ReglementsDTOOutAdmin> GetReglementById(int id)
        {
            Reglement commandItem = _service.GetReglementById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<ReglementsDTOOutAdmin>(commandItem));
            }
            return NotFound();
        }

        //POST api/Reglements
        [HttpPost]
        public ActionResult<ReglementsDTOIn> CreateReglement(Reglement obj)
        {
            _service.AddReglement(obj);
            return CreatedAtRoute(nameof(GetReglementById), new { Id = obj.IdReglement }, obj);
        }

        //POST api/Reglements/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateReglement(int id, ReglementsDTOIn obj)
        {
            Reglement objFromRepo = _service.GetReglementById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateReglement(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/Reglements/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialReglementUpdate(int id, JsonPatchDocument<Reglement> patchDoc)
        {
            Reglement objFromRepo = _service.GetReglementById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            Reglement objToPatch = _mapper.Map<Reglement>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateReglement(objFromRepo);
            return NoContent();
        }

        //DELETE api/Reglements/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteReglement(int id)
        {
            Reglement obj = _service.GetReglementById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteReglement(obj);
            return NoContent();
        }


    }
}
