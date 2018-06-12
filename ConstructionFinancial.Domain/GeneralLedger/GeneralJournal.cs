using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.GeneralLedger
{
    [Table("GeneralJournal")]
    public class GeneralJournal : BaseEntity
    {
        [Required]
        public DateTime EntryDate { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        public string Description { get; set; }
        [Required]
        public string PostingReference { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public bool IsPosted { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        
        protected override void Validate()
        {
            if (EntryDate != DateTime.MinValue)
            {
                AddBrokenRule(GeneralLedgerBusinessRule.EntryDateRequired);
            }
        }
    }
}
