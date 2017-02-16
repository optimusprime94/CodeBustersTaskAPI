using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAPI;
using TaskAPI.Entities;
using TaskAPI.Models;
using TaskAPI.Services;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly ITaskManagementRepository _taskManagementRepository;
     
        // Constructor
        public TasksController(ITaskManagementRepository taskManagementRepository)
        {
            _taskManagementRepository = taskManagementRepository;
        }

        // GET api/tasks
        [HttpGet]
        public IActionResult Get()
        {
            // Return List with tasks data, that was acuired with the taskManagementRepository.
            return Ok(_taskManagementRepository.GetAllTasks());

        }
        // GET api/tasks/5
        [HttpGet("{id}")] //brackets are used when working with params
        public IActionResult Get(int id)
        {
            // we return a JsonResult where the id matches the id from tasklist.
            var task = TasksDataStore.Current.TasksList.FirstOrDefault(t => t.TaskId == id);

            // Return not found if the task is not found.
            if (task == null)
            {
                return NotFound();
            }
            // If task is found return ok, with the task.
            return Ok(task);
        }

        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
