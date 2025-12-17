namespace Part98_Delegate_And_Event
{
    public class Student
    {
        public Student(string name)
        {
            this.name = name;
        }
        // sắp theo thứ tự chữ cái
        public static Comparison WhichStudentComesFirst(Object o1, Object o2)
        {
            Student s1 = (Student)o1;
            Student s2 = (Student)o2;
            return (String.Compare(s1.name, s2.name) < 0 ?
            Comparison.theFirstComesFirst :
            Comparison.theSecondComesFirst);
        }
        public override string ToString()
        {
            return name;
        }
        // biến lưu tên
        private string name;
    }
}
