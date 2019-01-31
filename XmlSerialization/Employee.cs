using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSerialization
{
    [Serializable]
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Company Company { get; set; }

        public Employee() { }//Default Constructor
        public Employee(string firstName, string lastName, int age, Company comp)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Company = comp;
        }
    }
}
