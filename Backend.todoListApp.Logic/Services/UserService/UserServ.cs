using Backend.todoListApp.DataAccess.Data;
using Backend.todoListApp.DataAccess.Model;
using Backend.todoListApp.Logic.ModelsImage;

namespace Backend.todoListApp.Logic.Services.UserService
{
    public class UserServ : IUserServ
    {
        private TodoListDbContext Dbcontext;
        public UserServ(TodoListDbContext _dataDbContext)
        {
            Dbcontext = _dataDbContext;
        }



        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            var query = from User in Dbcontext.Users
                        join Task in Dbcontext.Tasks
                        on User.Id equals Task.TaskId
                        select new
                        {
                            User.Id,
                            User.UserName,
                            User.Password,
                            User.Tasks
                        };
            return await Task.FromResult(query.Cast<Users>().ToList());
        }



        public async Task<Users> GetUserByIdAsync(int id)
        {
            var query = from user in Dbcontext.Users
                        join task in Dbcontext.Tasks
                        on user.Id equals task.TaskId
                        where user.Id == id
                        select new
                        {
                            user.Id,
                            user.UserName,
                            user.Password,
                            user.Tasks,
                            task.TaskId,
                            task.Titre,
                            task.Descriptions,
                            task.Statut
                        };
            if (query != null)
            {
                return (Users)await Task.FromResult(query);
            }
            else
            {
                throw new Exception("Aucune donnée trouvée.");
            }
        }



         public async Task<Users> CreateUserAsync(ImgUsers User)
         {
             Users user=  new Users();
             if (User != null)
             {
                 user.Id = User.IdUsers;
                 user.UserName = User.UserName;
                 user.Password = User.Password;
                await Dbcontext.Users.AddAsync(user);
                await Dbcontext.SaveChangesAsync();
                return user;
            }
            else
            {
                throw new Exception("creation echouee");
            }
         }



        public async Task<Users> UpdateUserAsync(ImgUsers User)
        {
            var user = Dbcontext.Users.FirstOrDefault(a => a.Id == User.IdUsers);

            if(user != null)
            {
                user.Id = User.IdUsers;
                user.UserName = User.UserName;
                user.Password = User.Password;
                Dbcontext.UpdateRange(user);
                await Dbcontext.SaveChangesAsync();
                return user;
            }
            else
            {
               throw new Exception("Modification echouee.");
            }
        }



        public bool DeleteUserAsync(int id)
        {

            var user = Dbcontext.Users.FirstOrDefault(a => a.Id == id);
            if (user != null)
            {
                user.Id = id;
                Dbcontext.RemoveRange(user);
                Dbcontext.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Echec de suppression");
            }

        }


    }
}
