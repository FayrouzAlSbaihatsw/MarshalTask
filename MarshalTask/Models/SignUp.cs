using System.ComponentModel.DataAnnotations;

namespace MarshalTask.Models
{
    public class SignUp
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        //public string Age { get; set; }

    }
}
