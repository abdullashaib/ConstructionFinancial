using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Account
{
    public static class AccountBusinessRule
    {
        public static readonly BusinessRule AccountNameRequired = new BusinessRule(Constant.AccountNumberRequired);

        public static readonly BusinessRule GroupNameRequired = new BusinessRule(Constant.GroupNameRequired);
    }
}
