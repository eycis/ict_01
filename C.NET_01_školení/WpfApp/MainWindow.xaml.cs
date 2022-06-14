﻿using Data;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoadFiles_Click(object sender, RoutedEventArgs e)
        {
            txtInfo.Text = "";

            var files = Directory.EnumerateFiles(@"C:\Users\marie\source\repos\NewRepo\C.NET_01_školení\BIG");
            foreach (var file in files)
            {
                var result = FreqAnalysis.FreqAnalysisFromFile(file);
                txtInfo.Text += result.Source;
            }
        }
    }
}
