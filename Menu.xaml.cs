﻿using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }
        
        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void jouer_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string difficulte;

        private void facile_Click(object sender, RoutedEventArgs e)
        {
            difficulte = "facile";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            difficulte = "moyen";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            difficulte = "difficile";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            difficulte = "personnalisé";
        }
    }
}
