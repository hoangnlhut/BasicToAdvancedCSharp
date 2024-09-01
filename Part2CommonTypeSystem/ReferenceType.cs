using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2CommonTypeSystem
{
    public class Student
    {
        public string? Name { get; set; }
        public int Id { get; set; }
    }
    public class ReferenceType
    {
        public void AssignedReferenceTest() 
        {
            Student studentA = new Student() { Id = 1, Name = "Hoang" };
            var studentB = studentA;
            Console.WriteLine($"print studentA: {studentA.Id} - {studentA.Name} ");
            Console.WriteLine($"print studentB: {studentB.Id} - {studentB.Name}");

            studentA.Id = 20;
            studentA.Name = "Trang";
            Console.WriteLine($"print studentA: {studentA.Id} - {studentA.Name} ");
            Console.WriteLine($"print studentB: {studentB.Id} - {studentB.Name}");

            studentB.Id = 30;
            studentB.Name = "Viet";
            Console.WriteLine($"print studentA: {studentA.Id} - {studentA.Name} ");
            Console.WriteLine($"print studentB: {studentB.Id} - {studentB.Name}");
        }
    }
}
