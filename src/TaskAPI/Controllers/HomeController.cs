using System.Net;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Services;
using TaskManagerWebsite.Model;

namespace TaskAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskManagementRepository _taskManagementRepository;
       
        // Constructor
        public HomeController(ITaskManagementRepository taskManagementRepository)
        {
            _taskManagementRepository = taskManagementRepository;
        }
        public IActionResult Index()
        {
            TaskManagerViewModel model = new TaskManagerViewModel
            {
                Assignmentlist = _taskManagementRepository.GetAllAssignments(),
                Tasklist = _taskManagementRepository.GetAllTasks(),
                Userlist = _taskManagementRepository.GetAllUsers()
            };


            /* Finally return the view if successful */
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
