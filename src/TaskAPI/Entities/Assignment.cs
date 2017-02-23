


namespace TaskAPI.Entities
{
    public class Assignment
    {
        /* Foreign Key pointing to TaskId */
        public int TaskId { get; set; }
        public Task Task { get; set; }

        /* Foreign Key pointing to UserId */


        public int UserId { get; set; }
        public User User { get; set; }
    }
}
