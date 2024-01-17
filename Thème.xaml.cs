using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Démineur
{
    /// <summary>
    /// Logique d'interaction pour Thème.xaml
    /// </summary>
    public partial class Thème : Page
    {
        public Thème()
        {
            

            if (theme == "espace")
            {
                couleur = Colors.Black;
            }
        }

        public static string theme = "espace";
        public static Color couleur = new Color();

        private void far_west_Click(object sender, RoutedEventArgs e)
        {
            theme = "far west";
        }

        private void retro_Click(object sender, RoutedEventArgs e)
        {
            theme = "retro";
        }

        private void moyen_age_Click(object sender, RoutedEventArgs e)
        {
            theme = "moyen age";
        }

        private void nature_Click(object sender, RoutedEventArgs e)
        {
            theme = "nature";
        }

        private void espace_Click(object sender, RoutedEventArgs e)
        {
            theme = "espace";
        }

    }
}
