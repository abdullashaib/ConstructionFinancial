using ConstructionFinancial.DataEntity.Context;
using ConstructionFinancial.Domain.TaskModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.DataEntity.TaskModel
{
    public class TaskStatusRepository : ITaskStatusRepository
    {
        private readonly CFDBContext context;

        public TaskStatusRepository(CFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<ConstructionFinancial.Domain.TaskModel.TaskStatus> GetAll()
        {
            return context.TaskStatus.ToList();
        }

        public ConstructionFinancial.Domain.TaskModel.TaskStatus GetById(int id)
        {
            return context.TaskStatus.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(ConstructionFinancial.Domain.TaskModel.TaskStatus entity)
        {
            context.TaskStatus.Add(entity);
            context.SaveChanges();
        }

        public void Update(ConstructionFinancial.Domain.TaskModel.TaskStatus entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            
        }

        public void Delete(ConstructionFinancial.Domain.TaskModel.TaskStatus entity)
        {
            ConstructionFinancial.Domain.TaskModel.TaskStatus taskStatus = GetById(entity.Id);
            context.TaskStatus.Remove(taskStatus);
            context.SaveChanges();
        }

        private bool TaskStatusExist(int id)
        {
            return context.TaskStatus.Count(t => t.Id == id) > 0;
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
