using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    public class Company
    {
        private string companyName;
        public string CompanyName { get => companyName; set => companyName = value; }

        public Company() { }
        public Company(string companyName)
        {
            this.CompanyName = companyName;
        }
    }
}
