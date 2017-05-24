using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOsanceng.Model
{
    class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public string TelNum { get; set; }
        public int CustomerLevel { get; set; }
    }
}
