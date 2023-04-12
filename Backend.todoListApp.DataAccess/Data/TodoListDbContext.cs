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
        public virtual DbSet<Users>? Users { get; set; }
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



            {
                modelBuilder.Entity<Users>()
                    .HasMany(u => u.Tasks)
                    .WithOne(t => t.Users)
                    .HasForeignKey(t => t.Id)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            }

            modelBuilder.Entity<Taches>(o =>
            {
                o.HasKey(pe => pe.TaskId);
                o.HasOne(p => p.Users)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(e => e.TaskId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
