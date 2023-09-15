using Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ITransactional
    {
        Task<Tuple<bool, Result>>Insert_Customer(PostData<Insert_Customer> postData);
        Task<Tuple<bool, Result>> Update_Customer(PostData<Update_Customer> postData);
        Task<Tuple<bool, Result>> Delete_Customer(PostData<Delete_Customer> postData);

    }
}
