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
    /// Logique d'interaction pour EcranFin.xaml
    /// </summary>
    public partial class EcranFin : Window
    {
        public EcranFin()
        {
            InitializeComponent();
            if (GrilleJeu.gagner == false)
            {
                titrefin.Content = "Perdu";
                textefin.Content = Themes.TexteDefaite;
                imagefin.Fill = Themes.ImageDefaite;
            }
            else
            {
                titrefin.Content = "Gagné";
                textefin.Content = Themes.TexteVictoire;
                imagefin.Fill = Themes.ImageVictoire;
            }

            titrefin.Foreground = new SolidColorBrush(Themes.CouleurTitreFin);
            fondfin.Background = new SolidColorBrush(Themes.CouleurFondFin);
            textefin.Foreground = new SolidColorBrush(Themes.CouleurTexteFin);
            termine.BorderBrush = new SolidColorBrush(Themes.CouleurTermine);
            termine.Foreground = new SolidColorBrush(Themes.CouleurTermine);
            recommencer.BorderBrush = new SolidColorBrush(Themes.CouleurRecommencer);
            recommencer.Foreground = new SolidColorBrush(Themes.CouleurRecommencer);

            
        }

        private void termine_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void recommencer_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
