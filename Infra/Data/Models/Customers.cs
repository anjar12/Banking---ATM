using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Models
{
    public class Customers
    {
        [Key]
        public int ID_Customers { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public long RekeningNumber { get; set; }
        public string NIK { get; set; }
        public int PIN { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ApproveBy { get; set; }
        public int ID_Users { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
