using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingLibrary.hjb.file;

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
        private DateTime lastSampleTime;

        public DateTime LastSampleTime
        {
            get { return lastSampleTime; }
            set
            {
                lastSampleTime = value;
                this.RaisePropertyChanged("LastSampleTime");
            }
        }
        private DateTime nextSampleTime;

        public DateTime NextSampleTime
        {
            get { return nextSampleTime; }
            set
            {
                nextSampleTime = value;
                this.RaisePropertyChanged("NextSampleTime");
            }
        }
        private TimeSpan spanSampleTime;

        public TimeSpan SpanSampleTime
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
        private string sampleWindowPasswordPageVisibility;
        private bool quitSampleWindow;

        public bool QuitSampleWindow
        {
            get { return quitSampleWindow; }
            set
            {
                quitSampleWindow = value;
                this.RaisePropertyChanged("QuitSampleWindow");
            }
        }

        public string SampleWindowPasswordPageVisibility
        {
            get { return sampleWindowPasswordPageVisibility; }
            set
            {
                sampleWindowPasswordPageVisibility = value;
                this.RaisePropertyChanged("SampleWindowPasswordPageVisibility");
            }
        }
        private string sampleWindowPassword;

        public string SampleWindowPassword
        {
            get { return sampleWindowPassword; }
            set
            {
                sampleWindowPassword = value;
                this.RaisePropertyChanged("SampleWindowPassword");
            }
        }
        private ObservableCollection<SampleNgItemViewModel> nGItems;

        public ObservableCollection<SampleNgItemViewModel> NGItems
        {
            get { return nGItems; }
            set
            {
                nGItems = value;
                this.RaisePropertyChanged("NGItems");
            }
        }
        private bool isSampleCheck;

        public bool IsSampleCheck
        {
            get { return isSampleCheck; }
            set
            {
                isSampleCheck = value;
                this.RaisePropertyChanged("IsSampleCheck");
            }
        }
        private int nGItemCount;

        public int NGItemCount
        {
            get { return nGItemCount; }
            set
            {
                nGItemCount = value;
                this.RaisePropertyChanged("NGItemCount");
            }
        }
        private string samMode;

        public string SamMode
        {
            get { return samMode; }
            set
            {
                samMode = value;
                this.RaisePropertyChanged("SamMode");
            }
        }
        private string zPMID;

        public string ZPMID
        {
            get { return zPMID; }
            set
            {
                zPMID = value;
                this.RaisePropertyChanged("ZPMID");
            }
        }
        private string fCTMID;

        public string FCTMID
        {
            get { return fCTMID; }
            set
            {
                fCTMID = value;
                this.RaisePropertyChanged("FCTMID");
            }
        }

        #endregion
        #region 方法绑定
        public DelegateCommand FuncTestCommand { get; set; }
        public DelegateCommand ManulSampleCommand { get; set; }
        public DelegateCommand SampleCommand { get; set; }
        public DelegateCommand SampleWindowPasswordConfirmCommand { get; set; }
        public DelegateCommand SampleSaveCommand { get; set; }
        #endregion
        #region 自定义变量
        string iniParameterPath = System.Environment.CurrentDirectory + "\\Parameter.ini";
        #endregion
        #region 构造函数
        public MainWindowViewModel()
        {
            Init();
            this.FuncTestCommand = new DelegateCommand(new Action(this.FuncTestCommandExecute));
            this.ManulSampleCommand = new DelegateCommand(new Action(this.ManulSampleCommandExecute));
            this.SampleCommand = new DelegateCommand(new Action(this.SampleCommandExecute));
            this.SampleWindowPasswordConfirmCommand = new DelegateCommand(new Action(this.SampleWindowPasswordConfirmCommandExecute));
            this.SampleSaveCommand = new DelegateCommand(new Action(this.SampleSaveCommandExecute));
        }
        #endregion
        #region 自定义函数
        void Init()
        {
            this.UIName = "D5XUI 20200307";
            this.MessageStr = "";
            LastSampleTime = Convert.ToDateTime(Inifile.INIGetStringValue(iniParameterPath, "Sample", "LastSample", "2020/1/1 00:00:00"));
            this.NGItems = new ObservableCollection<SampleNgItemViewModel>();
            for (int i = 0; i < 10; i++)
            {
                this.NGItems.Add(new SampleNgItemViewModel
                {
                    Id = i + 1,
                    NgItem = Inifile.INIGetStringValue(iniParameterPath, "Sample", "NGItem" + (i + 1).ToString(), "OK"),
                    NGItemClassify = Inifile.INIGetStringValue(iniParameterPath, "Sample", "NGItemClassify" + (i + 1).ToString(), "ZP")
                });
            }
            IsSampleCheck = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "IsSampleCheck", "True"));
            NGItemCount = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "NGItemCount", "9"));
            SamMode = Inifile.INIGetStringValue(iniParameterPath, "Sample", "SamMode", "2h");
            ZPMID = Inifile.INIGetStringValue(iniParameterPath, "Sample", "ZPMID", "999");
            FCTMID = Inifile.INIGetStringValue(iniParameterPath, "Sample", "FCTMID", "999");
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

        }
        private void ManulSampleCommandExecute()
        {
            
        }
        private void SampleCommandExecute()
        {
            SampleWindowPassword = "";
            SampleWindowPasswordPageVisibility = "Visible";
            ShowSampleWindow = !ShowSampleWindow;
        }
        private void SampleWindowPasswordConfirmCommandExecute()
        {
            AddMessage(SampleWindowPassword);
            SampleWindowPasswordPageVisibility = "Collapsed";

        }
        private void SampleSaveCommandExecute()
        {
            for (int i = 0; i < 10; i++)
            {
                Inifile.INIWriteValue(iniParameterPath, "Sample", "NGItem" + (i+ 1).ToString(), this.NGItems[i].NgItem);
                Inifile.INIWriteValue(iniParameterPath, "Sample", "NGItemClassify" + (i + 1).ToString(), this.NGItems[i].NGItemClassify);
            }
            Inifile.INIWriteValue(iniParameterPath, "Sample", "IsSampleCheck", this.IsSampleCheck.ToString());
            Inifile.INIWriteValue(iniParameterPath, "Sample", "NGItemCount", this.NGItemCount.ToString());
            Inifile.INIWriteValue(iniParameterPath, "Sample", "SamMode", SamMode);
            Inifile.INIWriteValue(iniParameterPath, "Sample", "ZPMID", ZPMID);
            Inifile.INIWriteValue(iniParameterPath, "Sample", "FCTMID", FCTMID);
            QuitSampleWindow = !QuitSampleWindow;
            AddMessage("样本参数保存完成");
        }
        #endregion
    }
}
