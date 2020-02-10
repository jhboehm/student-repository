using System;
using System.Collections.Generic;
using System.Text;

namespace StudentRegistry
{
    public class Student
    {
        private static uint NextId = 8000;

        private List<CourseRecord> courseRecords = new List<CourseRecord>();
        public uint ID { get; private set; }
        public string First;
        public string Middle;
        public string Last;

        public double GPA
        {
            get
            {
                var numerator = 0.0;
                var denominator = 0.0;
                foreach (var record in courseRecords)
                {
                    var gradesThatCount = new List<Grade>() { Grade.A, Grade.B, Grade.C, Grade.D, Grade.F, Grade.XF };
                    if (gradesThatCount.Contains(record.Grade))
                    {
                        denominator += record.Course.CreditHours;
                        switch (record.Grade)
                        {
                            case Grade.A:
                                numerator += 4 * record.Course.CreditHours;
                                break;

                            case Grade.B:
                                numerator += 3 * record.Course.CreditHours;
                                break;

                            case Grade.C:
                                numerator += 2 * record.Course.CreditHours;
                                break;

                            case Grade.D:
                                numerator += 1 * record.Course.CreditHours;
                                break;          

                        }

                    }
                }
                return numerator / denominator;
            }
        }

        public Student(string last,string first,string middle)
        {
            Last = last;
            First = first;
            Middle = middle;
            ID = NextId++;
        }

        public override string ToString()
        {
            return $"{Last}, {First} {Middle} [{ID}] ({GPA})";
        }

        public bool Enroll(Course course)
        {
            if(course == null){return false;}
            var record = new CourseRecord(course, Grade.IP);
            if (courseRecords.Contains(record))
            {
                return false;
            }
            courseRecords.Add(record);
            return true;
        }
        public bool Drop(Course course)
        {
            if(course == null) { return false; }
            var record = courseRecords.Find(cr => cr.Course == course);
            if (record == null) return false;
            courseRecords.Remove(record);
            return true;
        }
        public bool CompleteCourse(Course course,Grade grade)
        {
            if (course == null) return false;
            var record = courseRecords.Find(cr => cr.Course == course);
            if (record == null) return false;
            record.Grade = grade;
            return true;
        }
    }
}
