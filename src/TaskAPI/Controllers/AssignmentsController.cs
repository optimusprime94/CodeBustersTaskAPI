using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Entities;
using TaskAPI.Models;
using TaskAPI.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    public class AssignmentsController : Controller
    {
        private ITaskManagementRepository _taskManagementRepository;

        public AssignmentsController(ITaskManagementRepository taskManagementRepository)
        {
            _taskManagementRepository = taskManagementRepository;
        }

        // GET: api/assignments
        [HttpGet]
        public IActionResult Get()
        {
            // returns all assignments with an 200 ok message.
            return Ok(_taskManagementRepository.GetAllAssignments());
        }


        // GET api/assignments/5
        [HttpGet("{taskId}/{userId}")]
        public IActionResult Get(int taskId, int userId)
        {
            //Assignment assignment = _taskManagementRepository.GetAllAssignments().FirstOrDefault(a => a.TaskId == taskId && a.UserId == userId);
            Assignment assignment = _taskManagementRepository.GetAssignment(taskId, userId);
            if (assignment == null)
            {
                return NotFound();
            }

            AssignmentDto dto = new AssignmentDto
            {
                TaskId = assignment.TaskId,
                UserId = assignment.UserId
            };
            return Ok(dto);
        }

        // POST api/assignments/create
        [HttpPost("create")]
        public IActionResult Post([FromBody] AssignmentDto assignmentDto)
        {
            // We are able to access this action, now we should check if the parameters is not null.
            if (assignmentDto == null)
            {
                return BadRequest();
            }
            var task = _taskManagementRepository.GetAllTasks().FirstOrDefault(t => t.TaskId == assignmentDto.TaskId);
            var user = _taskManagementRepository.GetAllUsers().FirstOrDefault(t => t.UserId == assignmentDto.UserId);
            if((user == null) || (task == null)) {
                return BadRequest();
            }
            Assignment assignment = new Assignment
            {
                TaskId = assignmentDto.TaskId,
                UserId = assignmentDto.UserId
            };
            // We also need to check if assignment already exists!
            if (_taskManagementRepository.GetAssignment(assignment) != null)
            {
                return BadRequest();
            }
            // else successfully create
            _taskManagementRepository.CreateAssignment(assignment);
            return Ok(200);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{taskId}/{userId}")]
        public void Delete(int taskId, int userId)
        {
            //Assignment assignment = _taskManagementRepository.GetAllAssignments().FirstOrDefault(a => a.TaskId == taskId && a.UserId == userId);
            Assignment assignment = _taskManagementRepository.GetAssignment(taskId, userId);
            _taskManagementRepository.DeleteAssignment(assignment);
        }
    }
}
