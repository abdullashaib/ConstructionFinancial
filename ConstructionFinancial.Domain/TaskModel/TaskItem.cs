using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionFinancial.Domain.Enum;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.TaskModel
{
    [Table("WorkItem")]
    public class TaskItem : BaseEntity
    {
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime SatrtDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        public virtual WorkTask Task { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(ItemName))
            {
                AddBrokenRule(TaskBusinessRule.ItemNameRequired);
            }
        }
    }
}
