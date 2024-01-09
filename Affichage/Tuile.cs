using System.Windows;
using System.Windows.Controls;

namespace Démineur;

public class Tuile : Button
{

    public int x { get; }
    public int y { get; }

    public Tuile(int _x, int _y, GrilleJeu grilleDeJeu)
    {
        x = _x;
        y = _y;
        Click += grilleDeJeu.Cell_Click;
        MouseRightButtonDown += grilleDeJeu.Cell_MouseRightButtonDown;
    }
}