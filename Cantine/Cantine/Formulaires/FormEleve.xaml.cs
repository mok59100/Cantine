using Cantine.Controllers;
using Cantine.Data;
using Cantine.Data.Dtos;
using Cantine.Listes;
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

namespace Cantine.Formulaires
{
    /// <summary>
    /// Logique d'interaction pour FormEleve.xaml
    /// </summary>
    public partial class FormEleve : Window
    {
        ListeEleves Window; // fenêtre d'appel
        ElevesDTOIn Eleve;
        ElevesController EleveController;
        string Action;
        int Id;
        public FormEleve(string action, ListeEleves Window, ElevesDTOIn Eleve, CantineContext _context)
        {
            InitializeComponent();
            this.Eleve = Eleve;
            this.Window = Window;
            // on récupère l'id de l'article, null si pas d'article

            // On récupère le type d'action Ajouter, Modifier, Supprimer à partir de l'information du bouton cliqué
            this.Action = action;

            EleveController = new ElevesController(_context);

            InitPage();
        }
        private void InitPage()
        {
            labTitreFormulaire.Text = this.Action + " un eleve";
            btn_Valider.Click += (s, e) => ActionEleve();
            btn_Valider.Content = this.Action;
            switch(this.Action)
            {
                case "Ajouter":
                    break;

                case "Modifier":

                    txbNom.Text = Eleve.Nom;
                    txbPrenom.Text = Eleve.Prenom;
                    txbClasse.Text = Eleve.Classe;
                    DateTime txbDateNaissance = Eleve.DateNaissance;
                    txbAdresse.Text = Eleve.Adresse;
                    txbMail.Text = Eleve.Mail;
                    break;

                case "Supprimer":

                    txbNom.Text = Eleve.Nom;
                    txbNom.IsEnabled = false;

                    txbPrenom.Text = Eleve.Prenom;
                    txbPrenom.IsEnabled = false;

                    txbClasse.Text = Eleve.Classe;
                    txbClasse.IsEnabled = false;

                    break;









            }

        }

        private void ActionEleve()
        {
            ElevesDTOIn eleve = new ElevesDTOIn
            {

                Nom = txbNom.Text,
                Prenom = txbPrenom.Text,
                Classe = txbClasse.Text,
                DateNaissance = (DateTime)txbDateNaissance.SelectedDate,
                Adresse = txbAdresse.Text,
                Mail = txbMail.Text

            };
            this.Window.ActionEleve(eleve, this.Action, Id);
            Retour();
        }
        public void Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void Retour()
        {
            this.Close();
        }
    }  
}
