using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Account
{
    [Table("Liability")]
    public class Liabilities : BaseEntity
    {
        [Required]
        public string LiabilitiesAccount { get; set; }
        public DateTime AddedDate { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(LiabilitiesAccount))
            {
                AddBrokenRule(AccountBusinessRule.AccountNameRequired);
            }
        }
    }
}
