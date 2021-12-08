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
        public IEnumerable<MenusDuJourDTOOut> GetAllMenusDuJour()
        {
            IEnumerable<MenuDuJour> listeMenusDuJour = _service.GetAllMenusDuJour();
            return _mapper.Map<IEnumerable<MenusDuJourDTOOut>>(listeMenusDuJour);
        }

        public IEnumerable<MenusDuJourDTOOut> GetMenusDuJourByDateDuJour(DateTime DateDuJour)
        {
            IEnumerable<MenuDuJour> listeMenusDuJour = _service.GetMenusDuJourByDateDuJour(DateDuJour);
            return _mapper.Map<IEnumerable<MenusDuJourDTOOut>>(listeMenusDuJour);
        }

        //GET api/MenusDuJour/{i}
        [HttpGet("{id}", Name = "GetMenusDuJourById")]
        public MenusDuJourDTOOut GetMenusDuJourById(int id)
        {
            MenuDuJour commandItem = _service.GetMenuDuJourById(id);
            if (commandItem != null)
            {
                return _mapper.Map<MenusDuJourDTOOut>(commandItem);
            }
            return null;
        }

        //POST api/MenusDuJour
        [HttpPost]
        public void CreateMenusDuJour(MenuDuJour obj)
        {
            _service.AddMenuDuJour(obj);
            
        }

        //POST api/MenusDuJour/{id}
        [HttpPut("{id}")]
        public bool UpdateMenusDuJour(int id, MenusDuJourDTOIn obj)
        {
            MenuDuJour objFromRepo = _service.GetMenuDuJourById(id);
            if (objFromRepo == null)
            {
                return false;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateMenuDuJour(objFromRepo);
            return true;
        }

        //DELETE api/MenusDuJour/{id}
        [HttpDelete("{id}")]
        public bool DeleteMenusDuJour(int id)
        {
            MenuDuJour obj = _service.GetMenuDuJourById(id);
            if (obj == null)
            {
                return false;
            }
            _service.DeleteMenuDuJour(obj);
            return true;
        }


    }
}
