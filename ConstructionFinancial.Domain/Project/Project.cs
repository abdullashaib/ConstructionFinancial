using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using ConstructionFinancial.Domain.Employees;

namespace ConstructionFinancial.Domain.Project
{
    [Table("Project")]
    public class Project : BaseEntity
    {
        [Required]
        public string ProjectName { get; set; }
        [Required]
        [MaxLength(70)]
        public string ProjectManager { get; set; }
        public int SubProjectOf { get; set; }
        [Required]
        public int ProjectTypeId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IEnumerable<Task> Tasks { get; set; }

        [ForeignKey("ProjectTypeId")]
        public virtual ProjectType ProjectType { get; set; }

       
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(ProjectName))
            {
                AddBrokenRule(ProjectBusinessRule.ProjectNameRequired);
            }
        }

    }
}
