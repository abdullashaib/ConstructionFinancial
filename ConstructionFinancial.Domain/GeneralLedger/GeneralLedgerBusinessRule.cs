using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.GeneralLedger
{
    public static class GeneralLedgerBusinessRule
    {
        public static readonly BusinessRule EntryDateRequired = new BusinessRule(Constant.EntryDateRequired);

        public static readonly BusinessRule AccountNumberRequired = new BusinessRule(Constant.AccountNumberRequired);
    }
}
