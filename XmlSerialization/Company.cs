using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSerialization
{
    [Serializable]
    public class Company
    {
        public string CompanyName { get; set; }

        public Company() { } //Default constructor
        public Company(string companyName)
        {
            this.CompanyName = companyName;
        }
    }
}
