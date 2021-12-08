using Cantine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Data.Services
{
    class UtilisateursServices
    {

        private readonly CantineContext _context;

        public UtilisateursServices(CantineContext context)
        {
            _context = context;
        }

        public void AddUtilisateur(Utilisateur obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Utilisateurs.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteUtilisateur(Utilisateur obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Utilisateurs.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Utilisateur> GetAllUtilisateurs()
        {
            return _context.Utilisateurs.ToList();
        }

        public Utilisateur GetUtilisateurById(int id)
        {
            return _context.Utilisateurs.FirstOrDefault(obj => obj.IdUtilisateur == id);
        }

        public Utilisateur GetUtilisateurByLoginEtMotDePasse(string login, string mdp)
        {
            return _context.Utilisateurs.FirstOrDefault(obj => obj.Login == login && obj.MotDePasse==mdp);
        }

        public void UpdateUtilisateur(Utilisateur obj)
        {
            _context.SaveChanges();
        }


    }
}
