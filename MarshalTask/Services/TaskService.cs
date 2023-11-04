using MarshalTask.data;
using MarshalTask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace MarshalTask.Services
{
    public class TaskService: ITaskService
    {
        MarshalContext context;
        UserManager<IdentityUser> usermanager;
        SignInManager<IdentityUser> signInManager;

        public TaskService(MarshalContext _context, UserManager<IdentityUser> _usermanager, SignInManager<IdentityUser> _signInManager)
        {
            context = _context;        
            signInManager = _signInManager;
            usermanager = _usermanager;

        }




        public List<TaskDTO> LoadAll()
        {

            List<data.Task> litasks = context.tasks.ToList();

            List<TaskDTO> task = new List<TaskDTO>();

            foreach (data.Task taskk in litasks)
            {
                TaskDTO taskDTO = new TaskDTO();
                taskDTO.Id = taskk.Id;
                taskDTO.Title = taskk.Title;
                taskDTO.Description = taskk.Description;
                taskDTO.DueDate = taskk.DueDate;
                taskDTO.Status = taskk.Status;
                //taskDTO.UserId = taskk.UserId;

                task.Add(taskDTO);
            }

            return task;

        }

        public TaskDTO Load(int Id)    
        {
            data.Task task = context.tasks.Find(Id);

            //CountryDTO countryDTO = new CountryDTO();
            //countryDTO.Id = country.Id;
            //countryDTO.Name = country.Name;

            TaskDTO taskDTO = new TaskDTO()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Status=task.Status, 
                //UserId = task.UserId,   
                
            };

            return taskDTO;
        }

        public void Insert(TaskDTO taskDTO)
        {
            data.Task task = new data.Task();
            task.Title = taskDTO.Title;
            task.Description = taskDTO.Description;
            task.DueDate = taskDTO.DueDate;
            task.Status = true;
            //task.UserId = taskDTO.UserId;

            context.tasks.Add(task);
            context.SaveChanges();

        }


        public void Update(TaskDTO taskDTO)
        {
            //context = new ClinicContext();
            data.Task task;
            task = new data.Task();
            task.Id = taskDTO.Id;
            task.Title = taskDTO.Title;
            task.Description = taskDTO.Description;
            task.DueDate = taskDTO.DueDate;
            task.Status = taskDTO.Status;


            context.tasks.Attach(task);
            context.Entry(task).State = EntityState.Modified;
            context.SaveChanges();

        }

        public void Delete(int Id)
        {
            data.Task task = context.tasks.Find(Id);
            context.tasks.Remove(task);
            context.SaveChanges();
        }


        public void ChangeStatus(int Id, bool status)
        {
            data.Task task = context.tasks.Find(Id);
            task.Status = status;

            context.tasks.Attach(task);
            context.Entry(task).State = EntityState.Modified;
            context.SaveChanges();
        }


        public List<TaskDTO> LoadCompleted()
        {
            List<data.Task> litasks = context.tasks.Where(t => t.Status).ToList();

            List<TaskDTO> task = new List<TaskDTO>();

            foreach (data.Task taskk in litasks)
            {
                TaskDTO taskDTO = new TaskDTO();
                taskDTO.Id = taskk.Id;
                taskDTO.Title = taskk.Title;
                taskDTO.Description = taskk.Description;
                taskDTO.DueDate = taskk.DueDate;
                taskDTO.Status = taskk.Status;
                //taskDTO.UserId = taskk.UserId;

                task.Add(taskDTO);
            }

            return task;
        }


        public List<TaskDTO> LoadActive()
        {
            List<data.Task> litasks = context.tasks.Where(t => !t.Status).ToList();

            List<TaskDTO> task = new List<TaskDTO>();

            foreach (data.Task taskk in litasks)
            {
                TaskDTO taskDTO = new TaskDTO();
                taskDTO.Id = taskk.Id;
                taskDTO.Title = taskk.Title;
                taskDTO.Description = taskk.Description;
                taskDTO.DueDate = taskk.DueDate;
                taskDTO.Status = taskk.Status;
                //taskDTO.UserId = taskk.UserId;

                task.Add(taskDTO);
            }

            return task;
        }



    }
}
