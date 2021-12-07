using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Services
{
    class MenuDuJourServices
    {


        private readonly MyDbContext _context;

        public NomServiceServices(MyDbContext context)
        {
            _context = context;
        }

        public void AddnomModel(nomModel obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.NomService.Add(obj);
            _context.SaveChanges();
        }

        public void DeletenomModel(nomModel obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.NomService.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<nomModel> GetAllNomService()
        {
            return _context.NomService.ToList();
        }

        public nomModel GetnomModelById(int id)
        {
            return _context.NomService.FirstOrDefault(obj => obj.Id == id);
        }

        public void UpdatenomModel(nomModel obj)
        {
            _context.SaveChanges();
        }


    }
}
