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
    public partial class MainWindow : Window
    {
        public static readonly string FACILE = "facile";
        public static readonly string MOYEN = "moyen";
        public static readonly string DIFFICILE = "difficile";

        GrilleJeu grilleJeu;
        
        public MainWindow()
        {
            InitializeComponent();

            Themes theme = new Themes ();
            theme.ShowDialog();

            Demineur();
            
        }

        public void Demineur()
        {
            Menu menu = new Menu();
            menu.ShowDialog();
            if (menu.DialogResult == false)
                Application.Current.Shutdown();

            Themes.musique.Volume = 0.5;
            Themes.musique.Play();

            GrilleXAML.Background = Themes.FondPage;
            if (Menu.difficulte == FACILE)
            {
                Grilledemineur.Width = 320;
                Grilledemineur.Height = 320;
                grilleJeu = new GrilleJeu(8, 8);
                Grilledemineur.Children.Add(grilleJeu); //on crée une grille de jeu dans la grille de la mainwindow
            }
            if (Menu.difficulte == MOYEN)
            {
                Grilledemineur.Width = 640;
                Grilledemineur.Height = 640;
                grilleJeu = new GrilleJeu(16, 16);
                Grilledemineur.Children.Add(grilleJeu); //on crée une grille de jeu dans la grille de la mainwindow
            }
            if (Menu.difficulte == DIFFICILE)
            {
                Grilledemineur.Width = 1280;
                Grilledemineur.Height = 640;
                grilleJeu = new GrilleJeu(16, 32);
                Grilledemineur.Children.Add(grilleJeu); //on crée une grille de jeu dans la grille de la mainwindow
            }

            grilleJeu.Background = new SolidColorBrush(Themes.CouleurFondGrille);
        }


        private void Grid_touche_pressee(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S)
            {
                grilleJeu.Triche();
            }
        }


    }
}
