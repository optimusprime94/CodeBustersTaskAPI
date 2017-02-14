using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Models
{
    public class TasksCreation
    {
        [Required]
        public string BeginDateTime { get; set; }

        [Required]
        public string DeadlineDateTime { get; set; }

        [Required(ErrorMessage = "Please, enter a task title!")]
        [MaxLength(30)]
        public string Title { get; set; }

        
        [Required]
        [MaxLength(100)]
        public string Requirements { get; set; }
    }
}
