using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Démineur;

public class GrilleJeu : Grid
{
    private readonly int[] _tx = {-1, 0, 1, 0};
    private readonly int[] _ty = {0, -1, 0, 1};    
    
    private Jeu _partie;
    BitmapImage _drapeau = new BitmapImage(new Uri($"/Images/flag.png", UriKind.Relative));

    public GrilleJeu(int ligne, int colonne)
    {
        Initialisation(ligne, colonne);
    }

    private void Initialisation(int ligne, int colonne)
    {
        _partie = new Jeu(ligne, colonne, ligne * colonne / 6, this);

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
                var cell = new Tuile(i, j, this);
                SetRow(cell, i);
                SetColumn(cell, j);
                Children.Add(cell);
            }
        }

        Invalidate();
    }

    private void Clear()
    {
        Initialisation(_partie.ligne, _partie.colonne);
    }

    public void Tuile_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (!_partie.jeuTourne)
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
            Invalidate(t);
        }

        e.Handled = true;
    }

        

    public void Tuile_Click(object sender, RoutedEventArgs e)
    {
        if (!_partie.jeuTourne)
        {
            e.Handled = true;
            return;
        }

        if (sender is Tuile tuile)
        {
            if (_partie.RecupDrapeau(tuile.x, tuile.y))
            {
                return;
            }
                
            if (_partie.EstUneBombe(tuile.x, tuile.y))
            {
                Clear(); //pour test nouveau départ
                e.Handled = true;
                return;
            }

            _partie.Revele(tuile.x, tuile.y);
            if (_partie.CalculeNombre(tuile.x, tuile.y) == 0)
            {
                Bfs(tuile);

                Invalidate();
            }
            else
            {
                Invalidate(tuile);
            }
        }

        e.Handled = true;
    }

    private void Bfs(Tuile tuile)
    {
        var q = new Queue();
        q.Enqueue(new KeyValuePair<int, int>(tuile.x, tuile.y));

        while (q.Count != 0)
        {
            var t = (KeyValuePair<int, int>) q.Dequeue();

            foreach (var i in _tx)
            {
                int r = t.Key + i;
                if (r < 0 || r >= _partie.ligne)
                {
                    continue;
                }

                foreach (var j in _ty)
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

    public void Invalidate()
    {
        foreach (UIElement uiElement in Children)
        {
            if (uiElement is Tuile t) Invalidate(t);
        }
    }

    public int FontSize { get; } = 20;

    public void Invalidate(Tuile t)
    {
        if (_partie.RecupDrapeau(t.x, t.y))
        {
            t.Background = new SolidColorBrush(Colors.Orange);
            //t.Content = _drapeau;
        }
        else if (_partie.EstRevelee(t.x, t.y))
        {
            int nb = _partie.CalculeNombre(t.x, t.y);
            t.Content = nb == 0 ? "" : nb.ToString();
            t.Foreground = new SolidColorBrush(Couleurs.nbCouleur[nb]);
            t.Background = new SolidColorBrush(Couleurs.CouleurArrierePlan);
            t.FontSize = FontSize;
            t.BorderThickness = new Thickness(2);
        }
        else
        {
            t.Background = new SolidColorBrush(Colors.CornflowerBlue);
            t.BorderThickness = new Thickness(1);
            t.Content = "";
        }
    }
}