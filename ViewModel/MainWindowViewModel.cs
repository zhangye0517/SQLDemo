using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SQLDemo.Mode;

namespace SQLDemo.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private ushort _SelectedPageIndex = 0;
        public ushort SelectedPageIndex
        {   
            get
            {
                return _SelectedPageIndex;
            }
            set
            {
                Set(ref _SelectedPageIndex, value);
            }
        }
        public RelayCommand<string> SelectPageCommand
        {
            get;
            private set;
        }
        public MainWindowViewModel()
        {
            SelectPageCommand = new RelayCommand<string>(SelectPageAction);
            Messenger.Default.Register<ushort>(this, "SelectPageMsg", m =>
            {
                _SelectedPageIndex = m;
            });
        }
        public void SelectPageAction(string key)
        {
            switch (key)
            {
                case "Student":
                    SelectedPageIndex = 0;
                    break;
                case "Teacher":
                    SelectedPageIndex = 1;
                    break;
                default:
                    break;
            }

        }
    }
}
