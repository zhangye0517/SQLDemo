using GalaSoft.MvvmLight;

namespace SQLDemo.Mode
{
    class TeacherInf : ObservableObject
    {
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
    }
}
