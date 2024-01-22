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
        public static readonly int MINIMUMLARGEUR = 8;
        public static readonly int MAXIMUMLARGEUR = 16;
        public static readonly int MINIMUMLONGUEUR = 8;
        public static readonly int MOYENLONGUEUR = 16;
        public static readonly int MAXIMUMLONGUEUR = 32;
        public static readonly int MINIMUMHAUTEURGRILLE = 320;
        public static readonly int MAXIMUMHAUTEURGRILLE = 640;
        public static readonly int MINIMUMLONGUEURGRILLE = 320;
        public static readonly int MOYENLONGUEURGRILLE = 640;
        public static readonly int MAXIMUMLONGUEURGRILLE = 1280;



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
                Grilledemineur.Width = MINIMUMLONGUEURGRILLE;
                Grilledemineur.Height = MINIMUMHAUTEURGRILLE;
                grilleJeu = new GrilleJeu(MINIMUMLARGEUR, MINIMUMLONGUEUR);
                Grilledemineur.Children.Add(grilleJeu); //on crée une grille de jeu dans la grille de la mainwindow
            }
            if (Menu.difficulte == MOYEN)
            {
                Grilledemineur.Width =MOYENLONGUEURGRILLE;
                Grilledemineur.Height = MAXIMUMHAUTEURGRILLE;
                grilleJeu = new GrilleJeu(MAXIMUMLARGEUR, MOYENLONGUEUR);
                Grilledemineur.Children.Add(grilleJeu); //on crée une grille de jeu dans la grille de la mainwindow
            }
            if (Menu.difficulte == DIFFICILE)
            {
                Grilledemineur.Width = MAXIMUMLONGUEURGRILLE;
                Grilledemineur.Height = MAXIMUMHAUTEURGRILLE;
                grilleJeu = new GrilleJeu(MAXIMUMLARGEUR, MAXIMUMLONGUEUR);
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
