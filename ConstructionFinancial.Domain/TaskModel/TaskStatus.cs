using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.TaskModel
{
    [Table("TaskStatus")]
    public class TaskStatus : BaseEntity
    {
        [Required]
        public string StatusName { get; set; }
        [Required]
        public string StatusVal { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(StatusName))
            {
                AddBrokenRule(TaskBusinessRule.StatusNameRequired);
            }
            else if (string.IsNullOrEmpty(StatusVal))
            {
                AddBrokenRule(TaskBusinessRule.StatusValRequired);
            }
        }
    }
}
