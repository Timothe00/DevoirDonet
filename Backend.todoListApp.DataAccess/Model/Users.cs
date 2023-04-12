

namespace Backend.todoListApp.DataAccess.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public ICollection<Taches>? Tasks { get; set; }
    }
}
