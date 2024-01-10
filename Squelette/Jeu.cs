using System;
using System.Windows;

namespace Démineur;

public class Jeu
{
    public int ligne { get; }
    public int colonne { get; }

    private bool[,] _tableauDrapeaux; //on crée 3 tableaux de booléens qui feront la taille de la grille pour localiser les cases marquées, révélées et qui sont des bombes
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
    
    public void Rafraichissement() //on calibre les tableaux pour qu'ils fassent la taille de la grille et on place les bombes aléatoirement en passant des booléens à true dans le tableau des bombes
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
    
    public int CalculeNombre(int tuilex, int tuiley) //on check les 8 coordonnées autour de la tuile donnée et si il y a une bombe on incrémente le compteur
    {
        int cpt = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }
                
                int x = tuilex + i;
                int y = tuiley + j;
                
                
                if (x >= 0 && x < ligne && y >= 0 && y < colonne)
                {
                    if (_tableauMines[x, y])
                    {
                        cpt++;
                    }
                }
            }
        }

        return cpt;
    }
    public bool EstUneBombe(int x, int y) //si le booléen aux coordonnées x y dans le tableau de mines est à true alors il y a une bombe
    {
        return _tableauMines[x, y];
    }

    public void Drapeau(int x, int y) //on inverse la valeur du booléen (true ou false) vu qu'on peut mettre un drapeau ou l'enlever
    {
        _tableauDrapeaux[x, y] = !_tableauDrapeaux[x, y];
    }

    public bool EstRevelee(int x, int y) //même principe que pour estunebombe
    {
        return _tableauRevelees[x, y];
    }

    public void Revele(int x, int y) //même principe que pour drapeau sauf qu'on ne peut que révéler une case et pas la re masquer
    {
        _tableauRevelees[x, y] = true;
    }

    public bool RecupDrapeau(int x, int y) //meme principe que estunebombe
    {
        return _tableauDrapeaux[x, y];
    }
}