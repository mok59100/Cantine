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
    /// Logique d'interaction pour ListeMenus.xaml
    /// </summary>
    public partial class ListeMenus : Window
    {
        CantineContext _context;
        MenusController _menuController;
        public ListeMenus()
        {
            InitializeComponent();
            _context = new CantineContext();
            //_menuController = new MenusController(_context);
            ListeMenu.ItemsSource = _menuController.GetAllMenus();
        }

        private void RedirectionFormulaire(object sender, RoutedEventArgs e)
        {

        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
