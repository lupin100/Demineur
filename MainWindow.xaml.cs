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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Menu menu = new Menu();
            menu.ShowDialog();
            if (menu.DialogResult == false)
                Application.Current.Shutdown();
            if (Menu.difficulte == "facile");
                GrilleXAML.Children.Add(new GrilleJeu(8,8)); //on crée une grille de jeu dans la grille de la mainwindow
            if (Menu.difficulte == "moyen") ;
                GrilleXAML.Children.Add(new GrilleJeu(16, 16)); //on crée une grille de jeu dans la grille de la mainwindow
            if (Menu.difficulte == "difficile") ;
                GrilleXAML.Children.Add(new GrilleJeu(8, 8)); //on crée une grille de jeu dans la grille de la mainwindow
        }
        
        
    }
}
