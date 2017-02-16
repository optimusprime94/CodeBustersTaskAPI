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
        public List<TaskDto> TasksList { get; set; }


        public TasksDataStore()
        {
            TasksList = new List<TaskDto>()
           {
               new TaskDto {
                   TaskId = 1,
                   BeginDateTime = "22-04-17",
                   DeadlineDateTime = "27-05-17",
                   Requirements = "etwrtet",
                   Title = "Application"
               },
               new TaskDto {
                   TaskId = 2,
                   BeginDateTime = "22-04-17",
                   DeadlineDateTime = "24-06-17",
                   Requirements = "Create the webbsite",
                   Title = "Webbsite"}
           };
        }
    }
}
