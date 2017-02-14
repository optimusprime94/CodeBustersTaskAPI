using Microsoft.AspNetCore.Mvc;
using TaskAPI.Entities;

namespace TaskAPI.Controllers
{
    public class TestDummyController: Controller
    {
        private TaskManagementContext _ctx;


        public TestDummyController(TaskManagementContext ctx)
        {
            _ctx = ctx;
        }


        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
