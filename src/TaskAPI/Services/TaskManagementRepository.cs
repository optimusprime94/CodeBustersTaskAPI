using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Entities;

namespace TaskAPI.Services
{
    /* This Repository let's us communicate with our database context, get data and store data. We use an interface
       that let's us change the underlying implementation without affecting the clients to this interface. */
    public class TaskManagementRepository : ITaskManagementRepository
    {
        // We store our database context for access
        private TaskManagementContext _context;

        public TaskManagementRepository(TaskManagementContext context)
        {
            _context = context;
        }
        IEnumerable<Entities.Task> ITaskManagementRepository.GetTasks()
        {
            // return a task list that is ordered after task id.
            return _context.Tasks.OrderBy(o => o.TaskId).ToList();
        }
        IEnumerable<Entities.Assignment> ITaskManagementRepository.GetAssignment()
        {
            // return a task list that is ordered after task id.
            return _context.Assignments.OrderBy(a => a.TaskId).ToList();
        }
    }
}
