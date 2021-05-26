using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SQLDemo.Mode;
using SQLDemo.access.Scervices;
using System.Collections.ObjectModel;
namespace SQLDemo.ViewModel
{
    class StudentViewModel : ViewModelBase
    {
        readonly SQLService sqlSever = new SQLService();
        
        private StudentInf _studentInformation;
        public StudentInf StudentInformation
        {
            get
            {
                return _studentInformation;
            }

            set
            {
                Set(ref _studentInformation, value);
            }
        }

        private ObservableCollection<StudentInf> _studentInf;
        public ObservableCollection<StudentInf> StudentInf
        {
            get
            {
                return _studentInf;
            }

            set
            {
                Set(ref _studentInf, value);
                RaisePropertyChanged("StudentInf");
            }
        }

        private string _searchId;
        public string SearchId
        {
            get
            {
                return _searchId;
            }

            set
            {
                Set(ref _searchId, value);
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                Set(ref _name, value);
            }
        }
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                Set(ref _id, value);
            }
        }
        private string _myclass;
        public string MyClass
        {
            get { return _myclass; }
            set
            {
                Set(ref _myclass, value);
            }
        }
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                Set(ref _age, value);
            }
        }
        private string _information;
        public string Information
        {
            get { return _information; }
            set
            {
                Set(ref _information, value);
            }
        }
        public RelayCommand StudentAddCommond
        {
            get;
            private set;
        }
        public RelayCommand StudentSearchCommond
        {
            get;
            private set;
        }
        public StudentViewModel()
        {
            //构造一个初始值
            SearchId = "Zhangye";
            this.SearchIformation();

            //测试groupbox
            StudentInf = new ObservableCollection<StudentInf>
            {
                new StudentInf {Id =1,Name = "zhangye"}
            };
            StudentAddCommond = new RelayCommand(AddAction);
            StudentSearchCommond = new RelayCommand(SearchAction);
        }
        public void AddAction()
        {
            StudentInf studentInf = new StudentInf();
            studentInf.Name = Name;
            studentInf.Age = Age;
            studentInf.Id = Id;
            studentInf.MyClass = MyClass;
            studentInf.Information = Information;
            sqlSever.StudentInformationAdd(studentInf);
        }
        public void SearchAction()
        {
            this.SearchIformation();
        }

        private void SearchIformation()
        {
            _studentInformation = sqlSever.StudentInformationSelect(SearchId);
            Name = _studentInformation.Name;
            Age = _studentInformation.Age;
            Id = _studentInformation.Id;
            MyClass = _studentInformation.MyClass;
            Information = _studentInformation.Information;
        }
    }
}
