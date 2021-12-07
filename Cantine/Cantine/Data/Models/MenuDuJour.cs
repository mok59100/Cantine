using System;
using System.Collections.Generic;

#nullable disable

namespace Cantine.Data.Models
{
    public partial class MenuDuJour
    {

        public int IdMenuDuJour { get; set; }
        public int? IdMenu { get; set; }
        public DateTime DateDuJour { get; set; }

        public virtual Menu IdMenuNavigation { get; set; }
    }
}
