using System;
using System.Collections.Generic;

namespace StudentRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var s = new Student("Rockwell", "Sam", "S");
            var p = new Student("Parker", "Peter", "J");
            var v = new Student("Veronika", "Stubbs", "C");

            var students = new List<Student>() { s, p, v };

            var cis400 = new Course()
            {
                Title = "CIS 400",
                CreditHours = 3,
                CourseNumber = 4382739
            };
            var cis308 = new Course()
            {
                Title = "CIS 308",
                CreditHours = 1,
                CourseNumber = 237921
            };
            s.Enroll(cis400);
            s.Enroll(cis308);
            s.CompleteCourse(cis400, Grade.XF);
            s.CompleteCourse(cis308, Grade.C);

            p.Enroll(cis400);
            p.Enroll(cis308);
            p.Drop(cis308);

            v.Enroll(cis400);
            v.Enroll(cis308);
            v.CompleteCourse(cis400, Grade.A);
            v.CompleteCourse(cis308, Grade.B);

            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
