using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerialization
{
    [Serializable]
    public class University
    {
        public string UniversityName { get; set; }
        public University() { }
        public University(string universityName)
        {
            this.UniversityName = universityName;
        }
    }
}
