using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Employees
{
    [Table("Role")]
    public class Role : BaseEntity
    {
        [Required]
        public string RoleName { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(RoleName))
            {
                AddBrokenRule(EmployeeBusinessRule.RoleNameRequired);
            }
        }
    }
}
