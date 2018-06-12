using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Account
{
    public interface IAccountGroupRepository
    {
        IEnumerable<AccountGroup> GetAll();
        AccountGroup GetById(int id);
        void Insert(AccountGroup entity);
        void Update(AccountGroup entity);
        void Delete(AccountGroup entity);
        
    }
}
