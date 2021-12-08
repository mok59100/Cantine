using Cantine.Controllers;
using Cantine.Data;
using Cantine.Data.Dtos;
using Cantine.Data.Models;
using Cantine.Formulaires;
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
            _menuController = new MenusController(_context);
            ListeMenu.ItemsSource = _menuController.GetAllMenusData();
        }

        private void RedirectionFormulaire(object sender, RoutedEventArgs e)
        {
            MenusDTOOutData menu = (MenusDTOOutData)ListeMenu.SelectedItem;
            string nom = (string)((Button)sender).Content;
            if (menu == null && (nom == "Modifier" || nom == "Supprimer"))
            {
                MessageBox.Show("Pas de sélection");
            }
            else
            {
                FormMenu actions = new FormMenu(nom, this, menu, _context);
                this.Opacity = 0.7;
                actions.ShowDialog();
                this.Opacity = 1;
            }
        }

        public void ActionMenu(MenusDTOIn menu, string nom, int id)
        {
            switch (nom)
            {
                case "Ajouter":
                    _menuController.CreateMenus(menu);
                    break;
                case "Modifier":
                    _menuController.UpdateMenus(id, menu);
                    break;
                case "Supprimer":
                    _menuController.DeleteMenus(id);
                    break;
            }

            ActualiserTableau();
        }

        private void ActualiserTableau()
        {
            // on recharge le datagrid
            ListeMenu.ItemsSource = _menuController.GetAllMenusData();
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
