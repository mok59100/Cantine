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
    class ReservationsMenusController: ControllerBase
    {

        private readonly ReservationsMenusServices _service;
        private readonly IMapper _mapper;

        public ReservationsMenusController(ReservationsMenusServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/ReservationsMenus
        [HttpGet]
        public IEnumerable<ReservationsMenusDTOOut> GetAllReservationsMenus()
        {
            IEnumerable<ReservationMenu> listeReservationsMenus = _service.GetAllReservationsMenus();
            return _mapper.Map<IEnumerable<ReservationsMenusDTOOut>>(listeReservationsMenus);
        }

        public IEnumerable<ReservationsMenusDTOOut> GetReservationsMenusByIdReservation(int idReservation)
        {
            IEnumerable<ReservationMenu> listeReservationsMenus = _service.GetReservationsMenusByIdReservation(idReservation);
            return _mapper.Map<IEnumerable<ReservationsMenusDTOOut>>(listeReservationsMenus);
        }

        //GET api/ReservationsMenus/{i}
        [HttpGet("{id}", Name = "GetReservationMenuById")]
        public ReservationsMenusDTOOut GetReservationMenuById(int id)
        {
            ReservationMenu commandItem = _service.GetReservationMenuById(id);
            if (commandItem != null)
            {
                return _mapper.Map<ReservationsMenusDTOOut>(commandItem);
            }
            return null;
        }

        

        //POST api/ReservationsMenus
        [HttpPost]
        public void CreateReservationMenu(ReservationsMenusDTOIn objIn)
        {
            ReservationMenu obj = _mapper.Map<ReservationMenu>(objIn);
            _service.AddReservationMenu(obj);
        }

        //POST api/ReservationsMenus/{id}
        [HttpPut("{id}")]
        public bool UpdateReservationMenu(int id, ReservationsMenusDTOIn obj)
        {
            ReservationMenu objFromRepo = _service.GetReservationMenuById(id);
            if (objFromRepo == null)
            {
                return false;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateReservationMenu(objFromRepo);
            return true;
        }


        //DELETE api/ReservationsMenus/{id}
        [HttpDelete("{id}")]
        public bool DeleteReservationMenu(int id)
        {
            ReservationMenu obj = _service.GetReservationMenuById(id);
            if (obj == null)
            {
                return false;
            }
            _service.DeleteReservationMenu(obj);
            return true;
        }


    }
}
