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
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            menufond.Background = new SolidColorBrush (Themes.CouleurFondMenu);
            titremenu.Foreground = new SolidColorBrush(Themes.CouleurTitreMenu);
            textemenu.Foreground = new SolidColorBrush(Themes.CouleurTexteMenu);
            facile.Foreground = new SolidColorBrush(Themes.CouleurFacileMenu);
            facile.BorderBrush = new SolidColorBrush(Themes.CouleurFacileMenu);
            moyen.Foreground = new SolidColorBrush(Themes.CouleurMoyenMenu);
            moyen.BorderBrush = new SolidColorBrush(Themes.CouleurMoyenMenu);
            difficile.Foreground = new SolidColorBrush(Themes.CouleurDifficileMenu);
            difficile.BorderBrush = new SolidColorBrush(Themes.CouleurDifficileMenu);
            jouer.Foreground = new SolidColorBrush(Themes.CouleurJouerMenu);
            jouer.BorderBrush = new SolidColorBrush(Themes.CouleurJouerMenu);
            annuler.Foreground = new SolidColorBrush(Themes.CouleurAnnulerMenu);
            annuler.BorderBrush = new SolidColorBrush(Themes.CouleurAnnulerMenu);
            imagedroite.Fill = Themes.ImageDroite;
            imagegauche.Fill = Themes.ImageGauche;
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void jouer_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public static string difficulte = "facile";

        private void facile_Click(object sender, RoutedEventArgs e)
        {
            difficulte = "facile";
        }


        private void difficile_Click(object sender, RoutedEventArgs e)
        {
            difficulte = "difficile";
        }

        private void moyen_Click(object sender, RoutedEventArgs e)
        {
            difficulte = "moyen";
        }
    }
}
