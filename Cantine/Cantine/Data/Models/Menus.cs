using System;
using System.Collections.Generic;

#nullable disable

namespace Cantine.Data.Models
{
    public partial class Menus
    {
        public Menus()
        {
            Menudujours = new HashSet<Menudujour>();
            Reservationsmenus = new HashSet<Reservationsmenu>();
        }

        public int IdMenu { get; set; }
        public string LibelleMenu { get; set; }
        public string Entree { get; set; }
        public string Plat { get; set; }
        public string Dessert { get; set; }
        public decimal Prix { get; set; }

        public virtual ICollection<Menudujour> Menudujours { get; set; }
        public virtual ICollection<Reservationsmenu> Reservationsmenus { get; set; }
    }
}
