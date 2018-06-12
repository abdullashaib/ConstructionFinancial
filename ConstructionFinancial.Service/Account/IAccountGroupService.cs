using ConstructionFinancial.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Service
{
    public interface IAccountGroupService
    {
        IEnumerable<AccountGroup> GetAllAccountGroup();
        AccountGroup GetAccountGroup(int id);
        void InsertAccountGroup(AccountGroup accountGroup);
        void UpdateAccountGroup(AccountGroup accountGroup);
        void DeleteAccountGroup(int id);  
    }
}
