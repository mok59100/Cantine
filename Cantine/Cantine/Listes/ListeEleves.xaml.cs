using Cantine.Controllers;
using Cantine.Data;
using Cantine.Data.Dtos;
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
    /// Logique d'interaction pour ListeEleves.xaml
    /// </summary>
    public partial class ListeEleves : Window
    {
        CantineContext _context;
        ElevesController _elevesController;


        public ListeEleves()
        {
            InitializeComponent();


            _context = new CantineContext();
            _elevesController = new ElevesController(_context);
             DgListeEleves.ItemsSource = _elevesController.GetAllEleves();
        }



        private void ListeEleves_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnListeEleves_Click(object sender, RoutedEventArgs e)
        {
            ElevesDTOIn Eleve = (ElevesDTOIn)DgListeEleves.SelectedItem;
            string nom = (string)((Button)sender).Content;
            if (Eleve == null && (nom == "Modifier" || nom == "Supprimer"))
            {
                MessageBox.Show("PAS DE SELECTION");
            }
            else
            {
                FormEleve actions = new FormEleve(nom, this, Eleve, _context);


                this.Opacity = 0.5;
                actions.ShowDialog();
                this.Opacity = 1;

            }
        }
        public void ActionEleve(ElevesDTOIn eleve, string action, int id)
        {
            // On met à jour l'article en base de données
            // en fonction de l'action
            switch (action)
            {
                case "Ajouter":
                    _elevesController.CreateEleve(eleve);
                    break;
                case "Modifier":
                    _elevesController.UpdateEleve(id, eleve);
                    break;
                case "Supprimer":
                    _elevesController.DeleteEleve(id);
                    break;
            }

        }
    }
}