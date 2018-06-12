using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionFinancial.Domain.Enum;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.Employees
{
    [Table("Employee")]
    public class Employee : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Role RoleId { get; set; }

        
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                AddBrokenRule(EmployeeBusinessRule.FirstNameRequired);
            }
        }
    }
}
