using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskAPI.Entities
{
    public class Assignment
    {
        /* Foreign Key pointing to TaskId */
        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public Task Task { get; set; }

        /* Foreign Key pointing to UserId */

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
