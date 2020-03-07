using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrobeUI.ViewModels
{
    class MainWindowViewModel : NotificationObject
    {
        #region 属性绑定
        private string uIName;
        public string UIName
        {
            get { return uIName; }
            set
            {
                uIName = value;
                this.RaisePropertyChanged("UIName");
            }
        }
        private string messageStr;

        public string MessageStr
        {
            get { return messageStr; }
            set
            {
                messageStr = value;
                this.RaisePropertyChanged("MessageStr");
            }
        }
        private string pLCStatus;

        public string PLCStatus
        {
            get { return pLCStatus; }
            set
            {
                pLCStatus = value;
                this.RaisePropertyChanged("PLCStatus");
            }
        }
        private long pLCCycle;

        public long PLCCycle
        {
            get { return pLCCycle; }
            set
            {
                pLCCycle = value;
                this.RaisePropertyChanged("PLCCycle");
            }
        }
        private string lastSampleTime;

        public string LastSampleTime
        {
            get { return lastSampleTime; }
            set
            {
                lastSampleTime = value;
                this.RaisePropertyChanged("LastSampleTime");
            }
        }
        private string nextSampleTime;

        public string NextSampleTime
        {
            get { return nextSampleTime; }
            set
            {
                nextSampleTime = value;
                this.RaisePropertyChanged("NextSampleTime");
            }
        }
        private string spanSampleTime;

        public string SpanSampleTime
        {
            get { return spanSampleTime; }
            set
            {
                spanSampleTime = value;
                this.RaisePropertyChanged("SpanSampleTime");
            }
        }
        private bool showSampleWindow;

        public bool ShowSampleWindow
        {
            get { return showSampleWindow; }
            set
            {
                showSampleWindow = value;
                this.RaisePropertyChanged("ShowSampleWindow");
            }
        }

        #endregion
        #region 方法绑定
        public DelegateCommand FuncTestCommand { get; set; }
        public DelegateCommand ManulSampleCommand { get; set; }
        public DelegateCommand SampleCommand { get; set; }
        #endregion
        #region 构造函数
        public MainWindowViewModel()
        {
            Init();
            this.FuncTestCommand = new DelegateCommand(new Action(this.FuncTestCommandExecute));
            this.ManulSampleCommand = new DelegateCommand(new Action(this.ManulSampleCommandExecute));
            this.SampleCommand = new DelegateCommand(new Action(this.SampleCommandExecute));
        }
        #endregion
        #region 自定义函数
        void Init()
        {
            this.UIName = "D5XUI 20200307";
            this.MessageStr = "";
        }
        void AddMessage(string str)
        {
            string[] s = MessageStr.Split('\n');
            if (s.Length > 1000)
            {
                MessageStr = "";
            }
            if (MessageStr != "")
            {
                MessageStr += "\n";
            }
            MessageStr += System.DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + " " + str;
        }
        #endregion
        #region 方法绑定执行函数
        private void FuncTestCommandExecute()
        {
            AddMessage("FuncButton Click!");
        }
        private void ManulSampleCommandExecute()
        {
            
        }
        private void SampleCommandExecute()
        {
            ShowSampleWindow = !ShowSampleWindow;
        }
        #endregion
    }
}
