using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.GeneralLedger
{
    public interface ITrialBalanceRepository
    {
        IEnumerable<TrialBalance> GetAll();
        TrialBalance GetById(int id);
        void Insert(TrialBalance entity);
        void Update(TrialBalance entity);
        void Delete(TrialBalance entity);
    }
}
