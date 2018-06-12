using ConstructionFinancial.DataEntity.Context;
using ConstructionFinancial.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.DataEntity
{
    public class AccountGroupRepository : IAccountGroupRepository
    {
        private readonly CFDBContext context;

        public AccountGroupRepository(CFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<AccountGroup> GetAll()
        {
            return context.AccountGroups.ToList();
        }

        public AccountGroup GetById(int id)
        {
            return context.AccountGroups.FirstOrDefault(g => g.Id == id);       
        }

        public void Insert(AccountGroup entity)
        {
            
            context.AccountGroups.Add(entity);
            context.SaveChanges();
        }

        public void Update(AccountGroup entity)
        {  
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            
        }

        public void Delete(AccountGroup entity)
        {
            AccountGroup groupToUpdate = GetById(entity.Id);
            context.AccountGroups.Remove(groupToUpdate);
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
