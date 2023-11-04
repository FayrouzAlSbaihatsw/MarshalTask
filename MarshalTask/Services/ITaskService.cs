using MarshalTask.Models;

namespace MarshalTask.Services
{
    public interface ITaskService
    {
        public List<TaskDTO> LoadAll();
        public TaskDTO Load(int Id);
        public void Insert(TaskDTO taskDTO);
        public void Update(TaskDTO taskDTO);
        public void Delete(int Id);
        public void ChangeStatus(int Id, bool status);
        public List<TaskDTO> LoadCompleted();
        public List<TaskDTO> LoadActive();


    }
}
