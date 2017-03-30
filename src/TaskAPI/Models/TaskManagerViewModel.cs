using System;
using System.Collections.Generic;
using System.Linq;
using TaskAPI.Entities;
using TaskAPI.Models;

namespace TaskManagerWebsite.Model
{
    public class TaskManagerViewModel
    {
        public IEnumerable<Task> Tasklist { get; set; }

        public IEnumerable<User> Userlist { get; set; }

        public IEnumerable<Assignment> Assignmentlist { get; set; }

    }
}
