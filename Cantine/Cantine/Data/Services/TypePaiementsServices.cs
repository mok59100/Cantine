using Cantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Services
{
    class TypePaiementsServices
    {

        private readonly CantineContext _context;

        public TypePaiementsServices(CantineContext context)
        {
            _context = context;
        }

        public void AddTypePaiements(TypePaiement obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.TypesPaiements.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteTypePaiements(TypePaiement obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.TypesPaiements.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<TypePaiement> GetAllTypePaiements()
        {
            return _context.TypesPaiements.ToList();
        }

        public TypePaiement GetTypePaiementsById(int id)
        {
            return _context.TypesPaiements.FirstOrDefault(obj => obj.IdTypePaiement == id);
        }

        public void UpdateTypePaiements(TypePaiement obj)
        {
            _context.SaveChanges();
        }


    }
}
