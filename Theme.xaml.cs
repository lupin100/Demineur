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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Démineur
{
    /// <summary>
    /// Logique d'interaction pour Theme.xaml
    /// </summary>
    public partial class Theme : Page
    {
        public Theme()
        {
            InitializeComponent();
        }
        public static Color CouleurArrierePlan = new Color();
        public static ImageBrush drapeau = new ImageBrush();


        private void far_west_Click(object sender, RoutedEventArgs e)
        {

        }

        private void retro_Click(object sender, RoutedEventArgs e)
        {
            CouleurArrierePlan = Colors.Gray;
            drapeau.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/flag.png"));
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
