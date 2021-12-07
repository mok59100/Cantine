using Cantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Services
{
    class ElevesServices
    {

        private readonly cantineContext _context;

        public ElevesServices(cantineContext context)
        {
            _context = context;
        }

        public void AddEleve(Eleve obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Eleves.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteEleve(Eleve obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Eleves.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Eleve> GetAllEleves()
        {
            return _context.Eleves.ToList();
        }

        public Eleve GetEleveById(int id)
        {
            return _context.Eleves.FirstOrDefault(obj => obj.IdUtilisateur == id);
        }

        public void UpdateEleve(Eleve obj)
        {
            _context.SaveChanges();
        }


    }
}
