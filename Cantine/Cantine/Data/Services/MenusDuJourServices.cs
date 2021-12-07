using Cantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Services
{
    public class MenusDuJourServices
    {


        private readonly CantineContext _context;

        public MenusDuJourServices( CantineContext context)
        {
            _context = context;
        }

        public void AddMenuDuJour(MenuDuJour obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.MenusDuJour.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteMenuDuJour(MenuDuJour obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.MenusDuJour.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<MenuDuJour> GetAllMenuDuJour()
        {
            return _context.MenusDuJour.ToList();
        }

        public MenuDuJour GetMenuDuJourById(int id)
        {
            return _context.MenusDuJour.FirstOrDefault(obj => obj.IdMenuDuJour == id);
        }
        public MenuDuJour GetMenuDuJourByDateDuJour(DateTime DateDuJour)
        {
            return _context.MenusDuJour.FirstOrDefault(obj => obj.DateDuJour == DateDuJour);
        }

        public void UpdateMenuDuJour(MenuDuJour obj)
        {
            _context.SaveChanges();
        }


    }
}
