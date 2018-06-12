using ConstructionFinancial.Domain;
using ConstructionFinancial.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Service
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public IEnumerable<Account> GetAllAccount()
        {
            return accountRepository.GetAll();
        }

        public Account GetAccount(int id)
        {
            return accountRepository.GetById(id);
        }

        public void InsertAccount(Account account)
        {
            ThrowExceptionAccountIsInvalid(account);
            try
            {
                accountRepository.Insert(account);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }

        public void UpdateAccount(Account account)
        {
            accountRepository.Update(account);
        }

        public void DeleteAccount(int id)
        {
            Account account = GetAccount(id);
            accountRepository.Delete(account);
        }

        private void ThrowExceptionAccountIsInvalid(Account account)
        {
            IEnumerable<BusinessRule> brokenRules = account.GetBrokenRules();

            if (brokenRules.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("There were problems saving the account group object: ");
                foreach (BusinessRule businessRule in brokenRules)
                {
                    sb.AppendLine(businessRule.RuleDescription);
                }
                throw new Exception(sb.ToString());
            }
        }

    }
}
