using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Models
{
    public class View_Customers
    {
        public string ID_Customers { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIK { get; set; }
        public int PIN { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class View_Credentials
    {
        public string ID_Customers { get; set; }
    }


}
