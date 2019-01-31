using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace XmlSerialization
{
    //The class to be serialized must have a standard constructor without parameters.
    //Also only open members are subject to serialization.If the class has fields or properties 
    //with the private modifier, then they will be ignored during serialization.
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
            Console.WriteLine(new string('=',50));
            Console.WriteLine($"Press any key to serialize people collection");
            Console.ReadKey();
            ///////////////////////////////////////////////////////////////////////////////
            //Equally, we can serialize an array or collection of objects, but the main 
            //requirement is that they define a standard constructor:
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
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Press any key to serialize Employee collection");
            Console.ReadKey();
            //But it was a simple object. However, it’s just as easy to work with more complex objects.
            List<Employee> employees = new List<Employee>()
            {
                new Employee("William", "Wilson", 35, new Company("Microsoft")),
                new Employee("Jacob", "Johnson", 28, new Company("Apple")),
                new Employee("Ethan", "Miller", 22, new Company("Facebook")),
                new Employee("Daniel", "Jones", 40, new Company("Google")),
            };
            XmlSerializer employeesSerializer = new XmlSerializer(typeof(List<Employee>));
            using(FileStream fileStream = new FileStream("employees.xml", FileMode.OpenOrCreate))
            {
                employeesSerializer.Serialize(fileStream, employees);
                Console.WriteLine($"Employee collection serialized!!!");
            }
            Console.WriteLine($"Press any key to Desrialize Employee collection");
            Console.ReadKey();
            using(FileStream fileStream = new FileStream("employees.xml", FileMode.OpenOrCreate))
            {
                List<Employee> newEmployees = (List<Employee>)employeesSerializer.Deserialize(fileStream);
                foreach (var item in newEmployees)
                {
                    Console.WriteLine($"Employee Name: {item.FirstName} {item.LastName}\t Employee Age: {item.Age}\n" +
                        $"Conmpany: {item.Company.CompanyName}");
                }
                Console.WriteLine($"Employee collection deserialized...");
            }
            Console.WriteLine($"Press Any key to exit");
            Console.ReadKey();
        }
    }
}
