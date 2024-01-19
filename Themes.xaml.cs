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

namespace Démineur
{
    /// <summary>
    /// Logique d'interaction pour Themes.xaml
    /// </summary>
    public partial class Themes : Window
    {
        public Themes()
        {
            InitializeComponent();
        }
        public static Color CouleurFondMenu = new Color();
        public static Color CouleurTitreMenu = new Color();
        public static Color CouleurTexteMenu = new Color();
        public static Color CouleurFacileMenu = new Color();
        public static Color CouleurMoyenMenu = new Color();
        public static Color CouleurDifficileMenu = new Color();
        public static Color CouleurAnnulerMenu = new Color();
        public static Color CouleurJouerMenu = new Color();


        public static Color CouleurArrierePlanGrille = new Color();
        public static Color CouleurTuileGrille = new Color();
        public static ImageBrush drapeau = new ImageBrush();

        public static Color CouleurFondFin = new Color();
        public static Color CouleurTitreFin = new Color();
        public static Color CouleurTexteFin = new Color();
        public static Color CouleurTermine = new Color();
        public static Color CouleurRecommencer = new Color();





        private void far_west_Click(object sender, RoutedEventArgs e)
        {

        }

        private void retro_Click(object sender, RoutedEventArgs e)
        {
            //Changement de couleur du menu
            CouleurFondMenu = Colors.LightGray;
            CouleurTitreMenu = Colors.Black;
            CouleurTexteMenu = Colors.Black;
            CouleurFacileMenu = Colors.DarkGreen;
            CouleurMoyenMenu = Colors.DarkOrange;
            CouleurDifficileMenu = Colors.DarkRed;
            CouleurJouerMenu = Colors.Black;
            CouleurAnnulerMenu = Colors.Black;

            //Changement de style de la grille
            CouleurArrierePlanGrille = Colors.LightGray;
            CouleurTuileGrille= Colors.LightGray;
            drapeau.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/flag.png"));

            //changement de style du menu final
            CouleurFondFin = Colors.LightGray;
            CouleurTitreFin = Colors.Black;
            CouleurTexteFin = Colors.Black;
            CouleurTermine = Colors.Black;
            CouleurRecommencer = Colors.Black;


        }

        private void moyen_age_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nature_Click(object sender, RoutedEventArgs e)
        {

        }

        private void espace_Click(object sender, RoutedEventArgs e)
        {

        }

        private void continuer_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

    }
}
