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
        private readonly CantineContext _context;

        public MenusServices(CantineContext context)
        {
            _context = context;
        }

        public void AddMenus(Menu obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Menus.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteMenus(Menu obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Menus.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Menu> GetAllMenus()
        {
            return _context.Menus.ToList();
        }

        public Menu GetMenusById(int id)
        {
            return _context.Menus.FirstOrDefault(obj => obj.IdMenu == id);
        }

        public void UpdateMenus(Menu obj)
        {
            _context.SaveChanges();
        }


    }
}
