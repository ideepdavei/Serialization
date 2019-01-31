using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student("Thomas", 22, new University("Cambridge ")),
                new Student("Richard", 19, new University("Oxford"))
            };

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using(FileStream fileStream = new FileStream("students.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fileStream, students);
                Console.WriteLine($"Student Collection Serialized");
            }
            Console.WriteLine($"Press any ket to deserialize");
            Console.ReadKey();
            using(FileStream fileStream = new FileStream("students.dat", FileMode.OpenOrCreate))
            {
                List<Student> newStudents = (List<Student>)binaryFormatter.Deserialize(fileStream);
                foreach (var item in newStudents)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine($"Press any key to exit...");
            Console.ReadKey();
        }
    }
}
