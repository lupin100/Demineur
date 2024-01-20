using System;
using System.Collections.Generic;
using System.IO.Packaging;
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

            themefond.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory+"Images/arc en ciel.jpg"));
            fondtheme.Background = themefond;

            boutonfarwest.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/theme far west.png"));
            far_west.Background = boutonfarwest;

            boutondemineur.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/theme demineur.png"));
            retro.Background = boutondemineur;

            boutonmoyenage.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/theme moyen age.png"));
            moyen_age.Background = boutonmoyenage;

            boutonnature.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/theme nature.png"));
            nature.Background = boutonnature;

            boutonespace.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/theme espace.png"));
            espace.Background = boutonespace;
        }
        public static MediaPlayer musique = new MediaPlayer();

        public static ImageBrush themefond = new ImageBrush();
        public static ImageBrush boutonfarwest = new ImageBrush();
        public static ImageBrush boutondemineur = new ImageBrush();
        public static ImageBrush boutonmoyenage = new ImageBrush();
        public static ImageBrush boutonnature = new ImageBrush();
        public static ImageBrush boutonespace = new ImageBrush();


        public static Color CouleurFondMenu = new Color();
        public static Color CouleurTitreMenu = new Color();
        public static Color CouleurTexteMenu = new Color();
        public static Color CouleurFacileMenu = new Color();
        public static Color CouleurMoyenMenu = new Color();
        public static Color CouleurDifficileMenu = new Color();
        public static Color CouleurAnnulerMenu = new Color();
        public static Color CouleurJouerMenu = new Color();
        public static ImageBrush ImageDroite = new ImageBrush();
        public static ImageBrush ImageGauche = new ImageBrush();


        public static Color CouleurArrierePlanGrille = new Color();
        public static Color CouleurTuileGrille = new Color();
        public static Color CouleurBordTuile = new Color();
        public static Color CouleurFondGrille = new Color();
        public static ImageBrush FondPage = new ImageBrush();
        public static ImageBrush drapeau = new ImageBrush();

        public static Color CouleurFondFin = new Color();
        public static Color CouleurTitreFin = new Color();
        public static Color CouleurTexteFin = new Color();
        public static Color CouleurTermine = new Color();
        public static Color CouleurRecommencer = new Color();
        public static string TexteVictoire;
        public static string TexteDefaite;
        public static ImageBrush ImageDefaite = new ImageBrush();
        public static ImageBrush ImageVictoire = new ImageBrush();

        


        //https://sebastien.warin.fr/2006/10/21/68-wpf-mediaelement/

        private void far_west_Click(object sender, RoutedEventArgs e)
        {
            musique.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Musiques/far west.mp3"));
            //Changement de couleur du menu
            CouleurFondMenu = Colors.Moccasin;
            CouleurTitreMenu = Colors.SaddleBrown;
            CouleurTexteMenu = Colors.SaddleBrown;
            CouleurFacileMenu = Colors.Green;
            CouleurMoyenMenu = Colors.Orange;
            CouleurDifficileMenu = Colors.Red;
            CouleurJouerMenu = Colors.SaddleBrown;
            CouleurAnnulerMenu = Colors.SaddleBrown;
            ImageDroite.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/chapeau.png"));
            ImageGauche.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/wanted.png"));

            //Changement de style de la grille
            CouleurArrierePlanGrille = Colors.Bisque;
            CouleurTuileGrille = Colors.Moccasin;
            CouleurBordTuile = Colors.SaddleBrown;
            CouleurFondGrille = Colors.Moccasin;
            FondPage.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/far west.jpg"));
            drapeau.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/etoile.png"));

            //changement de style du menu final
            CouleurFondFin = Colors.Moccasin;
            CouleurTitreFin = Colors.SaddleBrown;
            CouleurTexteFin = Colors.SaddleBrown;
            CouleurTermine = Colors.SaddleBrown;
            CouleurRecommencer = Colors.SaddleBrown;
            TexteDefaite = "Le desperados court \n toujours !";
            TexteVictoire = "Vous avez mis ce \n desperados en prison !";
            ImageDefaite.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/desperados.png"));
            ImageVictoire.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/prison.png"));


        }

        private void retro_Click(object sender, RoutedEventArgs e)
        {
            musique.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Musiques/retro.mp3"));

            //Changement de couleur du menu
            CouleurFondMenu = Colors.LightGray;
            CouleurTitreMenu = Colors.Black;
            CouleurTexteMenu = Colors.Black;
            CouleurFacileMenu = Colors.DarkGreen;
            CouleurMoyenMenu = Colors.DarkOrange;
            CouleurDifficileMenu = Colors.DarkRed;
            CouleurJouerMenu = Colors.Black;
            CouleurAnnulerMenu = Colors.Black;
            ImageDroite.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/drapeaudemineur.png"));
            ImageGauche.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/bomberetro.png"));

            //Changement de style de la grille
            CouleurArrierePlanGrille = Colors.Gainsboro;
            CouleurTuileGrille= Colors.LightGray;
            CouleurBordTuile = Colors.Gray;
            CouleurFondGrille= Colors.LightGray;
            drapeau.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/drapeaudemineur.png"));

            //changement de style du menu final
            CouleurFondFin = Colors.LightGray;
            CouleurTitreFin = Colors.Black;
            CouleurTexteFin = Colors.Black;
            CouleurTermine = Colors.Black;
            CouleurRecommencer = Colors.Black;
            TexteDefaite = "Les mines ont explosé \n et vous avec...";
            TexteVictoire = "Vous avez réussi à\n déminer la zone !";



        }

        private void moyen_age_Click(object sender, RoutedEventArgs e)
        {
            musique.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Musiques/moyen age.mp3"));

            //Changement de couleur du menu
            CouleurFondMenu = Colors.Sienna;
            CouleurTitreMenu = Colors.Goldenrod;
            CouleurTexteMenu = Colors.Goldenrod;
            CouleurFacileMenu = Colors.Green;
            CouleurMoyenMenu = Colors.Orange;
            CouleurDifficileMenu = Colors.Red;
            CouleurJouerMenu = Colors.Goldenrod;
            CouleurAnnulerMenu = Colors.Goldenrod;
            ImageDroite.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/dragon.png"));
            ImageGauche.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/chevalier.png"));

            //Changement de style de la grille
            CouleurArrierePlanGrille = Colors.Peru;
            CouleurTuileGrille = Colors.Sienna;
            CouleurBordTuile = Colors.Goldenrod;
            CouleurFondGrille = Colors.Sienna;
            FondPage.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/chateau.jpg"));
            drapeau.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/bouclier.png"));

            //changement de style du menu final
            CouleurFondFin = Colors.Sienna;
            CouleurTitreFin = Colors.Goldenrod;
            CouleurTexteFin = Colors.Goldenrod;
            CouleurTermine = Colors.Goldenrod;
            CouleurRecommencer = Colors.Goldenrod;
            TexteDefaite = "Le dragon vous a \n réduit en cendres";
            TexteVictoire = "Vous avez sauvé\n la princesse !";
            ImageDefaite.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/dragon menu.png"));
            ImageVictoire.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/princesse.png"));
        }

        private void nature_Click(object sender, RoutedEventArgs e)
        {
            musique.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Musiques/nature.mp3"));

            //Changement de couleur du menu
            CouleurFondMenu = Colors.SeaGreen;
            CouleurTitreMenu = Colors.SaddleBrown;
            CouleurTexteMenu = Colors.SaddleBrown;
            CouleurFacileMenu = Colors.LawnGreen;
            CouleurMoyenMenu = Colors.Orange;
            CouleurDifficileMenu = Colors.Red;
            CouleurJouerMenu = Colors.SaddleBrown;
            CouleurAnnulerMenu = Colors.SaddleBrown;
            ImageDroite.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/cerf.png"));
            ImageGauche.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/fusil.png"));

            //Changement de style de la grille
            CouleurArrierePlanGrille = Colors.MediumSeaGreen;
            CouleurTuileGrille = Colors.SeaGreen;
            CouleurBordTuile = Colors.SaddleBrown;
            CouleurFondGrille = Colors.SeaGreen;
            FondPage.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/foret.jpg"));
            drapeau.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/arbre.png"));

            //changement de style du menu final
            CouleurFondFin = Colors.SeaGreen;
            CouleurTitreFin = Colors.SaddleBrown;
            CouleurTexteFin = Colors.SaddleBrown;
            CouleurTermine = Colors.SaddleBrown;
            CouleurRecommencer = Colors.SaddleBrown;
            TexteDefaite = "Vous avez fini à\n la charcuterie";
            TexteVictoire = "Vous avez retrouvé\n votre famille !";
            ImageDefaite.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/viande.png"));
            ImageVictoire.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/famillecerf.png"));
        }

        private void espace_Click(object sender, RoutedEventArgs e)
        {
            musique.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Musiques/espace.mp3"));

            //Changement de couleur du menu
            CouleurFondMenu = Colors.Black;
            CouleurTitreMenu = Colors.Lime;
            CouleurTexteMenu = Colors.Lime;
            CouleurFacileMenu = Colors.LawnGreen;
            CouleurMoyenMenu = Colors.Orange;
            CouleurDifficileMenu = Colors.Red;
            CouleurJouerMenu = Colors.Lime;
            CouleurAnnulerMenu = Colors.Lime;
            ImageDroite.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/fusée.png"));
            ImageGauche.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/soucoupe.png"));

            //Changement de style de la grille
            CouleurArrierePlanGrille = Colors.DarkSlateGray;
            CouleurTuileGrille = Colors.Black;
            CouleurBordTuile = Colors.Lime;
            CouleurFondGrille = Colors.Black;
            FondPage.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/espace.jpg"));
            drapeau.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/satellite.png"));

            //changement de style du menu final
            CouleurFondFin = Colors.Black;
            CouleurTitreFin = Colors.Lime;
            CouleurTexteFin = Colors.Lime;
            CouleurTermine = Colors.Lime;
            CouleurRecommencer = Colors.Lime;
            TexteDefaite = "Les aliens vous\n ont capturé";
            TexteVictoire = "Vous allez rentrer\n sur Terre !";
            ImageDefaite.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/alien.png"));
            ImageVictoire.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/astronaute.png"));
        }

        private void continuer_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

    }
}
