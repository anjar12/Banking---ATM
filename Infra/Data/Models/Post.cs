using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Models
{
    #region Transactional

    #region BackOffice
    public class Insert_Customer
    {
        public string FirstName { get; set; }
        public long RekeningNumber { get; set; }

        public string LastName { get; set; }
        public int PIN { get; set; }

        public string NIK { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string ApproveBy { get; set; }

        public string ID_Users { get; set; }

    }
    public class Update_Customer
    {
        public int ID_Customer { get; set; }
        public int PIN { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int ID_Users { get; set; }
    }
    public class Delete_Customer
    {
        public int ID_Customer { get; set; }
    }
    #endregion BackOffice
    #region Customer
    public class Customer_Transact
    {
        public string ID_Customer { get; set; }
        public decimal Nominal { get; set; }
        public string ID_TransactionType { get; set; }
    }
    #endregion Customer

    #endregion Transactional

    #region Master
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    #endregion Master
}
