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

        private readonly cantineContext _context;

        public ReservationsServices(cantineContext context)
        {
            _context = context;
        }

        public void AddReservations(Reservations obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Reservations.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteReservations(Reservations obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Reservations.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Reservations> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public Reservations GetReservationsById(int id)
        {
            return _context.Reservations.FirstOrDefault(obj => obj.IdReservation == id);
        }

        public void UpdateReservations(Reservations obj)
        {
            _context.SaveChanges();
        }


    }
}
