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

namespace StrobeUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            this.SetBinding(ShowSampleWindowProperty, "ShowSampleWindow");
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
    }
}
