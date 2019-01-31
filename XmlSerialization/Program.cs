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
            Console.WriteLine($"Press any key to serialize people collection");
            Console.ReadKey();
            ///////////////////////////////////////////////////////////////////////////////

            List<Person> people = new List<Person>()
            {
                new Person("Bill", 25),
                new Person("Tom", 30),
                new Person("Jill", 28)
            };
            XmlSerializer peopleSerializer = new XmlSerializer(typeof(List<Person>));
            using(FileStream fileStream = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                peopleSerializer.Serialize(fileStream, people);
                Console.WriteLine($"Collection Serialized");
            }
            Console.WriteLine($"Press any key to Desrialize people collection");
            Console.ReadKey();

            using(FileStream fileStream = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                List<Person> newPeople = (List<Person>)peopleSerializer.Deserialize(fileStream);
                foreach (var item in newPeople)
                {
                    Console.WriteLine($"Person Name: {item.Name}\t Person Age: {item.Age}");
                }
                Console.WriteLine($"Collection Deserialized");
            }
            Console.ReadKey();
            
        }
    }
}
