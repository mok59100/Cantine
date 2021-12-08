using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cantine.Listes;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Cantine.Data.Models;
using Cantine.Data;
using Cantine.Controllers;

namespace Cantine.Formulaires
{
    /// <summary>
    /// Logique d'interaction pour FormMenuDuJour.xaml
    /// </summary>
    public partial class FormMenuDuJour : Window
    {
        string Nom;
        int Id;
        ListeMenusDuJour Window;
        MenuDuJour MenuDuJour;
        MenusController MenuController;
        public FormMenuDuJour(string nom, ListeMenusDuJour window, MenuDuJour menu, CantineContext _context)
        {
            InitializeComponent();
            this.Nom = nom;
            this.Id = (menu == null) ? 0 : menu.IdMenuDuJour;
            this.Window = window;
            this.MenuDuJour = menu;
            MenuController = new MenusController(_context);
            InitPage();
        }

        private void InitPage()
        {
            labTitre.Content = this.Nom + " un menu du jour";
            cbMenus.ItemsSource = MenuController.GetAllMenus();
            cbMenus.DisplayMemberPath = "LibelleMenu";
            cbMenus.SelectedValuePath = "IdMenu";
            btnValider.Click += (s, e) => ActionMenuDuJour();
            switch (this.Nom)
            {
                case "Ajouter":
                    // rien à faire
                    break;
                case "Modifier":
                    dpDateDuJour.SelectedDate = MenuDuJour.DateDuJour;
                    // Récupération des menus de la date du jour
                    //ListeMenusMenuDuJour.ItemsSource = ;
                    break;
                case "Supprimer":
                    dpDateDuJour.SelectedDate = MenuDuJour.DateDuJour;
                    dpDateDuJour.IsEnabled = false;
                    btnAjouterMenu.Visibility = Visibility.Hidden;
                    btnSupprimerMenu.Visibility = Visibility.Hidden;
                    // Récupération des menus de la date du jour
                    //ListeMenusMenuDuJour.ItemsSource = ;
                    break;
                default:
                    break;
            }
        }

        private void ActionMenuDuJour()
        {

        }
    }
}
