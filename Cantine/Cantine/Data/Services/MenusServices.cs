using Cantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Services
{
    class MenusServices
    {
        private readonly cantineContext _context;

        public MenusServices(cantineContext context)
        {
            _context = context;
        }

        public void AddMenus(Menus obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Menus.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteMenus(Menus obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Menus.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Menus> GetAllMenus()
        {
            return _context.Menus.ToList();
        }

        public Menus GetMenusById(int id)
        {
            return _context.Menus.FirstOrDefault(obj => obj.IdMenu == id);
        }

        public void UpdateMenus(Menus obj)
        {
            _context.SaveChanges();
        }


    }
}
