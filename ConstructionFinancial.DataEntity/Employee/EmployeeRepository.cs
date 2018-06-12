using ConstructionFinancial.DataEntity.Context;
using ConstructionFinancial.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.DataEntity.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CFDBContext context;

        public EmployeeRepository(CFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Domain.Employees.Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Employees.Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Domain.Employees.Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
