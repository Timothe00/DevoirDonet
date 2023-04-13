

namespace Backend.todoListApp.DataAccess.Model
{
    public class Taches
    {
        public int Id { get; set; }
        public string? Titre { get; set; }
        public string? Statut { get; set; }
        public string? Descriptions { get; set; }
        public DateTime? createAt { get; set; }
    }
}
