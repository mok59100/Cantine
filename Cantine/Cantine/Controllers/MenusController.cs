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
    class MenusController:ControllerBase
    {
        private readonly MenusServices _service;
        private readonly IMapper _mapper;

        public MenusController(CantineContext _context)
        {
            _service = new MenusServices(_context);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MenusProfile>();                
            });
            _mapper = config.CreateMapper();
        }

        //GET api/NomController
        [HttpGet]
        public IEnumerable<MenusDTOIn> GetAllMenus()
        {
            IEnumerable<Menu> listeMenus = _service.GetAllMenus();
            return _mapper.Map<IEnumerable<MenusDTOIn>>(listeMenus);
        }

        public IEnumerable<MenusDTOOutData> GetAllMenusData()
        {
            IEnumerable<Menu> listeMenus = _service.GetAllMenus();
            return _mapper.Map<IEnumerable<MenusDTOOutData>>(listeMenus);
        }

        //GET api/Menus/{i}
        [HttpGet("{id}", Name = "GetMenusById")]
        public MenusDTOIn GetMenusById(int id)
        {
            Menu commandItem = _service.GetMenusById(id);
            if (commandItem != null)
            {
                return _mapper.Map<MenusDTOIn>(commandItem);
            }
            return null;
        }

        //POST api/NomController
        [HttpPost]
        public void CreateMenus(MenusDTOIn objIn)
        {
            Menu obj = _mapper.Map<Menu>(objIn);
            _service.AddMenus(obj);
        }

        //POST api/NomController/{id}
        [HttpPut("{id}")]
        public bool UpdateMenus(int id, MenusDTOIn obj)
        {
            Menu objFromRepo = _service.GetMenusById(id);
            if (objFromRepo == null)
            {
                return false;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateMenus(objFromRepo);
            return true;
        }


        //DELETE api/NomController/{id}
        [HttpDelete("{id}")]
        public bool DeleteMenus(int id)
        {
            Menu obj = _service.GetMenusById(id);
            if (obj == null)
            {
                return false;
            }
            _service.DeleteMenus(obj);
            return true;
        }


    }
}
