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

        private readonly cantineContext _context;

        public ReglementsServices(cantineContext context)
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

        public void UpdateReglement(Reglement obj)
        {
            _context.SaveChanges();
        }


    }
}
