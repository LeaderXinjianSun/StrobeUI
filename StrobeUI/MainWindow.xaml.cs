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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StrobeUI.ViewModels;
using StrobeUI.Views;
using MahApps.Metro.Controls;

namespace StrobeUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            this.SetBinding(ShowSampleWindowProperty, "ShowSampleWindow");
            this.SetBinding(ShowFilmEmptyAlarmWindowProperty, "ShowFilmEmptyAlarmWindow");
            this.SetBinding(ShowAlarmLoginWindowProperty, "ShowAlarmLoginWindow");//显示报警弹出界面

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void MsgTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MsgTextBox.ScrollToEnd();
        }
        public static SampleWindow SampleWindow = null; 

        public static readonly DependencyProperty ShowSampleWindowProperty =
            DependencyProperty.Register("ShowSampleWindow", typeof(bool), typeof(MainWindow), new PropertyMetadata(
                new PropertyChangedCallback((d, e) =>
                {
                    if (SampleWindow != null)
                    {
                        if (SampleWindow.HasShow)
                            return;
                    }
                    var mMainWindow = d as MainWindow;
                    SampleWindow = new SampleWindow();// { Owner = this }.Show();
                    SampleWindow.Owner = Application.Current.MainWindow;
                    SampleWindow.DataContext = mMainWindow.DataContext;
                    SampleWindow.SetBinding(SampleWindow.QuitSampleWindowProperty, "QuitSampleWindow");
                    SampleWindow.HasShow = true;
                    SampleWindow.Show();
                })));
        public bool ShowSampleWindow
        {
            get { return (bool)GetValue(ShowSampleWindowProperty); }
            set { SetValue(ShowSampleWindowProperty, value); }
        }



        



        public bool ShowFilmEmptyAlarmWindow
        {
            get { return (bool)GetValue(ShowFilmEmptyAlarmWindowProperty); }
            set { SetValue(ShowFilmEmptyAlarmWindowProperty, value); }
        }
        public static FilmEmptyAlarmWindow FilmEmptyAlarmWindow = null;
        // Using a DependencyProperty as the backing store for ShowFilmEmptyAlarmWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowFilmEmptyAlarmWindowProperty =
            DependencyProperty.Register("ShowFilmEmptyAlarmWindow", typeof(bool), typeof(MainWindow), new PropertyMetadata(
                new PropertyChangedCallback((d, e) =>
                {
                    if (FilmEmptyAlarmWindow != null)
                    {
                        if (FilmEmptyAlarmWindow.HasShow)
                            return;
                    }
                    var mMainWindow = d as MainWindow;
                    FilmEmptyAlarmWindow = new FilmEmptyAlarmWindow();// { Owner = this }.Show();
                    FilmEmptyAlarmWindow.Owner = Application.Current.MainWindow;
                    FilmEmptyAlarmWindow.DataContext = mMainWindow.DataContext;
                    FilmEmptyAlarmWindow.SetBinding(FilmEmptyAlarmWindow.QuitFilmEmptyAlarmWindowProperty, "QuitFilmEmptyAlarmWindow");
                    FilmEmptyAlarmWindow.HasShow = true;
                    FilmEmptyAlarmWindow.Show();
                })
                ));



        public static AlarmLoginWindow AlarmLoginWindow = null;

        public static readonly DependencyProperty ShowAlarmLoginWindowProperty =
            DependencyProperty.Register("ShowAlarmLoginWindow", typeof(bool), typeof(MainWindow), new PropertyMetadata(
                new PropertyChangedCallback((d, e) =>
                {
                    if (AlarmLoginWindow != null)
                    {
                        if (AlarmLoginWindow.HasShow)
                            return;
                    }
                    var mMainWindow = d as MainWindow;
                    AlarmLoginWindow = new AlarmLoginWindow();// { Owner = this }.Show();
                    AlarmLoginWindow.Owner = Application.Current.MainWindow;
                    AlarmLoginWindow.DataContext = mMainWindow.DataContext;
                    AlarmLoginWindow.SetBinding(AlarmLoginWindow.QuitAlarmLoginProperty, "QuitAlarmLogin");
                    AlarmLoginWindow.HasShow = true;
                    AlarmLoginWindow.Show();
                })));
        public bool ShowAlarmLoginWindow
        {
            get { return (bool)GetValue(ShowAlarmLoginWindowProperty); }
            set { SetValue(ShowAlarmLoginWindowProperty, value); }
        }


    }
}
