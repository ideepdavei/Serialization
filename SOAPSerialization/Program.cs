using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace SOAPSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Car opel = new Car("Opel", "Astra", 90, 1999, new Manufacturer("General Motors"));
            Car mercedes = new Car("Mercedes-Benz", "C180", 129, 2001, new Manufacturer("Dimler Crysler"));
            Car ford = new Car("Ford", "Mustang", 320, 2007, new Manufacturer("Ford"));
            Car[] cars = new Car[] { opel, mercedes, ford };

            SoapFormatter soapFormatter = new SoapFormatter();

            using(FileStream fileStream = new FileStream("cars.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fileStream, cars);
                Console.WriteLine($"cars Collection serialized in soap format");
            }
            Console.WriteLine($"Press any key to deserialize cars collectin");
            Console.ReadKey();

            using(FileStream fileStream = new FileStream("cars.soap", FileMode.OpenOrCreate))
            {
                Car[] newCars = (Car[])soapFormatter.Deserialize(fileStream);
                foreach (var item in newCars)
                {
                    Console.WriteLine($"{item.Manufacturer.ManufacturerName}\t{item.MarkName}\t{item.ModelName}" +
                        $"\t{item.ModelYear}\t{item.HorsePower}");
                }
            }
            Console.WriteLine($"press any key to exit...");
        }
    }
}
