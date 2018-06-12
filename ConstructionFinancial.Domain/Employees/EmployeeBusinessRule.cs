using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Employees
{
    public static class EmployeeBusinessRule
    {
        public static readonly BusinessRule FirstNameRequired = new BusinessRule(Constant.FirstNameRequired);

        public static readonly BusinessRule RoleNameRequired = new BusinessRule(Constant.RoleNameRequired);
    }
}
