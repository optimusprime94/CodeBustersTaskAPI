using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskAPI;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult GetTasks()
        {
            // Return List with tasks.
            return Ok(TasksDataStore.Current.TasksList);
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
