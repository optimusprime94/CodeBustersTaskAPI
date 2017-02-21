using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private ITaskManagementRepository _taskManagementRepository;
        // GET api/values
        public UsersController(ITaskManagementRepository taskManagementRepository)
        {
            _taskManagementRepository = taskManagementRepository;
        }


        // GET: api/users
        [HttpGet]
        public IActionResult Get()
        {
            //Returns a list with all users, that are acuired with the taskManagementRepository.
            var allUsers = _taskManagementRepository.GetAllUsers();
            return Ok(allUsers);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_taskManagementRepository.GetUser(id));
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

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
