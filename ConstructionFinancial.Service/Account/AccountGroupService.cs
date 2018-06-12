using ConstructionFinancial.Domain;
using ConstructionFinancial.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Service
{
    public class AccountGroupService : IAccountGroupService
    {
        private IAccountGroupRepository accountGroupRepository;

        public AccountGroupService(IAccountGroupRepository accountGroupRepository)
        {
            this.accountGroupRepository = accountGroupRepository;
        }
        public IEnumerable<AccountGroup> GetAllAccountGroup()
        {
            return accountGroupRepository.GetAll();
        }

        public AccountGroup GetAccountGroup(int id)
        {
            return accountGroupRepository.GetById(id);
        }

        public void InsertAccountGroup(AccountGroup accountGroup)
        {
            ThrowExceptionAccountGroupIsInvalid(accountGroup);
            try
            {
                accountGroupRepository.Insert(accountGroup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }

        public void UpdateAccountGroup(AccountGroup accountGroup)
        {
            accountGroupRepository.Update(accountGroup);
        }

        public void DeleteAccountGroup(int id)
        {
            AccountGroup group = accountGroupRepository.GetById(id);
            accountGroupRepository.Delete(group);
        }

        // This function checks if any of theviolation of business rules
        private void ThrowExceptionAccountGroupIsInvalid(AccountGroup accountGroup)
        {
            IEnumerable<BusinessRule> brokenRules = accountGroup.GetBrokenRules();

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
