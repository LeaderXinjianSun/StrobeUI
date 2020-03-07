using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrobeUI.ViewModels
{
    class SampleNgItemViewModel : NotificationObject
    {
        public int Id { get; set; }
        private string ngItem;

        public string NgItem
        {
            get { return ngItem; }
            set
            {
                ngItem = value;
                this.RaisePropertyChanged("NgItem");
            }
        }
        private string nGItemClassify;

        public string NGItemClassify
        {
            get { return nGItemClassify; }
            set
            {
                nGItemClassify = value;
                this.RaisePropertyChanged("NGItemClassify");
            }
        }

    }
}
