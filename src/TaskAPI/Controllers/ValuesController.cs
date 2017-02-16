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
    public class ValuesController : Controller
    {
        private ITaskManagementRepository _taskManagementRepository;
        // GET api/values
        public ValuesController(ITaskManagementRepository taskManagementRepository)
        {
            _taskManagementRepository = taskManagementRepository;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            // Return List with tasks data, that was acuired with the taskManagementRepository.
            var alltasks = _taskManagementRepository.GetTasks();
            return Ok(alltasks);

        }

        // GET api/values/5
        [HttpGet("{id}")] //brackets are used when working with params
        public IActionResult GetTask(int id)
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

        // POST api/values
        //[HttpPost]
        //public IActionResult CreateTask(int taskId, [FromBody]TasksCreation newTask)
        //{
        //    if (newTask == null)
        //    {
        //        BadRequest();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        BadRequest(ModelState);
        //    }

        //    // we return a JsonResult where the id matches the id from tasklist.
        //    var task = TasksDataStore.Current.TasksList.FirstOrDefault(t => t.TaskId == taskId);

        //    // Return not found if the task is not found.
        //    if (task == null)
        //    {
        //        return NotFound();
        //    }
        //    // If task is found return ok, with the task.
        //    return Ok(taskId);
        //}

        // PUT api/values/5
        [HttpPost("createnewassignment")]
        public IActionResult CreateNewAssignment([FromBody] AssignmentDto assignmentDto)
        {
            // We are able to access this action, now we should check if the parameters is not null.
            if (assignmentDto == null)
            {
                return BadRequest();
            }

            Assignment assignment = new Assignment
            {
                TaskId = assignmentDto.TaskId,
                UserId = assignmentDto.UserId
            };
            // We also need to check if assignment already exists!
            if (_taskManagementRepository.GetAssignment(assignment) != null)
                return BadRequest();

            // else

            _taskManagementRepository.CreateAssignment(assignment);
            return Ok(200);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
