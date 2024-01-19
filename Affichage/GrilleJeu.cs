using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Démineur;

public class GrilleJeu : Grid
{
    private Jeu _partie;
    BitmapImage _drapeau = new BitmapImage(new Uri($"/Images/flag.png", UriKind.Relative));
    bool premier_clic = true;

    public GrilleJeu(int ligne, int colonne)
    {
        Initialisation(ligne, colonne);
    }

    private void Initialisation(int ligne, int colonne) //initialisation crée des lignes et des colonnes dans la grid et les remplit de boutons puis rafraichit leur visuel
    {
        _partie = new Jeu(ligne, colonne, ligne * colonne / 6, this);
        premier_clic = true;

        RowDefinitions.Clear();
        for (int i = 0; i < ligne; i++)
        {
            RowDefinitions.Add(new RowDefinition());
        }
        ColumnDefinitions.Clear();
        for (int i = 0; i < colonne; i++)
        {
            ColumnDefinitions.Add(new ColumnDefinition());
        }

        for (int i = 0; i < ligne; i++)
        {
            for (int j = 0; j < colonne; j++)
            {
                Tuile cell = new Tuile(i, j, this);
                SetRow(cell, i);
                SetColumn(cell, j);
                Children.Add(cell);
            }
        }

        RafraichirVisuel();
    }

    public void Clear()
    {
        Initialisation(_partie.ligne, _partie.colonne);
    }

    public void Tuile_Click_Droit(object sender, MouseButtonEventArgs e)
    {
        if (!_partie.jeuTourne) //utile pour rendre le jeu inutilisable lors que l'écran de fin apparait par exemple
        {
            e.Handled = true;
            return;
        }

        if (sender is Tuile t)
        {
            
            if (_partie.EstRevelee(t.x, t.y))
            {
                e.Handled = true;
                return;
            }

            _partie.Drapeau(t.x, t.y);
            RafraichirVisuel(t);
        }

        e.Handled = true;
    }

        

    public void Tuile_Click_Gauche(object sender, RoutedEventArgs e)
    {
        if (!_partie.jeuTourne) //utile pour rendre le jeu inutilisable lors que l'écran de fin apparait par exemple
        {
            e.Handled = true;
            return;
        } 

        if (sender is Tuile tuile)
        {
            if (premier_clic)
            {
                _partie.SafeZone(tuile.x, tuile.y);
                premier_clic = false;
            }
            if (_partie.RecupDrapeau(tuile.x, tuile.y))
            {
                return;
            }
                
            if (_partie.EstUneBombe(tuile.x, tuile.y))
            {
                Clear(); //enlever cette ligne si on veut pas un instant reset quand on perd
                e.Handled = true;
                return;
            }

            _partie.Revele(tuile.x, tuile.y);
            if (_partie.CalculeNombre(tuile.x, tuile.y) == 0)
            {
                ReveleEnChaine(tuile);

                RafraichirVisuel();
            }
            else
            {
                RafraichirVisuel(tuile);
            }

            if (_partie.Fin())
            {
                EcranFin ecranFin = new EcranFin();
                ecranFin.ShowDialog();
            }
        }

        e.Handled = true;
    }

    
    private void ReveleEnChaine(Tuile tuile) //ReveleEnChaine utilise l'algorithme du parcours en largeur (Breadth-first search en anglais)
    {
        Queue q = new Queue();
        q.Enqueue(new KeyValuePair<int, int>(tuile.x, tuile.y)); //KeyValuePair sert simplement à stocker deux int dans une seule entité (ici c'est pour les coordonnées des tuiles à checker

        while (q.Count != 0)
        {
            KeyValuePair<int, int> t = (KeyValuePair<int, int>) q.Dequeue();

            for (int i = -1; i <= 1; i++)
            {
                int r = t.Key + i;
                if (r < 0 || r >= _partie.ligne)
                {
                    continue;
                }

                for (int j = -1; j <= 1; j++)
                {
                    int c = t.Value + j;

                    if (c < 0 || c >= _partie.colonne)
                    {
                        continue;
                    }

                    if (_partie.EstRevelee(r, c)) continue;

                    _partie.Revele(r, c);
                    if (_partie.CalculeNombre(r, c) == 0)
                    {
                        q.Enqueue(new KeyValuePair<int, int>(r, c));
                    }
                }
            }
        }
    }

    public void RafraichirVisuel() //surcharge de RafraichirVisuel pour l'appliquer à toutes les tuiles de la grille
    {
        foreach (Tuile tuile in Children)
        {
            RafraichirVisuel(tuile);
        }
    }

    public int FontSize { get; } = 20;

    public void RafraichirVisuel(Tuile t)
    {
        if (_partie.RecupDrapeau(t.x, t.y)) //si c'est un drapeau la case affiche un drapeau
        {
            t.Background = Themes.drapeau;


        }
        else if (_partie.EstRevelee(t.x, t.y)) //si on a cliqué sur la tuile ou qu'elle a été révélée par ReveleEnChaine on calcule les bombes autour
        {
            int nb = _partie.CalculeNombre(t.x, t.y);
            t.Content = nb == 0 ? "" : nb.ToString();
            t.Foreground = new SolidColorBrush(Couleurs.nbCouleur[nb]);
            t.Background = new SolidColorBrush(Themes.CouleurArrierePlanGrille);
            t.FontSize = FontSize;
            t.BorderThickness = new Thickness(1);
        }
        else //si elle est inchangée la case est bleue
        {
            t.Background = new SolidColorBrush(Themes.CouleurTuileGrille);
            t.BorderThickness = new Thickness(2);
            t.Content = "";
        }
    }

    internal void Triche()
    {
        foreach (Tuile tuile in Children)
        {
            if (!_partie.EstUneBombe(tuile.x,tuile.y))
            {
                _partie.Revele(tuile.x, tuile.y);
                int nb = _partie.CalculeNombre(tuile.x, tuile.y);
                tuile.Content = nb == 0 ? "" : nb.ToString();
                tuile.Foreground = new SolidColorBrush(Couleurs.nbCouleur[nb]);
                tuile.Background = new SolidColorBrush(Themes.CouleurArrierePlanGrille);
                tuile.FontSize = FontSize;
                tuile.BorderThickness = new Thickness(1);
            }
        }
    }
}