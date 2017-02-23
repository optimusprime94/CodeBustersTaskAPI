using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Models;
using Task = TaskAPI.Entities.Task;
using Assignment = TaskAPI.Entities.Assignment;
using TaskAPI.Entities;

namespace TaskAPI.Services
{
    public interface ITaskManagementRepository
    {
        // Tasks
        IEnumerable<Task> GetAllTasks();
        Task GetTask(int id);
        void CreateTask(Task task);

        // Assignments
        IEnumerable<Assignment> GetAllAssignments();
        void CreateAssignment(Assignment assignment);
        Entities.Assignment GetAssignment(Assignment assignment);

        // Users
        IEnumerable<Entities.User> GetAllUsers();


        Entities.User GetUser(int id);
        void DeleteAssignment(Assignment assignment);
    }
}
