using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingLibrary.hjb.file;
using BingLibrary.hjb.PLC;
using System.Diagnostics;
using System.IO;
using BingLibrary.Net.net;
using BingLibrary.hjb;
using StrobeUI.Models;
using OfficeOpenXml;
using System.Data;
using SXJLibrary;
using 读写器530SDK;
using Newtonsoft.Json;

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
        private string zhuanpanBarcode1;

        public string ZhuanpanBarcode1
        {
            get { return zhuanpanBarcode1; }
            set
            {
                zhuanpanBarcode1 = value;
                this.RaisePropertyChanged("ZhuanpanBarcode1");
            }
        }
        private string zhuanpanBarcode2;

        public string ZhuanpanBarcode2
        {
            get { return zhuanpanBarcode2; }
            set
            {
                zhuanpanBarcode2 = value;
                this.RaisePropertyChanged("ZhuanpanBarcode2");
            }
        }
        private string simoBarcode1;

        public string SimoBarcode1
        {
            get { return simoBarcode1; }
            set
            {
                simoBarcode1 = value;
                this.RaisePropertyChanged("SimoBarcode1");
            }
        }
        private string simoBarcode2;

        public string SimoBarcode2
        {
            get { return simoBarcode2; }
            set
            {
                simoBarcode2 = value;
                this.RaisePropertyChanged("SimoBarcode2");
            }
        }
        private string lingminduBarcode1;

        public string LingminduBarcode1
        {
            get { return lingminduBarcode1; }
            set
            {
                lingminduBarcode1 = value;
                this.RaisePropertyChanged("LingminduBarcode1");
            }
        }
        private string lingminduBarcode2;

        public string LingminduBarcode2
        {
            get { return lingminduBarcode2; }
            set
            {
                lingminduBarcode2 = value;
                this.RaisePropertyChanged("LingminduBarcode2");
            }
        }
        private string lingminduJieGuo1;

        public string LingminduJieGuo1
        {
            get { return lingminduJieGuo1; }
            set
            {
                lingminduJieGuo1 = value;
                this.RaisePropertyChanged("LingminduJieGuo1");
            }
        }
        private string lingminduJieGuo2;

        public string LingminduJieGuo2
        {
            get { return lingminduJieGuo2; }
            set
            {
                lingminduJieGuo2 = value;
                this.RaisePropertyChanged("LingminduJieGuo2");
            }
        }
        private string zhuanpanBarcode2Background;

        public string ZhuanpanBarcode2Background
        {
            get { return zhuanpanBarcode2Background; }
            set
            {
                zhuanpanBarcode2Background = value;
                this.RaisePropertyChanged("ZhuanpanBarcode2Background");
            }
        }
        private string zhuanpanBarcode1Background;

        public string ZhuanpanBarcode1Background
        {
            get { return zhuanpanBarcode1Background; }
            set
            {
                zhuanpanBarcode1Background = value;
                this.RaisePropertyChanged("ZhuanpanBarcode1Background");
            }
        }
        private string simoBarcode2Background;

        public string SimoBarcode2Background
        {
            get { return simoBarcode2Background; }
            set
            {
                simoBarcode2Background = value;
                this.RaisePropertyChanged("SimoBarcode2Background");
            }
        }
        private string simoBarcode1Background;

        public string SimoBarcode1Background
        {
            get { return simoBarcode1Background; }
            set
            {
                simoBarcode1Background = value;
                this.RaisePropertyChanged("SimoBarcode1Background");
            }
        }
        private string lingminduBarcode2Background;

        public string LingminduBarcode2Background
        {
            get { return lingminduBarcode2Background; }
            set
            {
                lingminduBarcode2Background = value;
                this.RaisePropertyChanged("LingminduBarcode2Background");
            }
        }
        private string lingminduBarcode1Background;

        public string LingminduBarcode1Background
        {
            get { return lingminduBarcode1Background; }
            set
            {
                lingminduBarcode1Background = value;
                this.RaisePropertyChanged("LingminduBarcode1Background");
            }
        }
        private string lingminduJieGuo2Background;

        public string LingminduJieGuo2Background
        {
            get { return lingminduJieGuo2Background; }
            set
            {
                lingminduJieGuo2Background = value;
                this.RaisePropertyChanged("LingminduJieGuo2Background");
            }
        }
        private string lingminduJieGuo1Background;

        public string LingminduJieGuo1Background
        {
            get { return lingminduJieGuo1Background; }
            set
            {
                lingminduJieGuo1Background = value;
                this.RaisePropertyChanged("LingminduJieGuo1Background");
            }
        }
        private string sampleGridVisibility;

        public string SampleGridVisibility
        {
            get { return sampleGridVisibility; }
            set
            {
                sampleGridVisibility = value;
                this.RaisePropertyChanged("SampleGridVisibility");
            }
        }
        private string sampleText;

        public string SampleText
        {
            get { return sampleText; }
            set
            {
                sampleText = value;
                this.RaisePropertyChanged("SampleText");
            }
        }
        private bool bigDataEditIsReadOnly;

        public bool BigDataEditIsReadOnly
        {
            get { return bigDataEditIsReadOnly; }
            set
            {
                bigDataEditIsReadOnly = value;
                this.RaisePropertyChanged("BigDataEditIsReadOnly");
            }
        }
        private string pM;

        public string PM
        {
            get { return pM; }
            set
            {
                pM = value;
                this.RaisePropertyChanged("PM");
            }
        }
        private string gROUP1;

        public string GROUP1
        {
            get { return gROUP1; }
            set
            {
                gROUP1 = value;
                this.RaisePropertyChanged("GROUP1");
            }
        }
        private string tRACK;

        public string TRACK
        {
            get { return tRACK; }
            set
            {
                tRACK = value;
                this.RaisePropertyChanged("TRACK");
            }
        }
        private string mACID;

        public string MACID
        {
            get { return mACID; }
            set
            {
                mACID = value;
                this.RaisePropertyChanged("MACID");
            }
        }
        private string lIGHT_ID;

        public string LIGHT_ID
        {
            get { return lIGHT_ID; }
            set
            {
                lIGHT_ID = value;
                this.RaisePropertyChanged("LIGHT_ID");
            }
        }
        private string bigDataPeramEdit;

        public string BigDataPeramEdit
        {
            get { return bigDataPeramEdit; }
            set
            {
                bigDataPeramEdit = value;
                this.RaisePropertyChanged("BigDataPeramEdit");
            }
        }
        private bool alarmButtonIsEnabled;

        public bool AlarmButtonIsEnabled
        {
            get { return alarmButtonIsEnabled; }
            set
            {
                alarmButtonIsEnabled = value;
                this.RaisePropertyChanged("AlarmButtonIsEnabled");
            }
        }
                                                    
       
        private bool showFilmEmptyAlarmWindow;

        public bool ShowFilmEmptyAlarmWindow
        {
            get { return showFilmEmptyAlarmWindow; }
            set
            {
                showFilmEmptyAlarmWindow = value;
                this.RaisePropertyChanged("ShowFilmEmptyAlarmWindow");
            }
        }
        private bool quitFilmEmptyAlarmWindow;

        public bool QuitFilmEmptyAlarmWindow
        {
            get { return quitFilmEmptyAlarmWindow; }
            set
            {
                quitFilmEmptyAlarmWindow = value;
                this.RaisePropertyChanged("QuitFilmEmptyAlarmWindow");
            }
        }
        private string filmEmptyAlarmString;

        public string FilmEmptyAlarmString
        {
            get { return filmEmptyAlarmString; }
            set
            {
                filmEmptyAlarmString = value;
                this.RaisePropertyChanged("FilmEmptyAlarmString");
            }
        }
        private DateTime lastCleanTime;

        public DateTime LastCleanTime
        {
            get { return lastCleanTime; }
            set
            {
                lastCleanTime = value;
                this.RaisePropertyChanged("LastCleanTime");
            }
        }
        private DateTime nextCleanTime;

        public DateTime NextCleanTime
        {
            get { return nextCleanTime; }
            set
            {
                nextCleanTime = value;
                this.RaisePropertyChanged("NextCleanTime");
            }
        }
        private string spanCleanTime;

        public string SpanCleanTime
        {
            get { return spanCleanTime; }
            set
            {
                spanCleanTime = value;
                this.RaisePropertyChanged("SpanCleanTime");
            }
        }
        private double greenLampElapse;

        public double GreenLampElapse
        {
            get { return greenLampElapse; }
            set
            {
                greenLampElapse = value;
                this.RaisePropertyChanged("GreenLampElapse");
            }
        }
        private string mACID_M;

        public string MACID_M
        {
            get { return mACID_M; }
            set
            {
                mACID_M = value;
                this.RaisePropertyChanged("MACID_M");
            }
        }
        private string wORKSTATION;

        public string WORKSTATION
        {
            get { return wORKSTATION; }
            set
            {
                wORKSTATION = value;
                this.RaisePropertyChanged("WORKSTATION");
            }
        }
        private string mNOStr;

        public string MNOStr
        {
            get { return mNOStr; }
            set
            {
                mNOStr = value;
                this.RaisePropertyChanged("MNOStr");
            }
        }

        #endregion
        #region 方法绑定
        public DelegateCommand FuncTestCommand { get; set; }
        public DelegateCommand ManulSampleCommand { get; set; }
        public DelegateCommand SampleCommand { get; set; }
        public DelegateCommand SampleWindowPasswordConfirmCommand { get; set; }
        public DelegateCommand SampleSaveCommand { get; set; }
        public DelegateCommand BigDataPeramEditCommand { get; set; }
        public DelegateCommand BigDataAlarmGetCommand { get; set; }
        public DelegateCommand CleanActionCommand { get; set; }
        #endregion
        #region 自定义变量
        string iniParameterPath = System.Environment.CurrentDirectory + "\\Parameter.ini";
        string alarmExcelPath = System.Environment.CurrentDirectory + "\\D4X报警.xlsx";
        ThingetPLC Xinjie = new ThingetPLC();
        UDPClient udp1 = new UDPClient();
        UDPClient udp2 = new UDPClient();
        bool[] M11000; bool plcstate = false;
        List<string> SampleBarcode = new List<string>();
        bool sampleTestStart = false, isInSampleMode = false, sampleTestAbort = false, sampleTestFinished = false;
         List<AlarmData> AlarmList = new List<AlarmData>();
        string LastBanci;
        DateTime SamDateBigin, SamStartDatetime;
        int LampColor = 1;
        int LampGreenElapse, LampGreenFlickerElapse, LampYellowElapse, LampYellowFlickerElapse, LampRedElapse;
        string CurrentAlarm = "";
        Stopwatch LampGreenSw = new Stopwatch();
        CReader reader = new CReader(); int CardStatus = 1;
        BingLibrary.hjb.Metro.Metro metro = new BingLibrary.hjb.Metro.Metro();
        int AlarmCount = 0; double[] HD200; bool CardLockFlag; DateTime CardLockTime;
        Param paramJson;
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
            this.BigDataPeramEditCommand = new DelegateCommand(new Action(this.BigDataPeramEditCommandExecute));
            this.BigDataAlarmGetCommand = new DelegateCommand(new Action(this.BigDataAlarmGetCommandCommandExecute));
            this.CleanActionCommand = new DelegateCommand(new Action(this.CleanActionCommandExecute));
            Run();
        }
        #endregion
        #region 自定义函数
        void Init()
        {
            try
            {
                #region 初始化页面内容
                this.UIName = "D5XUI 20200827";
                this.MessageStr = "";
                this.BigDataEditIsReadOnly = true;
                this.BigDataPeramEdit = "Edit";
                this.AlarmButtonIsEnabled = true;
                this.SampleGridVisibility = "Collapsed";
                try
                {
                    using (StreamReader reader = new StreamReader(Path.Combine(System.Environment.CurrentDirectory, "Param.json")))
                    {
                        string json = reader.ReadToEnd();
                        paramJson = JsonConvert.DeserializeObject<Param>(json);
                    }
                }
                catch (Exception ex)
                {
                    paramJson = new Param();
                    AddMessage(ex.Message);
                }
                MNOStr = paramJson.MNOStr;
                #endregion
                #region 样本
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
                //IsSampleCheck = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "IsSampleCheck", "True"));
                IsSampleCheck = true;
                NGItemCount = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "NGItemCount", "9"));
                SamMode = Inifile.INIGetStringValue(iniParameterPath, "Sample", "SamMode", "2h");
                ZPMID = Inifile.INIGetStringValue(iniParameterPath, "Sample", "ZPMID", "999");
                FCTMID = Inifile.INIGetStringValue(iniParameterPath, "Sample", "FCTMID", "999");
                #endregion
                #region 清洁
                LastCleanTime = Convert.ToDateTime(Inifile.INIGetStringValue(iniParameterPath, "Clean", "LastCleanTime", "2020/1/1 00:00:00"));
                #endregion
                #region UDP网络
                string ip;
                int localport, targetport;
                string ip_l = Inifile.INIGetStringValue(iniParameterPath, "转盘", "LocalIP", "192.168.0.1");
                ip = Inifile.INIGetStringValue(iniParameterPath, "转盘", "TargetIP", "192.168.0.1");
                localport = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "转盘", "LocalPort", "8001"));
                targetport = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "转盘", "TargetPort", "5000"));
                udp1.Connect(localport, ip_l, targetport, ip);
                ip_l = Inifile.INIGetStringValue(iniParameterPath, "灵敏度", "LocalIP", "192.168.0.1");
                ip = Inifile.INIGetStringValue(iniParameterPath, "灵敏度", "TargetIP", "192.168.0.10");
                localport = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "灵敏度", "LocalPort", "8002"));
                targetport = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "灵敏度", "TargetPort", "5000"));
                udp2.Connect(localport, ip_l, targetport, ip);
                #endregion
                #region 机台
                ZhuanpanBarcode1 = Inifile.INIGetStringValue(iniParameterPath, "Barcode", "ZhuanpanBarcode1", "null");
                ZhuanpanBarcode2 = Inifile.INIGetStringValue(iniParameterPath, "Barcode", "ZhuanpanBarcode2", "null");
                SimoBarcode1 = Inifile.INIGetStringValue(iniParameterPath, "Barcode", "SimoBarcode1", "null");
                SimoBarcode2 = Inifile.INIGetStringValue(iniParameterPath, "Barcode", "SimoBarcode2", "null");
                LingminduBarcode1 = Inifile.INIGetStringValue(iniParameterPath, "Barcode", "LingminduBarcode1", "null");
                LingminduBarcode2 = Inifile.INIGetStringValue(iniParameterPath, "Barcode", "LingminduBarcode2", "null");
                LastBanci = Inifile.INIGetStringValue(iniParameterPath, "Summary", "LastBanci", "null");
                ZPMID = Inifile.INIGetStringValue(iniParameterPath, "Sample", "ZPMID", "ATKC4-012");
                FCTMID = Inifile.INIGetStringValue(iniParameterPath, "Sample", "FCTMID", "ATKC4-012");
                PM = Inifile.INIGetStringValue(iniParameterPath, "BigData", "PM", "D53G STROBE");
                GROUP1 = Inifile.INIGetStringValue(iniParameterPath, "BigData", "GROUP1", "NA");
                TRACK = Inifile.INIGetStringValue(iniParameterPath, "BigData", "TRACK", "NA");
                MACID = Inifile.INIGetStringValue(iniParameterPath, "BigData", "MACID", "NA");
                MACID_M = Inifile.INIGetStringValue(iniParameterPath, "BigData", "MACID_M", "NA");
                WORKSTATION = Inifile.INIGetStringValue(iniParameterPath, "BigData", "WORKSTATION", "AUTO");
                LIGHT_ID = Inifile.INIGetStringValue(iniParameterPath, "BigData", "LIGHT_ID", "NA");
                LampGreenElapse = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "BigData", "LampGreenElapse", "0"));
                LampGreenFlickerElapse = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "BigData", "LampGreenFlickerElapse", "0"));
                LampYellowElapse = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "BigData", "LampYellowElapse", "0"));
                LampYellowFlickerElapse = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "BigData", "LampYellowFlickerElapse", "0"));
                LampRedElapse = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "BigData", "LampRedElapse", "0"));
                #endregion
                #region 报警文档
                try
                {
                    if (File.Exists(alarmExcelPath))
                    {
                        FileInfo existingFile = new FileInfo(alarmExcelPath);
                        using (ExcelPackage package = new ExcelPackage(existingFile))
                        {
                            // get the first worksheet in the workbook
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                            for (int i = 1; i <= worksheet.Dimension.End.Row; i++)
                            {
                                AlarmData ad = new AlarmData();
                                ad.Code = worksheet.Cells["A" + i.ToString()].Value == null ? "Null" : worksheet.Cells["A" + i.ToString()].Value.ToString();
                                ad.Content = worksheet.Cells["B" + i.ToString()].Value == null ? "Null" : worksheet.Cells["B" + i.ToString()].Value.ToString();
                                ad.Start = DateTime.Now;
                                ad.End = DateTime.Now;
                                ad.State = false;
                                AlarmList.Add(ad);
                            }
                        }
                    }
                    else
                    {
                        AddMessage("D4X报警.xlsx 文件不存在");
                    }
                }
                catch (Exception ex)
                {
                    AddMessage(ex.Message);
                }
                #endregion
                #region 更新本地时间
                SXJLibrary.Oracle oraDB = new SXJLibrary.Oracle("qddb04.eavarytech.com", "mesdb04", "ictdata", "ictdata*168");
                if (oraDB.isConnect())
                {
                    string oracleTime = oraDB.OraclDateTime();
                    AddMessage("更新数据库时间到本地" + oracleTime);
                }
                oraDB.disconnect();
                #endregion
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }

        }
        void Run()
        {
            PLCRun();
            ZPUDPRun();
            UIRun();
            BigDataRun();
        }
        async void PLCRun()
        {
            bool first = true;
            bool M11140 = false, M11141 = false, M11142 = false, M11150 = false, M11151 = false, M11152 = false, M11153 = false, M11154 = false;
            string COM = Inifile.INIGetStringValue(iniParameterPath, "PLC", "COM", "COM19");
            Random rd = new Random();
            Stopwatch sw = new Stopwatch();
            while (true)
            {
                await Task.Delay(10);
                sw.Restart();
                plcstate = await Task<bool>.Run(() => { return Xinjie.ReadSM(0); });
                PLCStatus = plcstate ? "green" : "red";
                if (plcstate)
                {
                    M11000 = await Task<bool[]>.Run(() => { return Xinjie.ReadMultiMCoil(11000); }); //读160个M
                    HD200 = await Task<double[]>.Run(() => { return Xinjie.readMultiHD(200); });
                    bool[] M100 = await Task<bool[]>.Run(() => { return Xinjie.ReadMultiMCoil(100); }); //读160个M

                    await Task.Run(() => { Xinjie.WriteW(1201, rd.Next(0, 99).ToString()); });//往D1201写一个随机数
                    if (first)
                    {
                        first = false;
                        M11140 = M11000[140];//条码移动到吸爪
                        M11141 = M11000[141];//条码移动到灵敏度
                        M11142 = M11000[142];//向灵敏度补发条码
                        M11150 = M11000[150];//清空灵敏度条码
                        M11151 = M11000[151];//灵敏度1PASS
                        M11152 = M11000[152];//灵敏度1NG
                        M11153 = M11000[153];//灵敏度2PASS
                        M11154 = M11000[154];//灵敏度2NG
                    }
                    #region 灵敏度

                    if (M11140 != M11000[140])
                    {
                        M11140 = M11000[140];
                        if (M11140)
                        {
                            AddMessage("条码从撕膜到吸爪 " + ZhuanpanBarcode1 + "," + ZhuanpanBarcode2);
                            RunLog("条码从撕膜到吸爪 " + ZhuanpanBarcode1 + "," + ZhuanpanBarcode2);
                            SimoBarcode1 = ZhuanpanBarcode1;
                            SimoBarcode1Background = ZhuanpanBarcode1Background;
                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "SimoBarcode1", SimoBarcode1);
                            ZhuanpanBarcode1 = "null";
                            ZhuanpanBarcode1Background = "White";
                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "ZhuanpanBarcode1", ZhuanpanBarcode1);
                            SimoBarcode2 = ZhuanpanBarcode2;
                            SimoBarcode2Background = ZhuanpanBarcode2Background;
                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "SimoBarcode2", SimoBarcode2);
                            ZhuanpanBarcode2 = "null";
                            ZhuanpanBarcode2Background = "White";
                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "ZhuanpanBarcode2", ZhuanpanBarcode2);
                        }
                    }
                    if (M11141 != M11000[141])
                    {
                        M11141 = M11000[141];
                        if (M11141)
                        {
                            AddMessage("条码从吸爪到灵敏度" + SimoBarcode1 + "," + SimoBarcode2);
                            RunLog("条码从吸爪到灵敏度" + SimoBarcode1 + "," + SimoBarcode2);
                            LingminduBarcode1 = SimoBarcode1;
                            LingminduBarcode1Background = SimoBarcode1Background;
                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "LingminduBarcode1", LingminduBarcode1);
                            SimoBarcode1 = "null";
                            SimoBarcode1Background = "White";
                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "SimoBarcode1", SimoBarcode1);
                            LingminduBarcode2 = SimoBarcode2;
                            LingminduBarcode2Background = SimoBarcode2Background;
                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "LingminduBarcode2", LingminduBarcode2);
                            SimoBarcode2 = "null";
                            SimoBarcode2Background = "White";
                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "SimoBarcode2", SimoBarcode2);
                            string sends = "SN1:" + LingminduBarcode1 + ",P" + ";" + "SN2:" + LingminduBarcode2 + ",P" + "\r\n";
                            await udp2.SendAsync(sends);
                            AddMessage("向灵敏度发送 " + sends);
                            RunLog("向灵敏度发送 " + sends);
                            
                        }
                    }
                    if (M11142 != M11000[142])
                    {
                        M11142 = M11000[142];
                        if (M11142)
                        {
                            LingminduBarcode1 = "Null";
                            LingminduBarcode1Background = "White";
                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "LingminduBarcode1", LingminduBarcode1);
                            LingminduBarcode2 = "Null";
                            LingminduBarcode2Background = "White";
                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "LingminduBarcode2", LingminduBarcode2);
                            string sends = "SN1:" + LingminduBarcode1 + ",P" + ";" + "SN2:" + LingminduBarcode2 + ",P" + "\r\n";
                            await udp2.SendAsync(sends);
                            AddMessage("向灵敏度补发 " + sends);
                            RunLog("向灵敏度补发 " + sends);
                        }
                    }
                    if (M11150 != M11000[150])
                    {
                        M11150 = M11000[150];
                        if (M11150)
                        {
                            AddMessage("灵敏度清空条码" + LingminduBarcode1 + "," + LingminduBarcode2);
                            RunLog("灵敏度清空条码" + LingminduBarcode1 + "," + LingminduBarcode2);
                            LingminduBarcode1 = "null";
                            LingminduBarcode1Background = "White";
                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "LingminduBarcode1", LingminduBarcode1);
                            LingminduBarcode2 = "null";
                            LingminduBarcode2Background = "White";
                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "LingminduBarcode2", LingminduBarcode2);
                        }
                    }
                    if (M11151 != M11000[151])
                    {
                        M11151 = M11000[151];
                        if (M11151)
                        {
                            LingminduJieGuo1Background = "LightGreen";
                            SaveResult(LingminduBarcode1, "OK", "1");
                        }
                        else
                        {
                            LingminduJieGuo1Background = "Gray";
                        }
                    }
                    if (M11152 != M11000[152])
                    {
                        M11152 = M11000[152];
                        if (M11152)
                        {
                            LingminduJieGuo1Background = "Red";
                            SaveResult(LingminduBarcode1, "NG", "1");
                        }
                        else
                        {
                            LingminduJieGuo1Background = "Gray";
                        }
                    }
                    if (M11153 != M11000[153])
                    {
                        M11153 = M11000[153];
                        if (M11153)
                        {
                            LingminduJieGuo2Background = "LightGreen";
                            SaveResult(LingminduBarcode2, "OK", "2");
                        }
                        else
                        {
                            LingminduJieGuo2Background = "Gray";
                        }
                    }
                    if (M11154 != M11000[154])
                    {
                        M11154 = M11000[154];
                        if (M11154)
                        {
                            LingminduJieGuo2Background = "Red";
                            SaveResult(LingminduBarcode2, "NG", "2");
                        }
                        else
                        {
                            LingminduJieGuo2Background = "Gray";
                        }
                    }
                    #endregion
                    #region 灯信号
                    if (M100[6])//闪红
                    {
                        LampColor = 5;
                    }
                    else
                    {
                        if (M100[3])//闪绿
                        {
                            LampColor = 2;
                        }
                        else
                        {
                            if (M100[4])//闪黄
                            {
                                LampColor = 4;
                            }
                            else
                            {
                                if (M100[5])//长黄
                                {
                                    LampColor = 3;
                                }
                                else
                                {
                                    LampColor = 1;//常绿
                                }
                            }
                        }




                    }

                    #endregion
                }
                else
                {
                    await Task.Delay(1000);
                    Xinjie.ModbusDisConnect();
                    Xinjie.ModbusInit(COM, 19200, System.IO.Ports.Parity.Even, 8, System.IO.Ports.StopBits.One);
                    await Task.Run(() => { Xinjie.ModbusConnect(); });
                }
                PLCCycle = sw.ElapsedMilliseconds;
            }
        }
        async void ZPUDPRun()
        {
            while (true)
            {
                string rs = await udp1.ReceiveAsync();
                #region 从转盘接收条码
                if (rs != "error")
                {
                    RunLog("从转盘接收 " + rs);
                    AddMessage("从转盘接收 " + rs);
                    if (plcstate)
                    {
                        Xinjie.SetM(11148, true);
                    }


                    //string sends = "SNOK";
                    //await udp1.SendAsync(sends);
                    //AddMessage("向转盘发送 " + sends);
                    try
                    {
                        //SN1:G5Y9301RDD0K9037V-GF,P;SN2:G5Y9301RDCNK9037A-GF,P
                        //SN1:,;SN2:G5Y930432L2L65K5M-GF,P;49
                        string[] s1 = rs.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        string[] s1_1 = s1[0].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                        if (s1_1[0] == "SN1" && s1_1.Length == 2)
                        {
                            try
                            {
                                string[] s1_1_1 = s1_1[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                if (s1_1_1.Length >= 2)
                                {
                                    ZhuanpanBarcode1 = s1_1_1[0];
                                    if (sampleTestStart)
                                    {
                                        SampleBarcode.Add(s1_1_1[0]);
                                    }
                                    Inifile.INIWriteValue(iniParameterPath, "Barcode", "ZhuanpanBarcode1", ZhuanpanBarcode1);

                                    if (s1_1_1[1] == "P")
                                    {
                                        ZhuanpanBarcode1Background = "GreenYellow";
                                    }
                                    else
                                    {
                                        ZhuanpanBarcode1Background = "Red";
                                    }
                                }
                                else
                                {
                                    ZhuanpanBarcode1 = "null";
                                    Inifile.INIWriteValue(iniParameterPath, "Barcode", "ZhuanpanBarcode1", ZhuanpanBarcode1);
                                    ZhuanpanBarcode1Background = "Gray";
                                }
                            }
                            catch (Exception ex)
                            {
                                AddMessage(ex.Message);

                            }

                        }
                        string[] s1_2 = s1[1].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                        if (s1_2[0] == "SN2" && s1_2.Length == 2)
                        {
                            try
                            {
                                string[] s1_2_1 = s1_2[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                if (s1_2_1.Length >= 2)
                                {
                                    ZhuanpanBarcode2 = s1_2_1[0];
                                    if (sampleTestStart)
                                    {
                                        SampleBarcode.Add(s1_2_1[0]);
                                    }
                                    Inifile.INIWriteValue(iniParameterPath, "Barcode", "ZhuanpanBarcode2", ZhuanpanBarcode2);


                                    if (s1_2_1[1] == "P")
                                    {
                                        ZhuanpanBarcode2Background = "GreenYellow";
                                    }
                                    else
                                    {
                                        ZhuanpanBarcode2Background = "Red";
                                    }


                                }
                                else
                                {
                                    ZhuanpanBarcode2 = "null";
                                    Inifile.INIWriteValue(iniParameterPath, "Barcode", "ZhuanpanBarcode2", ZhuanpanBarcode2);

                                    ZhuanpanBarcode2Background = "Gray";
                                }

                            }
                            catch (Exception ex)
                            {

                                AddMessage(ex.Message);
                            }


                        }
                    }
                    catch (Exception ex)
                    {

                        AddMessage(ex.Message);
                    }


                }
                #endregion        
            }
        }
        async void UIRun()
        {
            CardLockFlag = false;
            CardLockTime = System.DateTime.Now;
            int cardcount = 0;
            int filmalarmcount = 0;
            int timetick = 0;
            bool first = true;
            while (true)
            {
                await Task.Delay(100);

                #region 样本
                switch (SamMode)
                {
                    case "2h":
                        SamDateBigin = LastSampleTime.AddMinutes(90);
                        SamStartDatetime = LastSampleTime.AddHours(2);
                        break;
                    case "6h":
                        SamDateBigin = LastSampleTime.AddHours(4);
                        SamStartDatetime = LastSampleTime.AddHours(6);
                        break;
                    default:
                        break;
                }


                NextSampleTime = SamStartDatetime;
                var timeSpan = SamStartDatetime - DateTime.Now;
                String fmt = (timeSpan < TimeSpan.Zero ? "\\-dd\\.hh\\:mm\\:ss" : "hh\\:mm\\:ss");
                SpanSampleTime = timeSpan.ToString(fmt);
                if (M11000 != null && plcstate)
                {
                    isInSampleMode = M11000[110];
                    sampleTestAbort = M11000[111];
                    //sampleTestFinished = M11000[112];
                    sampleTestStart = M11000[113];
                    if (isInSampleMode && sampleTestAbort)
                    {
                        AddMessage("样本测试中断");
                        Xinjie.SetM(11110, false);
                        isInSampleMode = false;
                        //SampleBarcode.Clear();
                    }
                    SampleGridVisibility = (DateTime.Now - SamDateBigin).TotalSeconds > 0 && IsSampleCheck ? "Visible" : "Collapsed";
                    if ((DateTime.Now - SamDateBigin).TotalSeconds > 0 && IsSampleCheck)
                    {
                        if (isInSampleMode)
                        {
                            SampleText = "样本测试中";
                        }
                        else
                        {
                            if ((DateTime.Now - SamStartDatetime).TotalSeconds < 0)
                            {
                                SampleText = "请测样本";
                            }
                            else
                            {
                                SampleText = "强制样本";
                                if (!M11000[116])
                                {
                                    Xinjie.SetM(11116, true);
                                }

                            }
                        }
                    }
                    if (sampleTestFinished != M11000[112])
                    {
                        if (isInSampleMode && M11000[112])
                        {

                            bool res = CheckSampleFromDt();
                            Xinjie.SetM(11114, !res);
                            Xinjie.SetM(11110, false);
                            if (res)
                            {
                                AddMessage("样本测试成功");
                                SampleBarcode.Clear();
                                LastSampleTime = DateTime.Now;
                                Inifile.INIWriteValue(iniParameterPath, "Sample", "LastSample", LastSampleTime.ToString());
                                Xinjie.SetM(11116, false);
                            }
                            else
                            {
                                //NowSam = DateTime.Now;
                                AddMessage("样本测试失败");
                            }
                            Xinjie.SetM(11115, true);                            
                        }
                        sampleTestFinished = M11000[112];
                    }
                    
                }

                #endregion
                #region 清洁
                NextCleanTime = LastCleanTime.AddHours(2);
                timeSpan = NextCleanTime - DateTime.Now;
                fmt = (timeSpan < TimeSpan.Zero ? "\\-dd\\.hh\\:mm\\:ss" : "hh\\:mm\\:ss");
                SpanCleanTime = timeSpan.ToString(fmt);
                #endregion
                #region 换班
                if (LastBanci != GetBanci())
                {
                    LastBanci = GetBanci();
                    Inifile.INIWriteValue(iniParameterPath, "Summary", "LastBanci", LastBanci);
                    WriteMachineData();
                    LampGreenElapse = 0;
                    Inifile.INIWriteValue(iniParameterPath, "BigData", "LampGreenElapse", LampGreenElapse.ToString());
                    LampGreenFlickerElapse = 0;
                    Inifile.INIWriteValue(iniParameterPath, "BigData", "LampGreenFlickerElapse", LampGreenFlickerElapse.ToString());
                    LampYellowElapse = 0;
                    Inifile.INIWriteValue(iniParameterPath, "BigData", "LampYellowElapse", LampYellowElapse.ToString());
                    LampYellowFlickerElapse = 0;
                    Inifile.INIWriteValue(iniParameterPath, "BigData", "LampYellowFlickerElapse", LampYellowFlickerElapse.ToString());
                    LampRedElapse = 0;
                    Inifile.INIWriteValue(iniParameterPath, "BigData", "LampRedElapse", LampRedElapse.ToString());


                    //更新数据库数据

                    string result = await Task<string>.Run(() =>
                    {
                        try
                        {
                            int _result = -999;
                            Mysql mysql = new Mysql();
                            if (mysql.Connect())
                            {
                                //string stm = string.Format("UPDATE HA_F4_LIGHT SET LIGHT = '{3}',SDATE = '{4}',STIME = '{5}',ALARM = '{6}',CLASS = '{7}',TIME_1 = '0',TIME_2 = '0',TIME_3 = '0',TIME_4 = '0',TIME_5 = '0' WHERE PM = '{0}' AND LIGHT_ID = '{1}' AND MACID = '{2}'"
                                //    , PM, LIGHT_ID, MACID, LampColor, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("mmddss"), "NA", GetBanci());
                                string stm = string.Format("INSERT INTO HA_F4_LIGHT (PM,LIGHT_ID,MACID,CLASS,LIGHT,SDATE,STIME,ALARM,WORKSTATION,TIME_1,TIME_2,TIME_3,TIME_4,TIME_5) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','0','0','0','0','0')"
                                    , PM, LIGHT_ID, MACID, GetBanci(), LampColor.ToString(), DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("mmddss"), "NA", WORKSTATION);
                                _result = mysql.executeQuery(stm);
                                stm = string.Format("INSERT INTO HA_F4_DATA_FPY (PM,MACID,CLASS,WORKSTATION,INPUT,OUTPUT,FAIL,FPY) VALUES ('{0}','{1}','{2}','{3}','0','0','0','0')"
                                    , PM, MACID, GetBanci(), WORKSTATION);
                                _result = mysql.executeQuery(stm);
                            }
                            mysql.DisConnect();
                            return _result.ToString();
                        }
                        catch (Exception ex)
                        {
                            return ex.Message;
                        }
                    });

                    QuitFilmEmptyAlarmWindow = !QuitFilmEmptyAlarmWindow;
                    LastCleanTime = DateTime.Now;
                    Inifile.INIWriteValue(iniParameterPath, "Clean", "LastCleanTime", LastCleanTime.ToString());

                    AddMessage(LastBanci + " 换班数据清零。数据库更新" + result);
                    AlarmCount = 0;
                    Xinjie.SetM(11099, true);//通知PLC换班，计数清空
                    CardLockFlag = true;
                    CardLockTime = System.DateTime.Now;
                    Xinjie.SetM(11155, true);
                }
                #endregion
                #region 刷卡
                if (first && plcstate)
                {
                    first = false;
                    CardLockFlag = true;
                    CardLockTime = System.DateTime.Now;
                    Xinjie.SetM(11155, true);
                }
                if (cardcount++ > 9)
                {
                    cardcount = 0;

                    if (CardLockFlag)
                    {
                        await Task.Run(() =>
                        {
                            try
                            {
                                SXJLibrary.Oracle oraDB = new SXJLibrary.Oracle("qddb04.eavarytech.com", "mesdb04", "ictdata", "ictdata*168");
                                if (oraDB.isConnect())
                                {
                                    string stm = string.Format("SELECT * FROM CFT_DATA WHERE CFT01 LIKE '%{0}%' AND MNO = '{1}' AND TRESULT = 'PASS' ORDER BY TESTDATE DESC,TESTTIME DESC",
                                        PM, MACID_M);
                                    DataSet ds = oraDB.executeQuery(stm);
                                    DataTable dt = ds.Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        DataRow dr = dt.Rows[0];
                                        string datestr = (string)dr["TESTDATE"];
                                        string timestr = (string)dr["TESTTIME"];
                                        if (datestr.Length == 8 && (timestr.Length == 5 || timestr.Length == 6))
                                        {
                                            if (timestr.Length == 5)
                                            {
                                                timestr = "0" + timestr;
                                            }
                                            string datetimestr = string.Empty;
                                            datetimestr = string.Format("{0}/{1}/{2} {3}:{4}:{5}", datestr.Substring(0, 4), datestr.Substring(4, 2), datestr.Substring(6, 2), timestr.Substring(0, 2), timestr.Substring(2, 2), timestr.Substring(4, 2));
                                            DateTime updatetime = Convert.ToDateTime(datetimestr);
                                            if ((updatetime - CardLockTime).TotalMilliseconds > 0)
                                            {
                                                Xinjie.SetM(11155, false);
                                                CardLockFlag = false;
                                                //OperaterID = (string)dr["OPERTOR"];
                                                //Inifile.INIWriteValue(iniFilepath, "A", "op", OperaterID);
                                                AddMessage("刷卡成功，解锁");
                                            }
                                        }
                                    }
                                }
                                oraDB.disconnect();
                            }
                            catch (Exception ex)
                            {
                                AddMessage(ex.Message);
                            }
                        });

                    }

                }
                #region 锁机
                if (!CardLockFlag && plcstate)
                {
                    if (LampColor != 1)
                    {
                        if (timetick++ > 15 * 600)
                        {
                            Xinjie.SetM(11155, true);
                            CardLockFlag = true;
                            CardLockTime = DateTime.Now;
                            AddMessage("机台锁定!");
                            timetick = 0;
                        }
                    }
                    else
                    {
                        timetick = 0;
                    }
                }
                else
                {
                    timetick = 0;
                }
                #endregion
                #endregion
                #region 清洁报警
                if (filmalarmcount++ > 100)
                {
                    filmalarmcount = 0;
                    if (DateTime.Now > NextCleanTime)
                    {
                        FilmEmptyAlarmString = "清洁时间到，请清洁。";
                        ShowFilmEmptyAlarmWindow = !ShowFilmEmptyAlarmWindow;
                        await Task.Run(()=> { Xinjie.SetM(11165, true); });
                        metro.ChangeAccent("Red");
                    }
                }
                #endregion
            }
        }
        async void BigDataRun()
        {
            int _LampColor = LampColor;
            int preLampColor = LampColor;
            int count1 = 0;int count2 = 0;
            bool first = true;
            LampGreenSw.Start();
            while (true)
            {
                await Task.Delay(1000);//每秒刷新               
                #region 报警
                if (M11000 != null && plcstate)
                {
                    for (int i = 0; i < AlarmList.Count; i++)
                    {
                        if (M11000[i] != AlarmList[i].State && AlarmList[i].Content != "Null" && (LampGreenSw.Elapsed.TotalMinutes > 3 || first))
                        //if (M11000[i] != AlarmList[i].State)
                        {
                            first = false;
                            LampGreenSw.Reset();
                            AlarmList[i].State = M11000[i];
                            if (AlarmList[i].State)
                            {
                                CurrentAlarm = AlarmList[i].Content;

                                AlarmList[i].Start = DateTime.Now;
                                AlarmList[i].End = DateTime.Now;
                                AddMessage(AlarmList[i].Code + AlarmList[i].Content + "发生");



                                AlarmAction(i);//等待报警结束
                            }

                        }
                    }

                }
                #endregion
                #region 灯号更新
                switch (LampColor)
                {
                    case 1:
                        LampGreenElapse += 1;
                        Inifile.INIWriteValue(iniParameterPath, "BigData", "LampGreenElapse", LampGreenElapse.ToString());
                        break;
                    case 2:
                        LampGreenFlickerElapse += 1;
                        Inifile.INIWriteValue(iniParameterPath, "BigData", "LampGreenFlickerElapse", LampGreenFlickerElapse.ToString());
                        break;
                    case 3:
                        LampYellowElapse += 1;
                        Inifile.INIWriteValue(iniParameterPath, "BigData", "LampYellowElapse", LampYellowElapse.ToString());
                        break;
                    case 4:
                        LampYellowFlickerElapse += 1;
                        Inifile.INIWriteValue(iniParameterPath, "BigData", "LampYellowFlickerElapse", LampYellowFlickerElapse.ToString());
                        break;
                    case 5:
                        if (preLampColor == 4)
                        {
                            LampRedElapse += 1;
                            Inifile.INIWriteValue(iniParameterPath, "BigData", "LampRedElapse", LampRedElapse.ToString());
                        }
                        break;
                    default:
                        break;
                }
                count1++;
                if (_LampColor != LampColor || count1 > 60)
                {

                    if (LampColor == 1 && _LampColor != LampColor)
                    {
                        LampGreenSw.Restart();
                    }
                    preLampColor = _LampColor;
                    _LampColor = LampColor;
                    count1 = 0;
                    string result = await Task<string>.Run(() =>
                    {
                        try
                        {
                            int _result = -999;
                            Mysql mysql = new Mysql();
                            if (mysql.Connect())
                            {
                                string currentAlarm = LampColor == 4 ? CurrentAlarm : "NA";
                                string stm = string.Format("UPDATE HA_F4_LIGHT SET LIGHT = '{3}',SDATE = '{4}',STIME = '{5}',ALARM = '{6}',TIME_1 = '{8}',TIME_2 = '{9}',TIME_3 = '{10}',TIME_4 = '{11}',TIME_5 = '{12}' WHERE PM = '{0}' AND LIGHT_ID = '{1}' AND MACID = '{2}' AND CLASS = '{7}' AND WORKSTATION = '{13}'"
                                    , PM, LIGHT_ID, MACID, LampColor, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("mmddss"), currentAlarm, GetBanci(), ((double)LampGreenElapse / 60).ToString("F2"), ((double)LampGreenFlickerElapse / 60).ToString("F2"), ((double)LampYellowElapse / 60).ToString("F2")
                                    , ((double)LampYellowFlickerElapse / 60).ToString("F2"), ((double)LampRedElapse / 60).ToString("F2"), WORKSTATION);
                                _result = mysql.executeQuery(stm);
                            }
                            mysql.DisConnect();
                            return _result.ToString();
                        }
                        catch (Exception ex)
                        {
                            return ex.Message;
                        }
                    });
                    AddMessage("更新灯信号" + result);
                }
                if (LampColor != 1)
                {
                    LampGreenSw.Reset();
                }
                if (LampColor == 1 && LampGreenSw.Elapsed == TimeSpan.Zero)
                {
                    LampGreenSw.Restart();
                }
                #endregion
                #region 良率上传
                if (HD200 != null && plcstate)
                {
                    if (count2++ >= 60)
                    {
                        count2 = 0;
                        string result = await Task<string>.Run(() =>
                        {
                            try
                            {
                                int _result = -999;
                                if (HD200[6] > 0)
                                {
                                    Mysql mysql = new Mysql();
                                    if (mysql.Connect())
                                    {
                                        double fpy = HD200[6] > 0 ? HD200[3] / HD200[6] * 100 : 0;
                                        string stm = string.Format("UPDATE HA_F4_DATA_FPY SET INPUT = '{3}',OUTPUT = '{4}',FAIL = '{5}',FPY = '{6}' WHERE PM = '{0}' AND MACID = '{1}' AND CLASS = '{2}' AND WORKSTATION = '{7}'"
                                            , PM, MACID, GetBanci(), HD200[6].ToString("F0"), HD200[3].ToString("F0"), (HD200[6] - HD200[3]).ToString("F0"), fpy.ToString("F1"), WORKSTATION);
                                        _result = mysql.executeQuery(stm);
                                    }
                                    mysql.DisConnect();
                                }
                                else
                                {
                                    _result = -500;
                                }

                                return _result.ToString();
                            }
                            catch (Exception ex)
                            {
                                return ex.Message;
                            }
                        });
                        AddMessage("上传良率" + result);
                    }
                }
                #endregion
                GreenLampElapse = Math.Round(LampGreenSw.Elapsed.TotalMinutes, 1);
                //#region 机台指标
                //if (HD200 != null && plcstate)
                //{
                //    TimeSpan ts = DateTime.Now - GetBanStart();
                //    //妥善率
                //    double ProperlyRate = (ts.TotalMinutes - (double)LampYellowFlickerElapse  - (double)LampRedElapse ) / ts.TotalMinutes * 100;
                //    //报警率
                //    double AlarmRate = AlarmCount / HD200[6] * 100;
                //    //达成率
                //    double YieldRate = HD200[3] / ((ts.TotalMinutes - (double)LampGreenFlickerElapse - (double)LampYellowElapse) * (60 / HD200[7]) * 10) * 100;
                //    //直通率
                //    double PassRate = HD200[3] / HD200[6] * 100;

                //    await Task.Run(() => { Xinjie.WriteW(410, (PassRate * 10).ToString("F0")); });//往D410写直通率，保留1位小数
                //    await Task.Run(() => { Xinjie.WriteW(411, (AlarmRate * 10).ToString("F0")); });//往D410写报警率，保留1位小数
                //    await Task.Run(() => { Xinjie.WriteW(412, (YieldRate * 10).ToString("F0")); });//往D411写达成率，保留1位小数
                //    await Task.Run(() => { Xinjie.WriteW(413, (ProperlyRate * 10).ToString("F0")); });//往D413写妥善率，保留1位小数

                await Task.Run(() => { Xinjie.WriteW(401, AlarmCount.ToString()); });//往D401写报警次数
                //}
                //#endregion
            }

        }
        async void AlarmAction(int i)
        {
            while (true)
            {
                await Task.Delay(100);
                try
                {
                    if (LampGreenSw.Elapsed.TotalMinutes > 3)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    AddMessage("AlarmAction " + ex.Message);
                }

            }
            AlarmList[i].End = DateTime.Now;
            AddMessage(AlarmList[i].Code + AlarmList[i].Content + "解除");
            TimeSpan time = AlarmList[i].End - AlarmList[i].Start - LampGreenSw.Elapsed;
            //string result = await Task<string>.Run(() =>
            //{
            //    try
            //    {
            //        int _result = -999;
            //        Mysql mysql = new Mysql();
            //        if (mysql.Connect())
            //        {
            //            string stm = string.Format("UPDATE HA_F4_DATA_ALARM SET SSTOPDATE = '{5}',SSTOPTIME = '{6}',TIME = '{7}' WHERE PM = '{0}' AND MACID = '{1}' AND NAME = '{2}' AND SSTARTDATE = '{3}' AND SSTARTTIME = '{4}'"
            //                , PM, MACID, AlarmList[i].Content, AlarmList[i].Start.ToString("yyyyMMdd"), AlarmList[i].Start.ToString("HHmmss"), AlarmList[i].End.ToString("yyyyMMdd"), AlarmList[i].End.ToString("HHmmss"), time.TotalMinutes.ToString("F2"));
            //            _result = mysql.executeQuery(stm);
            //        }
            //        mysql.DisConnect();
            //        return _result.ToString();
            //    }
            //    catch (Exception ex)
            //    {
            //        return ex.Message;
            //    }
            //});
            //AddMessage("更新报警" + result);


            string result = await Task<string>.Run(() =>
            {
                try
                {
                    int _result = -999;
                    Mysql mysql = new Mysql();
                    if (mysql.Connect())
                    {
                        string stm = string.Format("INSERT INTO HA_F4_DATA_ALARM (PM, GROUP1,TRACK,MACID,NAME,SSTARTDATE,SSTARTTIME,SSTOPDATE,SSTOPTIME,TIME,CLASS,WORKSTATION) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')"
                            , PM, GROUP1, TRACK, MACID, AlarmList[i].Content, AlarmList[i].Start.ToString("yyyyMMdd"), AlarmList[i].Start.ToString("HHmmss"), AlarmList[i].End.ToString("yyyyMMdd"), AlarmList[i].End.ToString("HHmmss"), time.TotalMinutes.ToString("F1"), GetBanci(), WORKSTATION);
                        _result = mysql.executeQuery(stm);
                    }
                    mysql.DisConnect();
                    return _result.ToString();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            });
            AddMessage("插入报警" + result);
        }
        private bool CheckSampleFromDt()
        {
            //条码、时间=>表格
            //不良项目数量是否够？
            try
            {
                if (SampleBarcode.Count > 0)
                {
                    SXJLibrary.Oracle oraDB = new SXJLibrary.Oracle("qddb04.eavarytech.com", "mesdb04", "ictdata", "ictdata*168");
                    if (oraDB.isConnect())
                    {
                        //select * from up_date where update >= to_date('2007-09-07 00:00:00','yyyy-mm-dd hh24:mi:ss')
                        //select* from barsamrec where barcode in ('G5Y796383C9LQ5919SAT','G5Y9321RAH5K7QC8V-G') and sdate > to_date('2019/8/16 18:45:16', 'yyyy/mm/dd hh24:mi:ss')
                        string samplebarcodes = "";
                        foreach (var item in SampleBarcode)
                        {
                            samplebarcodes += "'" + item + "',";
                        }
                        samplebarcodes = samplebarcodes.Substring(0, samplebarcodes.Length - 1);
                        string[] mnos = MNOStr.Split(new string[] { "\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                        string sampleMNOs = "";
                        for (int i = 0; i < mnos.Length; i++)
                        {
                            if (mnos[i] != "")
                            {
                                sampleMNOs += "'" + mnos[i] + "',";
                            }
                        }
                        sampleMNOs = sampleMNOs.Substring(0, sampleMNOs.Length - 1);
                        string selectSqlStr = "select * from barsamrec where BARCODE in (" + samplebarcodes + ") and MNO in (" + sampleMNOs + ") and sdate > to_date('" + DateTime.Now.AddMinutes(-30).ToString() + "', 'yyyy/mm/dd hh24:mi:ss')";
                        //AddMessage(selectSqlStr);
                        DataSet s = oraDB.executeQuery(selectSqlStr);
                        DataTable dt = s.Tables[0];
                        string Columns = "";
                        for (int i = 0; i < dt.Columns.Count - 1; i++)
                        {
                            Columns += dt.Columns[i].ColumnName + ",";
                        }
                        Columns += dt.Columns[dt.Columns.Count - 1].ColumnName;
                        Csvfile.dt2csv(dt, "C:\\Debug\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "Sample.csv", "Sample", Columns);

                        try
                        {
                            Process process1 = new Process();
                            process1.StartInfo.FileName = "C:\\Debug\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "Sample.csv";
                            process1.StartInfo.Arguments = "";
                            process1.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                            process1.Start();
                        }
                        catch (Exception ex)
                        {
                            AddMessage(ex.Message);
                        }

                        //匹配不良项数量是否满足
                        int[] counts = new int[NGItemCount];
                        //匹配是否测试正确

                        for (int i = 0; i < NGItemCount; i++)
                        {
                            DataRow[] dtr = dt.Select(string.Format("NGITEM = '{0}' AND SITEM = '{1}' AND TRES = '{2}'", NGItems[i].NgItem.ToString(), NGItems[i].NGItemClassify, NGItems[i].NgItem));
                            counts[i] = dtr.Length;
                            if (dtr.Length == 0)
                            {
                                AddMessage(NGItems[i].NGItemClassify + ":" + NGItems[i].NgItem + "没测到该样本项");
                            }
                        }
                        for (int i = 0; i < NGItemCount; i++)
                        {
                            if (counts[i] <= 0)
                            {
                                return false;
                            }
                        }
                        oraDB.disconnect();
                        return true;
                    }
                    else
                    {
                        AddMessage("数据库连接失败");
                        return false;
                    }
                }
                else
                {
                    AddMessage("条码数量为零");
                    return false;
                }
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                return false;
            }

        }
        void SaveResult(string bar, string rst, string index)
        {
            try
            {
                if (!Directory.Exists(Path.Combine(System.Environment.CurrentDirectory, DateTime.Now.ToString("yyyyMMdd"))))
                {
                    Directory.CreateDirectory(Path.Combine(System.Environment.CurrentDirectory, DateTime.Now.ToString("yyyyMMdd")));
                }
                string path = Path.Combine(System.Environment.CurrentDirectory, DateTime.Now.ToString("yyyyMMdd"), "Barcode.csv");
                Csvfile.savetocsv(path, new string[] { DateTime.Now.ToString(), bar, rst, index });
            }
            catch
            {

            }

        }
        private void WriteMachineData()
        {
            string excelpath = @"D:\D5XMachineData.xlsx";

            try
            {
                FileInfo fileInfo = new FileInfo(excelpath);
                if (!File.Exists(excelpath))
                {
                    using (ExcelPackage package = new ExcelPackage(fileInfo))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("MachineData");
                        worksheet.Cells[1, 1].Value = "绿灯常亮累计时长（单位min）";
                        worksheet.Cells[1, 2].Value = "绿灯闪烁累计时长（单位min）";
                        worksheet.Cells[1, 3].Value = "黄灯常亮累计时长（单位min）";
                        worksheet.Cells[1, 4].Value = "黄灯闪烁累计时长（单位min）";
                        worksheet.Cells[1, 5].Value = "红灯常亮累计时长（单位min）";
                        package.Save();
                    }
                }


                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int newrow = worksheet.Dimension.End.Row + 1;
                    worksheet.Cells[newrow, 1].Value = System.DateTime.Now.ToString();
                    worksheet.Cells[newrow, 2].Value = LampGreenElapse;
                    worksheet.Cells[newrow, 2].Value = LampGreenFlickerElapse;
                    worksheet.Cells[newrow, 3].Value = LampYellowElapse;
                    worksheet.Cells[newrow, 4].Value = LampYellowFlickerElapse;
                    worksheet.Cells[newrow, 5].Value = LampRedElapse;
                    package.Save();
                }
                AddMessage("保存机台生产数据完成");
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }
        }
        string GetPassWord()
        {
            int day = System.DateTime.Now.Day;
            int month = System.DateTime.Now.Month;
            string ss = (day + month).ToString();
            string passwordstr = "";
            for (int i = 0; i < 4 - ss.Length; i++)
            {
                passwordstr += "0";
            }
            passwordstr += ss;
            return passwordstr;
        }
        public void RunLog(string str)
        {
            try
            {
                string tempSaveFilee5 = System.AppDomain.CurrentDomain.BaseDirectory + @"RunLog";
                DateTime dtim = DateTime.Now;
                string DateNow = dtim.ToString("yyyy/MM/dd");
                string TimeNow = dtim.ToString("HH:mm:ss");

                if (!Directory.Exists(tempSaveFilee5))
                {
                    Directory.CreateDirectory(tempSaveFilee5);  //创建目录 
                }

                if (File.Exists(tempSaveFilee5 + "\\" + DateNow.Replace("/", "") + ".txt"))
                {
                    //第一种方法：
                    FileStream fs = new FileStream(tempSaveFilee5 + "\\" + DateNow.Replace("/", "") + ".txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("TTIME：" + TimeNow + " 执行事件：" + str);
                    sw.Dispose();
                    fs.Dispose();
                    sw.Close();
                    fs.Close();
                }
                else
                {
                    //不存在就新建一个文本文件,并写入一些内容 
                    StreamWriter sw;
                    sw = File.CreateText(tempSaveFilee5 + "\\" + DateNow.Replace("/", "") + ".txt");
                    sw.WriteLine("TTIME：" + TimeNow + " 执行事件：" + str);
                    sw.Dispose();
                    sw.Close();
                }
            }
            catch { }
        }
        private string GetBanci()
        {
            string rs = "";
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
            {
                rs += DateTime.Now.ToString("yyyyMMdd") + "_D";
            }
            else
            {
                if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 8)
                {
                    rs += DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "_N";
                }
                else
                {
                    rs += DateTime.Now.ToString("yyyyMMdd") + "_N";
                }
            }
            return rs;
        }
        private DateTime GetBanStart()
        {
            //"2020/1/1 00:00:00"
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
            {
                return Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd ") + "08:00:00");
            }
            else
            {
                if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 8)
                {
                    return Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd ") + "20:00:00");
                }
                else
                {
                    return Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd ") + "20:00:00");
                }
            }
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
            MessageStr += System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + str;
        }
        private void WriteToJson(object p, string path)
        {
            try
            {
                using (FileStream fs = File.Open(path, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, p);
                }
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }
        }
        #endregion
        #region 方法绑定执行函数
        private void FuncTestCommandExecute()
        {
            //Inifile.INIWriteValue(iniParameterPath, "转盘", "LocalIP", "127.0.0.1");
            //Inifile.INIWriteValue(iniParameterPath, "转盘", "TargetIP", "127.0.0.1");
            //Inifile.INIWriteValue(iniParameterPath, "转盘", "LocalPort", "8001");
            //Inifile.INIWriteValue(iniParameterPath, "转盘", "TargetPort", "8000");
            //Inifile.INIWriteValue(iniParameterPath, "灵敏度", "LocalIP", "127.0.0.1");
            //Inifile.INIWriteValue(iniParameterPath, "灵敏度", "TargetIP", "127.0.0.1");
            //Inifile.INIWriteValue(iniParameterPath, "灵敏度", "LocalPort", "8002");
            //Inifile.INIWriteValue(iniParameterPath, "灵敏度", "TargetPort", "8020");
            //Inifile.INIWriteValue(iniParameterPath, "读卡器", "COM", "COM21");
            //Inifile.INIWriteValue(iniParameterPath, "读卡器", "MODE", "3");
            //byte[] aa = new byte[256];
            //aa[0] = 78; aa[1] = 98;
            //AddMessage(Encoding.UTF8.GetString(aa));


            //reader.OpenComm(21, 9600);//打开串口

            //while (true)
            //{
            //    System.Threading.Thread.Sleep(100);

            //    byte[] buf = new byte[256];
            //    byte[] snr = CPublic.CharToByte("FF FF FF FF FF");
            //    int ret = reader.MF_Read(0, 0, 0, 1, ref snr[0], ref buf[0]);//读取卡信息

            //    if (ret == 0)
            //    {
            //        var str = Encoding.UTF8.GetString(buf);//编码
            //    }

            //}

            //var daa = Convert.ToDateTime((DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd ") + "08:00:00"));
            //AddMessage(DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd ") + "08:00:00");








        }
        private void ManulSampleCommandExecute()
        {
            if (!sampleTestAbort && !isInSampleMode && IsSampleCheck && plcstate)
            {
                Xinjie.SetM(11110, true);
                isInSampleMode = true;
                Xinjie.SetM(11112, false);
                //NowSam = DateTime.Now;
                AddMessage("开始样本测试");
            }
        }
        private void SampleCommandExecute()
        {
            SampleWindowPassword = "";
            SampleWindowPasswordPageVisibility = "Visible";
            ShowSampleWindow = !ShowSampleWindow;
        }
        private void SampleWindowPasswordConfirmCommandExecute()
        {
            if (SampleWindowPassword == GetPassWord())
            {
                SampleWindowPasswordPageVisibility = "Collapsed";
            }
            else
            {
                SampleWindowPassword = "";
                AddMessage("密码错误");
            }
        }
        private void SampleSaveCommandExecute()
        {
            for (int i = 0; i < 10; i++)
            {
                Inifile.INIWriteValue(iniParameterPath, "Sample", "NGItem" + (i + 1).ToString(), this.NGItems[i].NgItem);
                Inifile.INIWriteValue(iniParameterPath, "Sample", "NGItemClassify" + (i + 1).ToString(), this.NGItems[i].NGItemClassify);
            }
            Inifile.INIWriteValue(iniParameterPath, "Sample", "IsSampleCheck", this.IsSampleCheck.ToString());
            Inifile.INIWriteValue(iniParameterPath, "Sample", "NGItemCount", this.NGItemCount.ToString());
            Inifile.INIWriteValue(iniParameterPath, "Sample", "SamMode", SamMode);
            Inifile.INIWriteValue(iniParameterPath, "Sample", "ZPMID", ZPMID);
            Inifile.INIWriteValue(iniParameterPath, "Sample", "FCTMID", FCTMID);
            paramJson.MNOStr = MNOStr;
            WriteToJson(paramJson, Path.Combine(System.Environment.CurrentDirectory, "Param.json"));
            QuitSampleWindow = !QuitSampleWindow;
            AddMessage("样本参数保存完成");
        }
        private void BigDataPeramEditCommandExecute()
        {
            if (BigDataEditIsReadOnly)
            {
                BigDataEditIsReadOnly = false;
                BigDataPeramEdit = "Save";
            }
            else
            {
                Inifile.INIWriteValue(iniParameterPath, "BigData", "PM", PM);
                Inifile.INIWriteValue(iniParameterPath, "BigData", "GROUP1", GROUP1);
                Inifile.INIWriteValue(iniParameterPath, "BigData", "TRACK", TRACK);
                Inifile.INIWriteValue(iniParameterPath, "BigData", "MACID", MACID);
                Inifile.INIWriteValue(iniParameterPath, "BigData", "WORKSTATION", WORKSTATION);
                Inifile.INIWriteValue(iniParameterPath, "BigData", "MACID_M", MACID_M);
                Inifile.INIWriteValue(iniParameterPath, "BigData", "LIGHT_ID", LIGHT_ID);
                BigDataEditIsReadOnly = true;
                BigDataPeramEdit = "Edit";
                AddMessage("大数据参数保存");
            }
        }
        private async void BigDataAlarmGetCommandCommandExecute()
        {
            AlarmButtonIsEnabled = false;

            var rst = await Task<string>.Run(() =>
            {
                try
                {
                    if (!Directory.Exists(Path.Combine(System.Environment.CurrentDirectory, DateTime.Now.ToString("yyyyMMdd"))))
                    {
                        Directory.CreateDirectory(Path.Combine(System.Environment.CurrentDirectory, DateTime.Now.ToString("yyyyMMdd")));
                    }
                    string path = Path.Combine(System.Environment.CurrentDirectory, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMddHHmmss") + "AlarmTotal.csv");


                    Mysql mysql = new Mysql();
                    if (mysql.Connect())
                    {
                        string stm = string.Format("SELECT * FROM HA_F4_DATA_ALARM WHERE PM = '{0}' AND MACID = '{1}' AND CLASS = '{2}' AND WORKSTATION = '{3}'", PM, MACID, GetBanci(), WORKSTATION);
                        DataSet ds = mysql.Select(stm);

                        DataTable dt = ds.Tables["table0"];
                        if (dt.Rows.Count > 0)
                        {
                            AlarmCount = dt.Rows.Count;
                            string strHead = DateTime.Now.ToString("yyyyMMddHHmmss") + "AlarmTotal";
                            string strColumns = "";
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                strColumns += dt.Columns[i].ColumnName + ",";
                            }
                            strColumns = strColumns.Substring(0, strColumns.Length - 1);
                            Csvfile.dt2csv(dt, path, strHead, strColumns);

                            Process process1 = new Process();
                            process1.StartInfo.FileName = path;
                            process1.StartInfo.Arguments = "";
                            process1.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                            process1.Start();
                        }

                    }
                    mysql.DisConnect();




                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
                return "查询报警结束";
            });

            AddMessage(rst);
            AlarmButtonIsEnabled = true;
        }

        
        
        private void CleanActionCommandExecute()
        {
            QuitFilmEmptyAlarmWindow = !QuitFilmEmptyAlarmWindow;
            metro.ChangeAccent("Blue");
            LastCleanTime = DateTime.Now;
            Inifile.INIWriteValue(iniParameterPath, "Clean", "LastCleanTime", LastCleanTime.ToString());
            Task.Run(() => { Xinjie.SetM(11165, false); });
        }
        #endregion
    }
    public class Param
    {
        public string MNOStr { set; get; }
        public Param()
        {
            MNOStr = "";
        }
    }
}
