using Cantine.Listes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Cantine
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        
        public Accueil()
        {
            InitializeComponent();
        }

        private void Deconnexion(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RedirectionVersListe(object sender, RoutedEventArgs e)
        {
            string nom = (string)((Button)sender).Name;
            var window = new Window();
            switch (nom)
            {
                case "btn_Menus":
                    window = new ListeMenus();
                    break;
                case "btn_MenusDuJour":
                    window = new ListeMenusDuJour();
                    break;
                case "btn_Eleves":
                    //window = new ListeEleves();
                    break;
                case "btn_Utilisateurs":
                    //window = new ListeUtilisateurs();
                    break;
                case "btn_Reservations":
                    window = new ListeReservations();
                    break;
                case "btn_ReservationsMenus":
                    //window = new ListeReservationsMenus();
                    break;
                case "btn_Reglements":
                    //window = new ListeReglements();
                    break;
                case "btn_TypesPaiements":
                    //window = new ListeTypesPaiements();
                    break;
            }
            this.Visibility = Visibility.Hidden;
            window.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
