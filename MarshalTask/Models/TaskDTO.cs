using System.ComponentModel.DataAnnotations;

namespace MarshalTask.Models
{
    public class TaskDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public bool Status { set; get; }

        //public string UserId { get; set; }
    }
}
