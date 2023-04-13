using Backend.todoListApp.DataAccess.Data;
using Backend.todoListApp.DataAccess.Model;
using Backend.todoListApp.Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.todoListApp.Logic.Services
{
    public class TachesService : ITachesService
    {
        private TodoListDbContext _todoListDbContext;

        public TachesService(TodoListDbContext _databaseContext)
        {
            _todoListDbContext = _databaseContext;
        }

        public async Task<IEnumerable<Taches>> GetAllTasks()
        {
            List<Taches> taches = _todoListDbContext.Tasks.Select(task=> new Taches()
            {
                Id= task.Id,
                Titre= task.Titre,
                Descriptions= task.Descriptions,
                Statut= task.Statut,
                createAt= task.createAt,
            }).ToList();
            return await Task.FromResult(taches);

        }



        public async Task<Taches?> GetTaskByIdAsync(int id)
        {
            Taches? TaskById = await _todoListDbContext.Tasks.FindAsync(id);
            if (TaskById == null)
            {
                return null;
            }

            return TaskById;
        }


        public async Task<Taches> CreateTaskAsync(TachesImg Task)
        {
            Taches Taskk = new Taches()
            { 
                Titre = Task.Titre,
                Descriptions= Task.Descriptions,
                Statut= Task.Statut,
                createAt = Task.createAt,
            };
             await _todoListDbContext.Tasks.AddAsync(Taskk);
             await _todoListDbContext.SaveChangesAsync();

            return Taskk;
        }


        public async Task<Taches> UpdateTaskAsync(int id, TachesImg Task)
        {
            var TaskToUpdate = await _todoListDbContext.Tasks.FindAsync(id);

            if (TaskToUpdate == null)
            {
                return null;
            }
            TaskToUpdate.Titre = Task.Titre;
            TaskToUpdate.Descriptions = Task.Descriptions;
            TaskToUpdate.Statut = Task.Statut;
            TaskToUpdate.createAt = Task.createAt;
            await _todoListDbContext.SaveChangesAsync();
            return TaskToUpdate;
        }



        public async Task<bool> DeleteTaskAsync(int id)
        {
            var tasck = await GetTaskByIdAsync(id);
            if (tasck == null)
                return false;
            _todoListDbContext.Remove(tasck);
            await _todoListDbContext.SaveChangesAsync();
            return true;
        }


    }
}
