using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Account
{
    [Table("Account")]
    public class Account : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string AccountName { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        public string Description { get; set; }
        [Required]
        public int GroupId { get; set; }
        public DataType AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("GroupId")]
        public virtual AccountGroup AccountGroup { get; set; }

        protected override void Validate()
        {
            if (AccountNumber.Equals(""))
            {
                AddBrokenRule(AccountBusinessRule.AccountNameRequired);
            }
        }
    }
}
