using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Entities;
using TaskAPI.Models;
using Task = TaskAPI.Entities.Task;

namespace TaskAPI.Services
{
    /* This Repository let's us communicate with our database context, get data and store data. We use an interface
       that let's us change the underlying implementation without affecting the clients to this interface. */
    public class TaskManagementRepository : ITaskManagementRepository
    {
        // We store our database context for access
        private readonly TaskManagementContext _context;

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

        User ITaskManagementRepository.GetUser(int id)
        {
            // returns the correct user.       
            return _context.Users.Find(id);
        }

        void ITaskManagementRepository.DeleteUser(User user)
        {
            // Deletes the assignment
            _context.Remove(user);
            _context.SaveChanges();
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
        Entities.Assignment ITaskManagementRepository.GetAssignment(int taskId, int userId)
        {
            // Return the found assignment
            return _context.Assignments.Find(taskId, userId);
        }

        void ITaskManagementRepository.CreateAssignment(Assignment assignment)
        {
            _context.Add(assignment);
            _context.SaveChanges();
        }
        void ITaskManagementRepository.DeleteAssignment(Assignment assignment)
        {
            // Deletes the assignment
            _context.Remove(assignment);
            _context.SaveChanges();
        }

        public Task GetTask(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateTask(Task task)
        {

            _context.Add(task);
            _context.SaveChanges();
        }
        void ITaskManagementRepository.DeleteTask(Task task)
        {
            // Deletes the assignment
            _context.Remove(task);
            _context.SaveChanges();
        }

    }
}
