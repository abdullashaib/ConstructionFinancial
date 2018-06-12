using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Account
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        Account GetById(int id);
        void Insert(Account entity);
        void Update(Account entity);
        void Delete(Account entity);
        
    }
}
