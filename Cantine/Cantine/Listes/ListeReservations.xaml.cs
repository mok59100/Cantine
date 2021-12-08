using Cantine.Controllers;
using Cantine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cantine.Listes
{
    /// <summary>
    /// Logique d'interaction pour ListeReservations.xaml
    /// </summary>
    public partial class ListeReservations : Window
    {
        CantineContext _context;
        ReservationsController _reservationsController;

        public ListeReservations()
        {
            InitializeComponent();
            _context = new CantineContext();
            _reservationsController = new ReservationsController(_context);

        }
    }
}
