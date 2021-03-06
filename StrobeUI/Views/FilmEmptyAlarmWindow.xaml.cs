﻿using MahApps.Metro.Controls;
using System;
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

namespace StrobeUI.Views
{
    /// <summary>
    /// FilmEmptyAlarmWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FilmEmptyAlarmWindow : MetroWindow
    {
        public FilmEmptyAlarmWindow()
        {
            InitializeComponent();
        }




        public bool QuitFilmEmptyAlarmWindow
        {
            get { return (bool)GetValue(QuitFilmEmptyAlarmWindowProperty); }
            set { SetValue(QuitFilmEmptyAlarmWindowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for QuitFilmEmptyAlarmWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty QuitFilmEmptyAlarmWindowProperty =
            DependencyProperty.Register("QuitFilmEmptyAlarmWindow", typeof(bool), typeof(FilmEmptyAlarmWindow), new PropertyMetadata(

                new PropertyChangedCallback((d, e) =>
                {
                    var mFilmEmptyAlarmWindow = d as FilmEmptyAlarmWindow;
                    if (mFilmEmptyAlarmWindow.HasShow)
                    {
                        mFilmEmptyAlarmWindow.HasShow = false;
                        mFilmEmptyAlarmWindow.Close();
                        mFilmEmptyAlarmWindow = null;
                    }
                })
                ));




        public bool HasShow { get; set; }
        protected override void OnClosed(EventArgs e)
        {
            HasShow = false;
            base.OnClosed(e);
        }
    }
}
