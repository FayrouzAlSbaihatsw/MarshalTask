using MarshalTask.Models;
using MarshalTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarshalTask.Controllers
{
    public class TaskController : Controller
    {
        ITaskService taskService;
        IConfiguration config;

        public TaskController(ITaskService _taskservice , IConfiguration _config) 
        {
            taskService= _taskservice;
            config= _config;
        }


        public IActionResult ToDoList()
        {
            //return View();
            List<TaskDTO> taskitmes = taskService.LoadAll();

            return View("ToDoList", taskitmes);
        }


        public IActionResult EditTask(int Id)
        {
            ViewData["IsEdit"] = true;
            TaskDTO taskDTO = taskService.Load(Id);
            TaskDTO dTO = new TaskDTO();
            dTO = taskDTO;
            taskService.LoadAll();
            return View("NewTask", dTO);

        }
        

        public IActionResult AddNewTask(TaskDTO taskDTO)
        {
            ViewData["IsEdit"] = false;
            taskService.Insert(taskDTO);
            //return View("NewTask");
            List<TaskDTO> taskitmes = taskService.LoadAll();

            return View("ToDoList", taskitmes);
        }

        public IActionResult NewTask()
        {
            ViewData["IsEdit"] = false;
            return View();
        }


        public IActionResult UpdateTask(TaskDTO taskDto)
        {
            ViewData["IsEdit"] = true;

            taskService.Update(taskDto);

            //return View("NewTask", taskDto);
            List<TaskDTO> taskitmes = taskService.LoadAll();

            return View("ToDoList", taskitmes);
        }

        public IActionResult DeleteTask(int Id)
        {
            taskService.Delete(Id);
            List<TaskDTO> taskitmes = taskService.LoadAll();

            return View("ToDoList", taskitmes);

        }

        [HttpPost]
        public IActionResult TaskStatus(int Id, bool status)
        {
            taskService.ChangeStatus(Id, status);
            return View("ToDoList");
        }


        public IActionResult CompletedTasks()
        {
            //return View();
            taskService.LoadAll();
            List<TaskDTO> taskitmes = taskService.LoadCompleted();

            return View("ToDoList", taskitmes);
        }

        public IActionResult ActiveTasks()
        {
            //return View();
            taskService.LoadAll();
            List<TaskDTO> taskitmes = taskService.LoadActive();

            return View("ToDoList", taskitmes);
        }


    }
}
