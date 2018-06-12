using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Account
{
    [Table("Asset")]
    public class Asset : BaseEntity
    {
        [Required]
        public string AssetAccount { get; set; }
        public DateTime AddedDate { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(AssetAccount))
            {
                AddBrokenRule(AccountBusinessRule.AccountNameRequired);
            }
        }
    }
}
