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

namespace QuizPOG
{
    /// <summary>
    /// Logika interakcji dla klasy QuizFormWindow.xaml
    /// </summary>
    public partial class QuizFormWindow : Window
    {
        public QuizFormWindow()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
