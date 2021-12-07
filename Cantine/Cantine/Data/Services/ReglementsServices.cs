using Cantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Services
{
    class ReglementsServices
    {

        private readonly CantineContext _context;

        public ReglementsServices(CantineContext context)
        {
            _context = context;
        }

        public void AddReglement(Reglement obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Reglements.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteReglement(Reglement obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Reglements.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Reglement> GetAllReglements()
        {
            return _context.Reglements.ToList();
        }

        public Reglement GetReglementById(int id)
        {
            return _context.Reglements.FirstOrDefault(obj => obj.IdReglement == id);
        }

        public Reglement GetReglementByEleves(int id)
        {
            return _context.Reglements.FirstOrDefault(obj => obj.IdUtilisateurNavigation.IdUtilisateur == id);
        }

        public Reglement GetReglementByReservations(int id)
        {
            return _context.Reglements.FirstOrDefault(obj => obj.IdReservationNavigation.IdReservation == id);
        }

        public void UpdateReglement(Reglement obj)
        {
            _context.SaveChanges();
        }


    }
}
