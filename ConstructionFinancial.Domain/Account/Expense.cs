using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Account
{
    [Table("Expense")]
    public class Expense : BaseEntity
    {
        public string ExpenseAccount { get; set; }
        public DateTime AddedDate { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(ExpenseAccount))
            {
                AddBrokenRule(AccountBusinessRule.AccountNameRequired);
            }
        }
    }
}
