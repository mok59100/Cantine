using Cantine.Data.Dtos;
using Cantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Services
{
    class TypesPaiementsServices
    {

        private readonly CantineContext _context;

        public TypesPaiementsServices(CantineContext context)
        {
            _context = context;
        }

        public void AddTypePaiement(TypePaiement obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.TypesPaiements.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteTypePaiement(TypePaiement obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.TypesPaiements.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<TypePaiement> GetAllTypesPaiements()
        {
            return _context.TypesPaiements.ToList();
        }

        public TypePaiement GetTypePaiementById(int idTypePaiement)
        {
            return _context.TypesPaiements.FirstOrDefault(obj => obj.IdTypePaiement == idTypePaiement);
        }

        public void UpdateTypePaiement(TypePaiement obj)
        {
            _context.SaveChanges();
        }


    }
}
