using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrobeUI.ViewModels
{
    class FilmRuleItemViewModel: NotificationObject
    {
        public int Id { get; set; }
        private string codeRule1;

        public string CodeRule1
        {
            get { return codeRule1; }
            set
            {
                codeRule1 = value;
                this.RaisePropertyChanged("CodeRule1");
            }
        }
        private string codeRule2;
        public string CodeRule2
        {
            get { return codeRule2; }
            set
            {
                codeRule2 = value;
                this.RaisePropertyChanged("CodeRule2");
            }
        }
        private string codeRule3;
        public string CodeRule3
        {
            get { return codeRule3; }
            set
            {
                codeRule3 = value;
                this.RaisePropertyChanged("CodeRule3");
            }
        }
        private string codeRule4;
        public string CodeRule4
        {
            get { return codeRule4; }
            set
            {
                codeRule4 = value;
                this.RaisePropertyChanged("CodeRule4");
            }
        }
        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                this.RaisePropertyChanged("IsChecked");
            }
        }

    }
}
