using Backend.todoListApp.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.todoListApp.DataAccess.Data
{
    public class TodoListDbContext : DbContext
    {

        public virtual DbSet<Taches>? Tasks { get; set; }

        public TodoListDbContext() {}

        public TodoListDbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder Dbcontextoptions)
        {
            if (!Dbcontextoptions.IsConfigured)
            {
                Dbcontextoptions.UseSqlServer("Server=DESKTOP-1MJGFMU;Database=TodoListDataBase;Trusted_Connection=True;Encrypt=false;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Taches>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titre).IsRequired();
                entity.Property(e => e.Descriptions).IsRequired();
                entity.Property(e => e.Statut).IsRequired();
                entity.Property(e=>e.createAt).IsRequired();
            });

        }
    }
}
