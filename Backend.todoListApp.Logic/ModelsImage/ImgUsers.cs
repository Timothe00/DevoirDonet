using Backend.todoListApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.todoListApp.Logic.ModelsImage
{
    public class ImgUsers
    {
        public int IdUsers { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
