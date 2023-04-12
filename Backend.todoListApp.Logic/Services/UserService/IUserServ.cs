using Backend.todoListApp.DataAccess.Model;
using Backend.todoListApp.Logic.ModelsImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.todoListApp.Logic.Services.UserService
{
    public interface IUserServ
    {
        Task<IEnumerable<Users>> GetUsersAsync();
        Task<Users> GetUserByIdAsync(int id);
        Task<Users> CreateUserAsync(ImgUsers User);
        Task<Users> UpdateUserAsync(ImgUsers User);
        bool DeleteUserAsync(int id);
    }
}
