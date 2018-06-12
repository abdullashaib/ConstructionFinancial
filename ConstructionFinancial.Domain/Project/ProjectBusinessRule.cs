using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Project
{
    public static class ProjectBusinessRule
    {
        public static readonly BusinessRule ProjectNameRequired = new BusinessRule(Constant.ProjectNameRequired);

        public static readonly BusinessRule TypeName = new BusinessRule(Constant.ProjectTypeRequired);
    }
}
