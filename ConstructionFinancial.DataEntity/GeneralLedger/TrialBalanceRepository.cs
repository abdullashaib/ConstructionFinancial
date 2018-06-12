using ConstructionFinancial.DataEntity.Context;
using ConstructionFinancial.Domain.GeneralLedger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.DataEntity
{
    public class TrialBalanceRepository : ITrialBalanceRepository
    {
        private readonly CFDBContext context;

        public TrialBalanceRepository(CFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<TrialBalance> GetAll()
        {
            return context.TrialBalances.ToList();
        }

        public TrialBalance GetById(int id)
        {
            return context.TrialBalances.SingleOrDefault(t => t.Id == id);
        }

        public void Insert(TrialBalance entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.TrialBalances.Add(entity);
            context.SaveChanges();
        }

        public void Update(TrialBalance entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TrialBalance entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            TrialBalance tToDelete = GetById(entity.Id);
            context.TrialBalances.Remove(tToDelete);
            context.SaveChanges();
        }
    }
}
