using System.Windows;
using System.Windows.Controls;

namespace Démineur;

public class Tuile : Button //c'est un héritage en gros on crée la classe tuile qui hérite des méthodes de la classe button
{

    public int x { get; }
    public int y { get; }

    public Tuile(int _x, int _y, GrilleJeu grilleDeJeu)
    {
        x = _x;
        y = _y;
        Click += grilleDeJeu.Tuile_Click_Gauche; //là on assigne les méthodes aux boutons créés
        MouseRightButtonDown += grilleDeJeu.Tuile_Click_Droit;
    }
}