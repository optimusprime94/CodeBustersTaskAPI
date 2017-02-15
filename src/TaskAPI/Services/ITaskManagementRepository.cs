using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = TaskAPI.Entities.Task;

namespace TaskAPI.Services
{
    public interface ITaskManagementRepository
    {
        IEnumerable<Task> GetTasks();
    }
}
