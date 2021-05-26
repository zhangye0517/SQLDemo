using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using SQLDemo.Mode;
using SQLDemo.access.ViewModel;

namespace SQLDemo.ViewModel
{
    class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<StudentViewModel>();
            SimpleIoc.Default.Register<TeacherViewModel>();
            SimpleIoc.Default.Register<MainWindowViewModel>();
        }
        public MainWindowViewModel MainView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }

        public StudentViewModel StudentView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StudentViewModel>();
            }
        }
        
        public TeacherViewModel TeacherView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TeacherViewModel>();
            }
        }
    }
}
