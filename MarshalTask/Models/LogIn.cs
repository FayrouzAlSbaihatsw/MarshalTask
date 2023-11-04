using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MarshalTask.Models
{
    public class LogIn
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool rememberMe { get; set; }

        public string Id { set; get; }
    }
}
