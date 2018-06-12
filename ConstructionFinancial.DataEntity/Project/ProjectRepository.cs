using ConstructionFinancial.DataEntity.Context;
using ConstructionFinancial.Domain.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.DataEntity
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly CFDBContext context;

        public ProjectRepository(CFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return context.Projects.ToList();
        }

        public Project GetById(int id)
        {
            return context.Projects.FirstOrDefault(p => p.Id == id);
        }

        public void Insert(Project entity)
        {
            context.Projects.Add(entity);
            context.SaveChanges();
        }

        public void Update(Project entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Project entity)
        {
            Project project = GetById(entity.Id);
            context.Projects.Remove(project);
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
