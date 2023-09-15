using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IUnitOfWorks : IDisposable
    {
        IReport report { get; }
        ITransactional transactional { get; }
        IMaster master { get; }
    }
}
