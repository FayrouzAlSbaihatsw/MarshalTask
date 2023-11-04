
using MarshalTask.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace MarshalTask.data
{
    public class Task
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { set; get; }

       
        // Foreign key property
        //public string UserId { get; set; }

        //// Navigation property for the related user
        //public ApplicationUser User { get; set; }



    }
}
