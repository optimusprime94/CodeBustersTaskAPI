namespace TaskAPI.Models
{
    public class Tasks
    {
        public int TaskId { get; set; }

        public string BeginDateTime { get; set; }

        public string DeadlineDateTime { get; set; }

        public string Title { get; set; }

        public string Requirements { get; set; }

    }
}
