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

        public void AddReservation(Reservation obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Reservations.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteReservation(Reservation obj)
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

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations.FirstOrDefault(obj => obj.IdReservation == id);
        }

        public IEnumerable<Reservation> GetReservationsByEleves(int idUtilisateur)
        {
            return _context.Reservations.Where(o => o.IdUtilisateur == idUtilisateur).ToList();
        }

        public IEnumerable<Reservation> GetReservationsByDateRepas(DateTime dateRepas)
        {
            return _context.Reservations.Where(o => o.DateRepas == dateRepas).ToList();
        }

        public void UpdateReservation(Reservation obj)
        {
            _context.SaveChanges();
        }


    }
}
