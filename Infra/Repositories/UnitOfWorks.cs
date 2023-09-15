using Infra.Data.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly BankingDB _context;
        public IMaster master { get; private set; }
        public IReport report { get; private set; }
        public ITransactional transactional { get; private set; }
        public UnitOfWorks(
            BankingDB context,
            ITransactional Transactional,
            IMaster Master,
            IReport Report
            )
        {
            _context = context;
            master = Master;
            report = Report;
            transactional = Transactional;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
