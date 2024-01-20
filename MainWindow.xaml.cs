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
        GrilleJeu grilleJeu;
        
        public MainWindow()
        {
            InitializeComponent();

            
           

            Themes theme = new Themes ();
            theme.ShowDialog();

            Themes.musique.Volume = 0.5;
            Themes.musique.Play();

            Menu menu = new Menu();
            menu.ShowDialog();
            if (menu.DialogResult == false)
                Application.Current.Shutdown();
            GrilleXAML.Background = Themes.FondPage;
            if (Menu.difficulte == "facile")
            {
                Grilledemineur.Width = 320;
                Grilledemineur.Height = 320;
                grilleJeu = new GrilleJeu(8, 8);
                Grilledemineur.Children.Add(grilleJeu); //on crée une grille de jeu dans la grille de la mainwindow
            }
            if (Menu.difficulte == "moyen")
            {
                Grilledemineur.Width = 640;
                Grilledemineur.Height = 640;
                grilleJeu = new GrilleJeu(16, 16);
                Grilledemineur.Children.Add(grilleJeu); //on crée une grille de jeu dans la grille de la mainwindow
            }
            if (Menu.difficulte == "difficile")
            {
                Grilledemineur.Width = 1280;
                Grilledemineur.Height = 640;
                grilleJeu = new GrilleJeu(16, 32);
                Grilledemineur.Children.Add(grilleJeu); //on crée une grille de jeu dans la grille de la mainwindow
            }
            
            grilleJeu.Background = new SolidColorBrush(Themes.CouleurFondGrille);
        }


        public static void Fin()
        {
            EcranFin ecranFin = new EcranFin();
            ecranFin.ShowDialog();
            if (ecranFin.DialogResult == false)
            {
                Application.Current.Shutdown();
            }
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
