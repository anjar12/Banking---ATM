using Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IMaster
    {
        Task<Tuple<bool, Result, ResultValue<View_Credentials>>> Login(PostData<Login> postData);
        Task<Tuple<bool, Result,ResultValue<List<View_Customers>>>> Get_Customer(PostData<Abstract> postData);

    }
}
