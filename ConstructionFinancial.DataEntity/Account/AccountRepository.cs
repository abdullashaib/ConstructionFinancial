using ConstructionFinancial.DataEntity.Context;
using ConstructionFinancial.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.DataEntity
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CFDBContext context;

        public AccountRepository(CFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Account> GetAll()
        {
            return context.Accounts.ToList();
        }

        public Account GetById(int id)
        {
            return context.Accounts.SingleOrDefault(a => a.Id == id);
        }

        public void Insert(Account entity)
        {
            // Check for the submitted GroupId to get the right account number group
            if (entity.GroupId == 1)
            {
                // Get the Account Number to be used
                var a = context.Assets.SqlQuery("Select Id FROM Asset");
                entity.AccountNumber = Convert.ToInt32(a);

                context.Accounts.Add(entity);
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("INSERT INTO Asset (Id, AssetAccount, AddedDate) Values("+ entity.AccountNumber +", "+ entity.AccountName +","+ DateTime.Now +")");
            }
        }

        public void Update(Account entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            //Account accountToUpdate = GetById(entity.Id);
        }

        public void Delete(Account entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            Account accountToDelete = GetById(entity.Id);
            context.Accounts.Remove(accountToDelete);
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
