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
        IEnumerable<Entities.Task> ITaskManagementRepository.GetAllTasks()
        {
            // return a task list that is ordered after task id.
            return _context.Tasks.OrderBy(o => o.TaskId).ToList();
        }
        IEnumerable<Entities.User> ITaskManagementRepository.GetAllUsers()
        {
            // return a task list that is ordered after task id.
            return _context.Users.OrderBy(u => u.UserId).ToList();
        }

        IEnumerable<Entities.Assignment> ITaskManagementRepository.GetAllAssignments()
        {
            // return an assignment list that is ordered after task id.
            return _context.Assignments.OrderBy(a => a.TaskId).ToList();
        }

        Entities.Assignment ITaskManagementRepository.GetAssignment(Assignment assignment)
        {
            // Return the found assignment
            return _context.Assignments.Find(assignment.TaskId, assignment.UserId);
        }

        void ITaskManagementRepository.CreateAssignment(Assignment assignment)
        {
            //Assignment assignment = new Assignment
            //{
            //    TaskId = taskId,
            //    UserId = userId
            //};
            _context.Add(assignment);
            _context.SaveChanges();
        }
    }
}
