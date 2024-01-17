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
        }

        private void Termine_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Recommencer_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
