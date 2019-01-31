using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerialization
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public University University { get; set; }
        public Student() { }
        public Student(string name, int age, University university)
        {
            this.Name = name;
            this.Age = age;
            this.University = university;
        }
        public override string ToString()
        {
            return string.Format($"Student Name: {Name}\n" +
                $"Student Age: {Age}\n" +
                $"University: {University.UniversityName}");
        }
    }
}
