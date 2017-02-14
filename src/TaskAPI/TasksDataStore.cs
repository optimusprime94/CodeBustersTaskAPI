using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI
{
    public class TasksDataStore
    {
        public static TasksDataStore Current { get; } = new TasksDataStore();
        public List<Tasks> TasksList { get; set; }


        public TasksDataStore()
        {
            TasksList = new List<Tasks>()
           {
               new Tasks {
                   TaskId = 1,
                   BeginDateTime = "22-04-17",
                   DeadlineDateTime = "27-05-17",
                   Requirements = "etwrtet",
                   Title = "Application"
               },
               new Tasks {
                   TaskId = 2,
                   BeginDateTime = "22-04-17",
                   DeadlineDateTime = "24-06-17",
                   Requirements = "Create the webbsite",
                   Title = "Webbsite"}
           };
        }
    }
}
