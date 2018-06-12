using ConstructionFinancial.DataEntity.Context;
using ConstructionFinancial.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.DataEntity.Employees
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CFDBContext context;

        public RoleRepository(CFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return context.Roles.ToList();
        }

        public Role GetById(int id)
        {
            return context.Roles.FirstOrDefault(r => r.Id == id);
        }

        public void Insert(Role entity)
        {
            context.Roles.Add(entity);
            context.SaveChanges();
        }

        public void Update(Role entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Role entity)
        {
            Role role = GetById(entity.Id);
            context.Roles.Remove(role);
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
