using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Models
{
    public class Transactions
    {
        [Key]
        public int ID { get; set; }

        public int ID_Customers { get; set; }

        public int ID_TransactionType { get; set; }

        public decimal Nominal { get; set; }

        public DateTime CreatedTime { get; set; }

    }
}
