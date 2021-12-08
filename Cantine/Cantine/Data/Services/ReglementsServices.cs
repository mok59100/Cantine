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

        public IEnumerable<Reglement> GetReglementsByEleves(int id)
        {
            return _context.Reglements.Where(o => o.IdUtilisateur == id).ToList();
        }

        public IEnumerable<Reglement> GetReglementsByReservations(int id)
        {
            return _context.Reglements.Where(o => o.IdReservation == id).ToList();
        }

        public void UpdateReglement(Reglement obj)
        {
            _context.SaveChanges();
        }


    }
}
