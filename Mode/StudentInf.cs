using GalaSoft.MvvmLight;

namespace SQLDemo.Mode
{
    public class StudentInf : ObservableObject
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
        private int _id = 1001;
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
        private int _age = 20;
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


    }
}
