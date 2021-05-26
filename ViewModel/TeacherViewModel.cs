using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SQLDemo.access.Scervices;
using SQLDemo.Mode;

namespace SQLDemo.access.ViewModel
{
    class TeacherViewModel : ViewModelBase
    {
        SQLService sqlSever = new SQLService();
        private TeacherInf _teacherInformation;
        public TeacherInf TeacherInformation
        {
            get
            {
                return _teacherInformation;
            }

            set
            {
                Set(ref _teacherInformation, value);
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
        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set
            {
                Set(ref _subject, value);
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
        private string _professionalTitle;
        public string ProfessionalTitle
        {
            get { return _professionalTitle; }
            set
            {
                Set(ref _professionalTitle, value);
            }
        }
        public RelayCommand TeacherAddCommand
        {
            get;
            private set;
        }

        public RelayCommand TeacherSearchCommand
        {
            get;
            private set;
        }
        public TeacherViewModel()
        {
            TeacherAddCommand = new RelayCommand(Addaction);
            TeacherSearchCommand = new RelayCommand(Searchaction);
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
        public void Addaction()
        {

        }
        public void Searchaction()
        {
            _teacherInformation = sqlSever.TeacherInformationSelect(SearchId);
            Id = _teacherInformation.Id;
            Name = _teacherInformation.Name;
            Age = _teacherInformation.Age;
            Subject = _teacherInformation.Subject;
            ProfessionalTitle = _teacherInformation.ProfessionalTitle;
        }
    }
}
