using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionBeauty
{
    public class CompanyInfo
    {
        private string companyName;
        private string companyNumber;
        private string companyContact;

        public string CompanyName 
        {
            get { return companyName; }
            set { companyName = value; } 
        }

        public string CompanyNumber
        {
            get { return companyNumber; }
            set { companyNumber = value; }
        }

        public string CompanyContact
        {
            get { return companyContact; }
            set { companyContact = value; }
        }
    }
}
