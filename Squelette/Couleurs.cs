using System.Windows.Media;

namespace Démineur;

public class Couleurs
{
    public static Color[] nbCouleur { get; } =
    {
        Colors.White, Colors.SkyBlue, Colors.Navy, Colors.MediumPurple, Colors.IndianRed, Colors.DarkSalmon,
        Colors.DarkCyan,
        Colors.Yellow, Colors.SaddleBrown
    };

    public static Color CouleurArrierePlan { get; } = Colors.AliceBlue;
}