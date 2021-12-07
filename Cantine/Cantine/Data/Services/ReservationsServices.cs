using Cantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Services
{
    class ReservationsServices
    {

        private readonly CantineContext _context;

        public ReservationsServices(CantineContext context)
        {
            _context = context;
        }

        public void AddReservations(Reservation obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Reservations.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteReservations(Reservation obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Reservations.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public Reservation GetReservationsById(int id)
        {
            return _context.Reservations.FirstOrDefault(obj => obj.IdReservation == id);
        }

        public IEnumerable<Reservations> GetReservationsByEleves(int idEleve)
        {

            return _context.Reservations.ToList(o => o.IdEleve==idEleve);
        }

        public void UpdateReservations(Reservations obj)
        {
            _context.SaveChanges();
        }


    }
}
