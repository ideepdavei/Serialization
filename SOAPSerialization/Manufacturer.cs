using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAPSerialization
{
    [Serializable]
    public class Manufacturer
    {
        private string manufacturerName;
        public string ManufacturerName { get => manufacturerName; set => manufacturerName = value; }

        public Manufacturer() { }
        public Manufacturer(string carManufacturerName)
        {
            this.ManufacturerName = carManufacturerName;
        }
    }
}
