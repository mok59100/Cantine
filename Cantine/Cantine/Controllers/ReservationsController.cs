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
    class ReservationsController:ControllerBase
    {

        private readonly ReservationsServices _service;
        private readonly IMapper _mapper;

        public ReservationsController(CantineContext _context)
        {
            _service = new ReservationsServices(_context);

            var config = new MapperConfiguration(cfg =>
            {
                
                cfg.AddProfile<ReservationsProfile>();
                cfg.AddProfile<ElevesProfile>();

            });
            _mapper = config.CreateMapper();
        }

        //GET api/Reservations
        [HttpGet]
        public IEnumerable<ReservationsDTOOutAdmin> GetAllReservations()
        {
            IEnumerable<Reservation> listeReservations = _service.GetAllReservations();
            return _mapper.Map<IEnumerable<ReservationsDTOOutAdmin>>(listeReservations);
        }

        //GET api/Reservations/{i}
        [HttpGet("{id}", Name = "GetReservationById")]
        public ReservationsDTOOutAdmin GetReservationById(int id)
        {
            Reservation commandItem = _service.GetReservationById(id);
            if (commandItem != null)
            {
                return _mapper.Map<ReservationsDTOOutAdmin>(commandItem);
            }
            return null;
        }

        public IEnumerable<ReservationsDTOOutAdmin> GetReservationsByEleves(int idUtilisateur)
        {
            IEnumerable<Reservation> listeReservations = _service.GetReservationsByEleves(idUtilisateur);
            return _mapper.Map<IEnumerable<ReservationsDTOOutAdmin>>(listeReservations);
        }

        public IEnumerable<ReservationsDTOOutAdmin> GetReservationsByDateRepas(DateTime dateRepas)
        {
            IEnumerable<Reservation> listeReservations = _service.GetReservationsByDateRepas(dateRepas);
            return _mapper.Map<IEnumerable<ReservationsDTOOutAdmin>>(listeReservations);
        }

        //POST api/Reservations
        [HttpPost]
        public void CreateReservation(ReservationsDTOIn objIn)
        {
            Reservation obj = _mapper.Map<Reservation>(objIn);
            _service.AddReservation(obj);
        }

        //POST api/Reservations/{id}
        [HttpPut("{id}")]
        public bool UpdateReservation(int id, ReservationsDTOIn obj)
        {
            Reservation objFromRepo = _service.GetReservationById(id);
            if (objFromRepo == null)
            {
                return false;
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateReservation(objFromRepo);
            return true;
        }

        //DELETE api/Reservations/{id}
        [HttpDelete("{id}")]
        public bool DeleteReservation(int id)
        {
            Reservation obj = _service.GetReservationById(id);
            if (obj == null)
            {
                return false;
            }
            _service.DeleteReservation(obj);
            return true;
        }


    }
}
