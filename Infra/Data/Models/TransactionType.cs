using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Models
{
    public class TransactionType
    {
        [Key]
        public int ID_TransactionType { get; set; }

        public string TransactionName { get; set; }

    }
}
