using MarshalTask.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarshalTask.data
{
    public class MarshalContext : IdentityDbContext
    {
        IConfiguration config;
        public MarshalContext(IConfiguration _config)
        {
            config = _config;
        }

        public DbSet<Task> tasks { get; set; }  


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("xyz"));
            base.OnConfiguring(optionsBuilder);
        }


    }
}
