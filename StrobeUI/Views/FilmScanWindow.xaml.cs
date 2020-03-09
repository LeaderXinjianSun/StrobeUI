using MahApps.Metro.Controls;
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
    /// FilmScanWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FilmScanWindow : MetroWindow
    {
        public FilmScanWindow()
        {
            InitializeComponent();
        }


        public bool QuitFilmScanWindow
        {
            get { return (bool)GetValue(QuitFilmScanWindowProperty); }
            set { SetValue(QuitFilmScanWindowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for QuitFilmScanWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty QuitFilmScanWindowProperty =
            DependencyProperty.Register("QuitFilmScanWindow", typeof(bool), typeof(FilmScanWindow), new PropertyMetadata(

                new PropertyChangedCallback((d, e) =>
                {
                    var mFilmScanWindow = d as FilmScanWindow;
                    if (mFilmScanWindow.HasShow)
                    {
                        mFilmScanWindow.HasShow = false;
                        mFilmScanWindow.Close();
                        mFilmScanWindow = null;
                    }
                })));

        public bool HasShow { get; set; }
        protected override void OnClosed(EventArgs e)
        {
            HasShow = false;
            base.OnClosed(e);
        }
    }
}
