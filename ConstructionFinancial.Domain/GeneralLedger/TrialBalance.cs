using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.GeneralLedger
{
    [Table("TrialBalance")]
    public class TrialBalance : BaseEntity
    {
        [Required]
        public int AccountNumber { get; set; }

        [Required]
        public string AccountName { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }


        protected override void Validate()
        {
            if (AccountNumber.Equals(""))
            {
                AddBrokenRule(GeneralLedgerBusinessRule.AccountNumberRequired);
            }
        }
    }
}
