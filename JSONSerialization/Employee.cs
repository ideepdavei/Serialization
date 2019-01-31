using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace JSONSerialization
{
    [DataContract]
    public class Employee
    {
        private string firstName;
        private string lastName;
        private int age;
        private Company company;

        [DataMember]
        public string FirstName { get => firstName; set => firstName = value; }

        [DataMember]
        public string LastName { get => lastName; set => lastName = value; }

        [DataMember]
        public int Age { get => age; set => age = value; }

        [DataMember]
        public Company Company { get => company; set => company = value; }

        public Employee() { }
        public Employee(string firstName, string lastName, int age, Company company)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Company = company;
        }
    }
}
