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
using System.Windows.Navigation;
using System.Windows.Shapes;
using _3DWall.Utils;
using _3DWall.Wall;

namespace _3DWall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///     public partial class MainWindow : Window
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Loaded += MainWindow_Loaded;
        }

        //void MainWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Loaded -= MainWindow_Loaded;

        //    try 
        //    {
        //        _bgbrush.ImageSource = new BitmapImage(new Uri(ExtendUtils.DATA_PATH + "bg.png"));
        //    }
        //    catch 
        //    {
        //        MessageBox.Show("背景文件不存在");
        //    }

        //    _mainwall.ItemClick += _mainwall_ItemClick;
        //}
        //Popwindow Picture;
        //void _mainwall_ItemClick(object sender, Wall.MianWall.ItemclickEventArg e)
        //{
        //    Picture = new Popwindow();
        //    Picture.X = 580;
        //    Picture.Y = 240;
        //    Picture.PictureSource = new BitmapImage(new Uri(ExtendUtils.DATA_PATH + e.MEDIA.Thumb));
        //    _grid.Children.Add(Picture);
        //    _rec.Visibility = Visibility.Visible;
        //    _rec.MouseLeftButtonDown+=_rec_MouseLeftButtonDown;
           
           
        //}

        //void _rec_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    _rec.Visibility = Visibility.Collapsed;
        //    _rec.MouseLeftButtonDown -= _rec_MouseLeftButtonDown;
        //    _grid.Children.Remove(Picture);
        //}
    }
}
