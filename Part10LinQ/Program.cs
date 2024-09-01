using NPOI.SS.Formula.Functions;

namespace Part10LinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //StartWithLinQ();

            LinQWorkWithStudentObject();
        }
        private static void StartWithLinQ()
        {
            var dataSource = GetIntNumbers();
            Print(dataSource);

            //data to object
            //var newArrsPositive = from ar in dataSource
            //                      where ar > 0
            //                        select ar;
            //Print(newArrsPositive);

            //var newArrsNegative = from ar in dataSource
            //                      where ar < 0
            //                      select ar;
            //Print(newArrsNegative);

            //using LINQ query syntax
            //var newArrsPositive = from ar in dataSource
            //                      where GreaterThan(ar) && ar % 2 == 0
            //                      select ar;
            //Print(newArrsPositive);

            //var newArrsNegative = from ar in dataSource
            //                      where LessThan(ar)
            //                      select ar;
            //Print(newArrsNegative);

            //using LINQ method syntax
            var newArrsPositive = dataSource.Where(ar => GreaterThan(ar) && ar % 2 == 0);
            Print(newArrsPositive);

            var newArrsNegative = dataSource.Where(ar => LessThan(ar));
            Print(newArrsNegative);
        }

        static bool GreaterThan(int a)
        {
            //Console.WriteLine("This is GreaterThan method");
            return a > 0;
        }
        static bool LessThan(int a) => a < 0;


        static IEnumerable<int> GetIntNumbers()
        => new int[] { 1, 26 ,-1, -3, -4, 54345, 6412, 3345,-12,6456456 };

        static void Print(IEnumerable<int> arrs)
        {
            Console.WriteLine("---------------");
            foreach (var item in arrs)
            {
                Console.WriteLine($"{item}");
            }
        }

        static IEnumerable<Student> GetStudents() =>
                [
                   new Student() { Address = "41 tho nhuom", DoB = DateTime.Now, Name = "hoang nguyen le" },
                   new Student() { Address = "71 tho nhuom", DoB = DateTime.Now, Name = "luu thi thu trang" },
                   new Student() { Address = "11 tho nhuom", DoB = DateTime.Now, Name = "nguyen hoang viet" },
                ];

        static void PrintStudents(IEnumerable<Student> students)
        {
            Console.WriteLine("----------------------");
            foreach (var student in students) 
            {
                Console.WriteLine($"Student {student.Name} - Address {student.Address} - Dob {student.DoB}");
            }
        }

        private static void LinQWorkWithStudentObject()
        {
            var students = GetStudents();
            PrintStudents(students);
        }
    }
}
