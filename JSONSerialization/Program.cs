using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Provides classes for serializing objects to the JavaScript Object Notation (JSON) and deserializing JSON data to objects
//Install-Package System.Runtime.Serialization.Json -Version 4.3.0
using System.Runtime.Serialization.Json;
namespace JSONSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee("William", "Wilson", 35, new Company("Microsoft")),
                new Employee("Jacob", "Johnson", 28, new Company("Apple")),
                new Employee("Ethan", "Miller", 22, new Company("Facebook")),
                new Employee("Daniel", "Jones", 40, new Company("Google")),
            };

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Employee>));

            using(FileStream fileStream = new FileStream("employees.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fileStream, employees);
                Console.WriteLine($"Employees Collection Serialized!!!");
            }
            Console.WriteLine($"Press eny key to Deserialize Employee Collection");
            Console.ReadKey();

            using(FileStream fileStream = new FileStream("employees.json", FileMode.OpenOrCreate))
            {
                List<Employee> newEmployees = (List<Employee>)jsonSerializer.ReadObject(fileStream);
                foreach (var item in newEmployees)
                {
                    Console.WriteLine($"Employee Name: {item.FirstName} {item.LastName}\tEmployee Age: {item.Age}" +
                        $"\nCompany: {item.Company.CompanyName}");
                }
                Console.WriteLine($"Employee Collection Deserialized!!!");
            }
            Console.WriteLine($"Press any key to exit...");
            Console.ReadKey();
        }
    }
}
