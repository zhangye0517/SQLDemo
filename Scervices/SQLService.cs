using SQLDemo.Mode;
using System.Collections.ObjectModel;
namespace SQLDemo.access.Scervices
{
    class SQLService
    {
        ActionAccess actionAccess = new ActionAccess();
        public StudentInf StudentInformationSelect(string ItemName)
        {
            StudentInf studentInf = new StudentInf();
            object[] info = new object[5];
            info = actionAccess.SqlReadAction("Student", "Name", ItemName);
            if (info[0].ToString() != "")
            {
                studentInf.Name = info[1].ToString();
                studentInf.Id = int.Parse(info[2].ToString());
                studentInf.MyClass = info[3].ToString();
                studentInf.Age = int.Parse(info[4].ToString());
                studentInf.Information = info[5].ToString();
            }
            return studentInf;
        }
        public TeacherInf TeacherInformationSelect(string ItemName)
        {
            TeacherInf teacherInf = new TeacherInf();
            object[] info = new object[5];
            info = actionAccess.SqlReadAction("Teacher", "Name", ItemName);
            if (info[0].ToString() != "")
            {
                teacherInf.Id = int.Parse(info[0].ToString());
                teacherInf.Name = info[1].ToString();
                teacherInf.Subject = info[2].ToString();
                teacherInf.Age = int.Parse(info[3].ToString());
                teacherInf.ProfessionalTitle = info[4].ToString();
            }
            return teacherInf;
        }

        public ObservableCollection<StudentInf> UpdateStudentList()
        {
            ObservableCollection<StudentInf> OC = new ObservableCollection<StudentInf>();

            return OC;
        }
        public void StudentInformationAdd(StudentInf studentInf)
        {
            string ss = "'" + studentInf.Name + "'," + "'" + studentInf.Id + "'," + "'" + studentInf.MyClass + "'," + "'" + studentInf.Age + "'," + "'" + studentInf.Information + "'";
            actionAccess.InsertAction<string>("Student", "Name,StuId,Class,Age,Info", ss);
        }
    }
}
