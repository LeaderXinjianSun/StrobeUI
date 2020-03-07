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
    /// SampleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SampleWindow : Window
    {
        public SampleWindow()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty QuitSampleWindowProperty =
                DependencyProperty.Register("QuitSampleWindow", typeof(bool), typeof(SampleWindow), new PropertyMetadata(
                new PropertyChangedCallback((d, e) =>
                {
                    var mSampleTestWindow = d as SampleWindow;
                    if (mSampleTestWindow.HasShow)
                    {
                        mSampleTestWindow.HasShow = false;
                        mSampleTestWindow.Close();
                        mSampleTestWindow = null;
                    }
                })));
        public bool QuitSampleWindow
        {
            get { return (bool)GetValue(QuitSampleWindowProperty); }
            set { SetValue(QuitSampleWindowProperty, value); }
        }
        public bool HasShow { get; set; }
        protected override void OnClosed(EventArgs e)
        {
            HasShow = false;
            base.OnClosed(e);
        }
    }
}
