using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace XmlSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("David", 42);
            Console.WriteLine($"Object created");

            // pass the class type to the constructor
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

            // get the stream where we will write the serialized object
            using(FileStream fileStream = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, person);
                Console.WriteLine($"Object serialized");
            }
            Console.WriteLine($"To deserialize press any key");
            Console.ReadKey();

            using (FileStream fileStream = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)xmlSerializer.Deserialize(fileStream);
                Console.WriteLine($"Objec Deserialized");
                Console.WriteLine($"Person Name: {newPerson.Name}\nPerson Age: {newPerson.Age}");
            }
            Console.ReadKey();
        }
    }
}
