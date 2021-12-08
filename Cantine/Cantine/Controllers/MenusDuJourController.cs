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
    class MenusDuJourController : ControllerBase
    {

        private readonly MenusDuJourServices _service;
        private readonly IMapper _mapper;

        public MenusDuJourController(MenusDuJourServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/MenusDuJour
        [HttpGet]
        public ActionResult<IEnumerable<MenusDuJourDTOIn>> GetAllMenusDuJour()
        {
            IEnumerable<MenuDuJour> listeMenusDuJour = _service.GetAllMenusDuJour();
            return Ok(_mapper.Map<IEnumerable<MenusDuJourDTOIn>>(listeMenusDuJour));
        }

        //GET api/MenusDuJour/{i}
        [HttpGet("{id}", Name = "GetMenusDuJourById")]
        public ActionResult<MenusDuJourDTOIn> GetMenusDuJourById(int id)
        {
            MenuDuJour commandItem = _service.GetMenusDuJourById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<MenusDuJourDTOIn>(commandItem));
            }
            return NotFound();
        }

        //POST api/MenusDuJour
        [HttpPost]
        public ActionResult<MenusDuJourDTOIn> CreateMenusDuJour(MenuDuJour obj)
        {
            _service.AddMenusDuJour(obj);
            return CreatedAtRoute(nameof(GetMenusDuJourById), new { Id = obj.IdMenuDuJour }, obj);
        }

        //POST api/MenusDuJour/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMenusDuJour(int id, MenusDuJourDTOIn obj)
        {
            MenuDuJour objFromRepo = _service.GetMenusDuJourById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateMenusDuJour(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/MenusDuJour/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialMenusDuJourUpdate(int id, JsonPatchDocument<MenuDuJour> patchDoc)
        {
            MenuDuJour objFromRepo = _service.GetMenusDuJourById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            MenuDuJour objToPatch = _mapper.Map<MenuDuJour>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateMenusDuJour(objFromRepo);
            return NoContent();
        }

        //DELETE api/MenusDuJour/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMenusDuJour(int id)
        {
            MenuDuJour obj = _service.GetMenusDuJourById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteMenusDuJour(obj);
            return NoContent();
        }


    }
}
