using Cantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Services
{
    class ReservationsMenusServices
    {

        private readonly CantineContext _context;

        public ReservationsMenusServices(CantineContext context)
        {
            _context = context;
        }

        public void AddReservationMenu(ReservationMenu obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.ReservationsMenus.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteReservationMenu(ReservationMenu obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.ReservationsMenus.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<ReservationMenu> GetAllReservationsMenus()
        {
            return _context.ReservationsMenus.ToList();
        }

        public ReservationMenu GetReservationMenuById(int id)
        {
            return _context.ReservationsMenus.FirstOrDefault(obj => obj.IdReservationMenu == id);
        }

        public IEnumerable<ReservationMenu> GetReservationsMenusByIdReservation(int idReservation)
        {
            return _context.ReservationsMenus.Where(o => o.IdReservation==idReservation).ToList();
        }

        public void UpdateReservationMenu(ReservationMenu obj)
        {
            _context.SaveChanges();
        }


    }
}
