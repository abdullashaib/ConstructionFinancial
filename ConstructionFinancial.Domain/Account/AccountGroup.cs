using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Account
{
    [Table("AccountGroup")]
    public class AccountGroup : BaseEntity
    {

        [Required]
        public string GroupName { get; set; }

        [Required]
        public int GroupNumber { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual IEnumerable<Account> Accounts { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(GroupName))
            {
                AddBrokenRule(AccountBusinessRule.GroupNameRequired);
            }
        }
    }
}
