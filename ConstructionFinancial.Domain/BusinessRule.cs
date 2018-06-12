using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain
{
    public class BusinessRule
    {
        private string _ruleDescription;

        public BusinessRule(string ruleDescription)
        {
            _ruleDescription = ruleDescription;
        }

        public String RuleDescription
        {
            get
            {
                return _ruleDescription;
            }
        }
    }
}
