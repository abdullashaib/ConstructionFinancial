using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Project
{
    [Table("ProjectType")]
    public class ProjectType : BaseEntity
    {
        [Required]
        public string TypeNmae { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(TypeNmae))
            {
                AddBrokenRule(ProjectBusinessRule.TypeName);
            }
        }
    }
}
