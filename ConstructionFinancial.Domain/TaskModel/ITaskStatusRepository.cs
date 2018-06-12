using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.Domain.TaskModel
{
    public interface ITaskStatusRepository
    {
        IEnumerable<TaskStatus> GetAll();
        TaskStatus GetById(int id);
        void Insert(TaskStatus entity);
        void Update(TaskStatus entity);
        void Delete(TaskStatus entity);
    }
}
