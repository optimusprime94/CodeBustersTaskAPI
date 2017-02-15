using System;
using System.Collections.Generic;
using System.Linq;
using TaskAPI.Entities;

namespace TaskAPI
{
    public static class TaskManagementContextSeed
    {
        public static void EnsureSeedDataForContext(this TaskManagementContext context)
        {
            //If the tasks are already added => return
            if (context.Tasks.Any())
            {
                return;
            }

            //Otherwise we create the seed and add it to database.
            var tasklist = new List<Task>()
            {
                new Task
                {
                    Title = "Website",
                    Requirements = "Communicate with the web api and display tasks",
                    BeginDateTime = DateTime.Today.ToString(),
                    DeadlineDateTime = new DateTime(2017, 6, 10).ToString()

                },
                new Task
                {
                    Title = "Windows Universal App",
                    Requirements = "Communicate with the web api and display tasks",
                    BeginDateTime = DateTime.Today.ToString(),
                    DeadlineDateTime = new DateTime(2017, 3, 13).ToString()

                },
                new Task
                {
                    Title = "Wep API",
                    Requirements = "Create the API",
                    BeginDateTime = DateTime.Today.ToString(),
                    DeadlineDateTime = new DateTime(2018, 6, 10).ToString()

                }
            };

            var userlist = new List<User>()
            {
                new User
                {
                    FirstName = "Elvir",
                    LastName = "Dzeko",
                },
                new User
                {
                    FirstName = "Nick",
                    LastName = "Dragonslayer",
                },
                new User
                {
                    FirstName = "Markus",
                    LastName = "Carlsson",
                }
            };

            context.Tasks.AddRange(tasklist); // tracks the entities
            context.Users.AddRange(userlist);
            context.SaveChanges();

        }
    }
}
