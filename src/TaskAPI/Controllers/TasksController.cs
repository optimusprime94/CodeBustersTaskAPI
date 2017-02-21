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
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // we return a IActonResult where the id matches the id from tasklist.
            var task = TasksDataStore.Current.TasksList.FirstOrDefault(t => t.TaskId == id);
            // if the task is not found.
            if (task == null)
            {
                return NotFound();
            }
            // If task is found return ok, with the task.
            return Ok(task);
        }

        // POST api/tasks/create
        [HttpPost("create")]
        public IActionResult Post([FromBody] TaskCreationDto taskDto)
        {
            // We are able to access this action, now we should check if the parameters is not null.
            if (taskDto == null)
            {
                return BadRequest();
            }
            // else successfully create
            Task task = new Task
            {
                BeginDateTime = taskDto.BeginDateTime,
                DeadlineDateTime = taskDto.DeadlineDateTime,
                Title = taskDto.Title,
                Requirements = taskDto.Requirements
            };

            _taskManagementRepository.CreateTask(task);
            return Ok(200);
        }


        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
