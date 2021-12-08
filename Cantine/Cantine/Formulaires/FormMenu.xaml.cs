using Cantine.Data;
using Cantine.Data.Dtos;
using Cantine.Data.Models;
using Cantine.Listes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cantine.Formulaires
{
    /// <summary>
    /// Logique d'interaction pour FormMenu.xaml
    /// </summary>
    public partial class FormMenu : Window
    {
        string Nom;
        int Id;
        ListeMenus Window;
        MenusDTOOutData Menu;

        public FormMenu(string nom, ListeMenus window, MenusDTOOutData menu, CantineContext _context)
        {
            InitializeComponent();
            this.Nom = nom;
            this.Id = (menu == null) ? 0 : menu.IdMenu;
            this.Window = window;
            this.Menu = menu;
            InitPage();
        }

        private void InitPage()
        {
            lblTitre.Content = Nom + " un menu";
            btnValider.Click += (s, e) => ActionMenu();
            switch (Nom)
            {
                case "Ajouter":

                    break;
                case "Modifier":
                    //Libelle
                    txbLibelle.Text = Menu.LibelleMenu;
                    //Entree
                    txbEntree.Text = Menu.Entree;
                    //Plat
                    txbPlat.Text = Menu.Plat;
                    //Dessert
                    txbDessert.Text = Menu.Dessert;
                    //Prix
                    txbPrix.Text = Menu.Prix.ToString();

                    break;
                case "Supprimer":
                    //Libelle
                    txbLibelle.Text = Menu.LibelleMenu;
                    txbLibelle.IsEnabled = false;
                    //Entree
                    txbEntree.Text = Menu.Entree;
                    txbEntree.IsEnabled = false;
                    //Plat
                    txbPlat.Text = Menu.Plat;
                    txbPlat.IsEnabled = false;
                    //Dessert
                    txbDessert.Text = Menu.Dessert;
                    txbDessert.IsEnabled = false;
                    //Prix
                    txbPrix.Text = Menu.Prix.ToString();
                    txbPrix.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void ActionMenu()
        {
            MenusDTOIn menu = new MenusDTOIn
            {
                LibelleMenu = txbLibelle.Text,
                Dessert = txbDessert.Text,
                Entree = txbEntree.Text,
                Plat = txbPlat.Text,
                Prix = int.Parse(txbPrix.Text)
            };
            this.Window.ActionMenu(menu,this.Nom,this.Id);
            Retour();
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Retour()
        {
            this.Close();
        }
    }
}
