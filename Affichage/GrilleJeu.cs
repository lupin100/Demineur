using System.Windows.Controls;

namespace Démineur;

public class GrilleJeu : Grid
{
        private Jeu _partie;

        public GrilleJeu(int ligne, int colonne)
        {
            Init(ligne, colonne);
        }

        private void Init(int ligne, int colonne)
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
                    var cell = new Cell(i, j, this);
                    SetRow(cell, i);
                    SetColumn(cell, j);
                    Children.Add(cell);
                }
            }

            Invalidate();
        }

        private void Clear()
        {
            Init(_partie.Row, _partie.Column);
        }

        public void Cell_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!_partie.GameRun)
            {
                e.Handled = true;
                return;
            }

            if (sender is Cell c)
            {
                if (_partie.IsVisited(c.R, c.C))
                {
                    e.Handled = true;
                    return;
                }

                _partie.NextFlag(c.R, c.C);
                Invalidate(c);
            }

            e.Handled = true;
        }

        private readonly int[] _cx = {-1, 0, 1, 0};
        private readonly int[] _cy = {0, -1, 0, 1};

        public void Cell_Click(object sender, RoutedEventArgs e)
        {
            if (!_partie.GameRun)
            {
                e.Handled = true;
                return;
            }

            if (sender is Cell cell)
            {
                if (_partie.GetFlag(cell.R, cell.C) != CellType.None)
                {
                    return;
                }

                bool b = _partie.IsBomb(cell.R, cell.C);
                if (b)
                {
                    Clear(); //TODO 새로시작 테스트용
                    e.Handled = true;
                    return;
                }

                _partie.SetVisited(cell.R, cell.C);
                if (_partie.CalcVal(cell.R, cell.C) == 0)
                {
                    Bfs(cell);

                    Invalidate();
                }
                else
                {
                    Invalidate(cell);
                }
            }

            e.Handled = true;
        }

        private void Bfs(Cell cell)
        {
            var q = new Queue();
            q.Enqueue(new KeyValuePair<int, int>(cell.R, cell.C));

            while (q.Count != 0)
            {
                var t = (KeyValuePair<int, int>) q.Dequeue();

                foreach (var i in _cx)
                {
                    int r = t.Key + i;
                    if (r < 0 || r >= _game.Row)
                    {
                        continue;
                    }

                    foreach (var j in _cy)
                    {
                        int c = t.Value + j;

                        if (c < 0 || c >= _game.Column)
                        {
                            continue;
                        }

                        if (_game.IsVisited(r, c)) continue;

                        _game.SetVisited(r, c);
                        if (_game.CalcVal(r, c) == 0)
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
                if (uiElement is Cell c) Invalidate(c);
            }
        }

        public int FontSize { get; } = 20;

        public void Invalidate(Cell c)
        {
            var type = _partie.GetFlag(c.R, c.C);
            if (type != CellType.None)
            {
                switch (type)
                {
                    case CellType.Flag:
                        c.Background = new SolidColorBrush(Colors.Orange);
                        c.Content = MakeImagePanel(Properties.Resources.flag);
                        break;
                    case CellType.Question:
                        c.Background = new SolidColorBrush(Colors.YellowGreen);
                        c.Content = MakeImagePanel(Properties.Resources.question_mark);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (_partie.IsVisited(c.R, c.C))
            {
                var val = _partie.CalcVal(c.R, c.C);
                c.Content = val == 0 ? "" : val.ToString();
                c.Foreground = new SolidColorBrush(MineColors.NumberColors[val]);
                c.Background = new SolidColorBrush(MineColors.BackgroundColor);
                c.FontSize = FontSize;
                c.BorderThickness = new Thickness(2);
            }
            else
            {
                c.Background = new SolidColorBrush(Colors.CornflowerBlue);
                c.BorderThickness = new Thickness(1);
                c.Content = "";
            }
        }

        private static StackPanel MakeImagePanel(System.Drawing.Image resource, double margin = 10)
        {
            var bitmapStream = new MemoryStream();
            resource.Save(bitmapStream, System.Drawing.Imaging.ImageFormat.Png);
            bitmapStream.Seek(0, SeekOrigin.Begin);
            var newBitmapFrame = BitmapFrame.Create(bitmapStream);
            var image = new Image {Source = newBitmapFrame};
            var stackPnl = new StackPanel {Orientation = Orientation.Horizontal, Margin = new Thickness(margin)};
            stackPnl.Children.Add(image);
            return stackPnl;
        }
}