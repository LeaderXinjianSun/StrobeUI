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
using System.IO;

namespace StrobeUI
{
    /// <summary>
    /// AlarmLoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AlarmLoginWindow : Window
    {
        public AlarmLoginWindow()
        {
            InitializeComponent();
            LoadID();
            LoadC();
        }

        public static string ID_path = System.Environment.CurrentDirectory + "\\Opertaor\\LeaderId.csv";

        public string[] ID = null;
        public void LoadID()
        {
            try
            {
                ID = File.ReadAllLines(ID_path, Encoding.GetEncoding("GB2312"));
            }
            catch (Exception ex)
            { Console.WriteLine("读取账号失败" + ex.Message); }
        }
        public void LoadC()
        {
            if (ID.Length > 0)
            {
                int count0 = ID.Length;
                for (int i = 0; i < count0; i++)
                {
                    AlarmId.Items.Add(ID[i]);
                }
            }
        }

        public static readonly DependencyProperty QuitAlarmLoginProperty =
            DependencyProperty.Register("QuitAlarmLogin", typeof(bool), typeof(AlarmLoginWindow), new PropertyMetadata(
            new PropertyChangedCallback((d, e) =>
            {
                var mAlarmLoginWindow = d as AlarmLoginWindow;
                if (mAlarmLoginWindow.HasShow)
                {
                    mAlarmLoginWindow.HasShow = false;
                    mAlarmLoginWindow.Close();
                    mAlarmLoginWindow = null;
                }
            })));
        public bool QuitAlarmLogin
        {
            get { return (bool)GetValue(QuitAlarmLoginProperty); }
            set { SetValue(QuitAlarmLoginProperty, value); }
        }

        public bool HasShow { get; set; }
        protected override void OnClosed(EventArgs e)
        {
            HasShow = false;
            base.OnClosed(e);
        }
    }
}
