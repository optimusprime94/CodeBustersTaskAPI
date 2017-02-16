using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = TaskAPI.Entities.Task;
using Assignment = TaskAPI.Entities.Assignment;

namespace TaskAPI.Services
{
    public interface ITaskManagementRepository
    {
        IEnumerable<Task> GetTasks();
        IEnumerable<Assignment> GetAllAssignments();
        void CreateAssignment(Assignment assignment);
        Entities.Assignment GetAssignment(Assignment assignment);
    }
}
