using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAPSerialization
{
    [Serializable]
    public class Car
    {
        private string markName;
        private string modelName;
        private int horsePower;
        private int modelYear;
        private Manufacturer manufacturer;

        public string MarkName { get => markName; set => markName = value; }
        public string ModelName { get => modelName; set => modelName = value; }
        public int HorsePower
        {
            get => horsePower;
            set
            {
                if (value <= 20 && value >= 1500)
                    throw new Exception(string.Format("Incorrect 'horsePower' value"));
                horsePower = value;
            }
        }
        public int ModelYear { get => modelYear; set => modelYear = value; }
        public Manufacturer Manufacturer { get => manufacturer; set => manufacturer = value; }

        public Car() { }
        public Car(string carMarkName, string carModelName, int carHorsePower, int carModelYear, Manufacturer carManufacturer)
        {
            this.MarkName = carMarkName;
            this.ModelName = carModelName;
            this.HorsePower = carHorsePower;
            this.ModelYear = carModelYear;
            this.Manufacturer = carManufacturer;
        }
    }
}
