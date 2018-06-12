using ConstructionFinancial.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ConstructionFinancial.Domain.TaskModel
{
    [Table("Task")]
    public class WorkTask : BaseEntity
    {
        [Required]
        public string TaskName { get; set; }
        public string Description { get; set; }
        [Required]
        public string Priority { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        public decimal BoQAmount { get; set; }
        public decimal BudgetAmount { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IEnumerable<TaskItem> WorkItems { get; set; }

       
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(TaskName))
            {
                AddBrokenRule(TaskBusinessRule.TaskNameRequired);
            }
            else if (string.IsNullOrEmpty(Priority))
            {
                AddBrokenRule(TaskBusinessRule.PriorityRequired);
            }
        }
    }
}
