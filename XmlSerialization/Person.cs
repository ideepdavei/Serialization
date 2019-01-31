using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSerialization
{
        //The class to be serialized must have a standard constructor without parameters.
        //Also only open members are subject to serialization.If the class has fields or properties 
        //with the private modifier, then they will be ignored during serialization.
    [Serializable]
    public class Person
    {
        private string name;
        private int age;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public Person() { } //Defaoult constructor without parameters
        public Person(string personName, int personAge)
        {
            this.Name = personName;
            this.Age = personAge;
        }

        public override string ToString() => string.Format($"Person Name: {Name}\nPerson Age: {Age}");
    }
}
