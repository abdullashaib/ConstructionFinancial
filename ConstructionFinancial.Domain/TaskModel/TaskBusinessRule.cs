using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.TaskModel
{
    public static class TaskBusinessRule
    {
        public static readonly BusinessRule TaskNameRequired = new BusinessRule(Constant.TaskNameRequired);

        public static readonly BusinessRule PriorityRequired = new BusinessRule(Constant.PriorityRequired);

        public static readonly BusinessRule StatusRequired = new BusinessRule(Constant.StatusRequired);

        public static readonly BusinessRule ItemNameRequired = new BusinessRule(Constant.ItemNameRequired);

        public static readonly BusinessRule SatrtDateRequired = new BusinessRule(Constant.StatusRequired);

        public static readonly BusinessRule EndDateRequired = new BusinessRule(Constant.EndDateRequired);

        public static readonly BusinessRule StatusNameRequired = new BusinessRule(Constant.StatusNameRequired);

        public static readonly BusinessRule StatusValRequired = new BusinessRule(Constant.StatusValRequired);

    }
}
