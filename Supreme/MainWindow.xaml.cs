﻿using AngleSharp;
using HtmlAgilityPack;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using Supreme.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Supreme
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    var Item = (Grid)sender;
        //    var ArtItem = Item.DataContext as ArtList;
        //    if (ArtItem.SoldOut)
        //    {
        //        ArtItem.SoldOutVisibility = Visibility.Visible;
        //    }
        //}

        //private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    var Item = (Grid)sender;
        //    var ArtItem = Item.DataContext as ArtList;
        //    if (ArtItem.SoldOut)
        //    {
        //        ArtItem.SoldOutVisibility = Visibility.Hidden;
        //    }
        //}
    }
}
