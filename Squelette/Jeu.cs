using System;
using System.Windows;

namespace Démineur;

public class Jeu
{
    public int ligne;
    public int colonne;

    private bool[,] _tableauDrapeaux; //on crée 3 tableaux de booléens qui feront la taille de la grille pour localiser les cases marquées, révélées et qui sont des bombes
    private bool[,] _tableauMines;
    private bool[,] _tableauRevelees;
    private readonly int _nbBombe;
    public readonly Random _random = new Random();
    public bool jeuTourne;

    public Jeu(int _ligne, int _colonne, int nbBombe, GrilleJeu grille)
    {
        ligne = _ligne;
        colonne = _colonne;
        _nbBombe = nbBombe;
        Initialisation();
    }
    
    public void Initialisation() //on calibre les tableaux pour qu'ils fassent la taille de la grille et on place les bombes aléatoirement en passant des booléens à true dans le tableau des bombes
    {
        _tableauDrapeaux = new bool[ligne, colonne];
        _tableauMines = new bool[ligne, colonne];
        _tableauRevelees = new bool[ligne, colonne];
        int cpt = 0;
        while (cpt < _nbBombe)
        {
            int x = _random.Next(ligne);
            int y = _random.Next(colonne);
            while (_tableauMines[x, y])
            {
                x++;
                if (x >= ligne)
                {
                    x = 0;
                    y++;
                    if (y >= colonne)
                    {
                        y = 0;
                    }
                }
            }
            _tableauMines[x, y] = true;
            cpt++;
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
    
    public void Securite(int tuilex, int tuiley)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int x = tuilex + i;
                int y = tuiley + j;


                if (x >= 0 && x < ligne && y >= 0 && y < colonne)
                {
                    if (EstUneBombe(x, y))
                    {
                        _tableauMines[x, y] = false;
                        int minex = _random.Next(ligne);
                        int miney = _random.Next(colonne);
                        while (_tableauMines[minex,miney] || (minex > tuilex-1 && minex < tuilex+1) || (miney > tuiley-1 && miney < tuiley+1))
                        {
                            minex++;
                            if (minex >= ligne)
                            {
                                minex = 0;
                                miney++;
                                if (miney >= colonne)
                                {
                                    miney = 0;
                                }
                            }
                        }
                        _tableauMines[minex, miney] = true;
                    }
                }
            }
        }
    }

    public bool Fin()
    {
        for (int i = 0; i < ligne; i++)
        {
            for (int j = 0; j < colonne; j++)
            {
                if (!EstUneBombe(i,j) && !EstRevelee(i,j))
                {
                    return false;
                }
            }
        }
        return true;
    }
}