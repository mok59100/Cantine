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
    class MenusController:ControllerBase
    {
        private readonly MenusServices _service;
        private readonly IMapper _mapper;

        public MenusController(MenusServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/NomController
        [HttpGet]
        public ActionResult<IEnumerable<MenusDTOIn>> GetAllNomController()
        {
            IEnumerable<Menu> listeMenus = _service.GetAllMenus();
            return Ok(_mapper.Map<IEnumerable<MenusDTOIn>>(listeMenus));
        }

        //GET api/Menus/{i}
        [HttpGet("{id}", Name = "GetMenusById")]
        public ActionResult<MenusDTOIn> GetMenusById(int id)
        {
            Menu commandItem = _service.GetMenusById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<MenusDTOIn>(commandItem));
            }
            return NotFound();
        }

        //POST api/NomController
        [HttpPost]
        public ActionResult<MenusDTOIn> CreateMenus(Menu obj)
        {
            _service.AddMenus(obj);
            return CreatedAtRoute(nameof(GetMenusById), new { Id = obj.IdMenu}, obj);
        }

        //POST api/NomController/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMenus(int id, MenusDTOIn obj)
        {
            Menu objFromRepo = _service.GetMenusById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateMenus(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/NomController/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialMenusUpdate(int id, JsonPatchDocument<Menu> patchDoc)
        {
            Menu objFromRepo = _service.GetMenusById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            Menu objToPatch = _mapper.Map<Menu>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateMenus(objFromRepo);
            return NoContent();
        }

        //DELETE api/NomController/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMenus(int id)
        {
            Menu obj = _service.GetMenusById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteMenus(obj);
            return NoContent();
        }


    }
}
