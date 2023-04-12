using Backend.todoListApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.todoListApp.Logic.ModelsImage
{
    public class ImgTache
    {
        public int TaskId { get; set; }
        public string? Titre { get; set; }
        public string? Statut { get; set; }
        public string? Descriptions { get; set; }
        public DateTime? createAt { get; set; }
        public string? Id { get; set; }
    }
}
