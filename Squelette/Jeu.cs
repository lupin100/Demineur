using System;
using System.Windows;

namespace Démineur;

public class Jeu
{
    public int ligne { get; }
    public int colonne { get; }

    private bool[,] _tableauDrapeaux;
    private bool[,] _tableauMines;
    private bool[,] _tableauRevelees;
    private readonly int _nbBombe;
    private readonly Random _random = new Random();

    public bool jeuTourne { get; private set; }

    public Jeu(int _ligne, int _colonne, int nbBombe, GrilleJeu grille)
    {
        ligne = _ligne;
        colonne = _colonne;
        _nbBombe = nbBombe;
        Rafraichissement();
    }
    
    public void Rafraichissement()
    {
        _tableauDrapeaux = new bool[ligne, colonne];
        _tableauMines = new bool[ligne, colonne];
        _tableauRevelees = new bool[ligne, colonne];
        int cpt = 0;
        while (cpt < _nbBombe)
        {
            int r = _random.Next(ligne);
            int c = _random.Next(colonne);
            if (!_tableauMines[r, c])
            {            
                    _tableauMines[r, c] = true;
                    cpt++;
            }
        }

        jeuTourne = true;
    }
    
    public int CalculeNombre(int x, int y)
    {
        int res = 0;
        for (int i = -1; i <= 1; i++)
        {
            if (x + i < 0 || y + i >= ligne)
            {
                continue;
            }

            for (int j = -1; j <= 1; j++)
            {
                if (y + j < 0 || y + j >= colonne)
                {
                    continue;
                }

                if (_tableauMines[x + i, y + j])
                {
                    res++;
                }
            }
        }

        return res;
    }
    public bool EstUneBombe(int x, int y)
    {
        return _tableauMines[x, y];
    }

    public void Drapeau(int x, int y)
    {
        _tableauDrapeaux[x, y] = !_tableauDrapeaux[x, y];
    }

    public bool EstRevelee(int x, int y)
    {
        return _tableauRevelees[x, y];
    }

    public void Revele(int x, int y)
    {
        _tableauRevelees[x, y] = true;
    }

    public bool RecupDrapeau(int x, int y)
    {
        return _tableauDrapeaux[x, y];
    }
}