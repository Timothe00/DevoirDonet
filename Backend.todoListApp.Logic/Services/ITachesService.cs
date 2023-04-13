using Backend.todoListApp.DataAccess.Model;
using Backend.todoListApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.todoListApp.Logic.Services
{
    public interface ITachesService
    {
        Task<bool> DeleteTaskAsync(int id);
        Task<Taches> UpdateTaskAsync(int id, TachesImg Task);
        Task<Taches> CreateTaskAsync(TachesImg Task);
        Task<Taches?> GetTaskByIdAsync(int id);
        Task<IEnumerable<Taches>> GetAllTasks();
    }
}
