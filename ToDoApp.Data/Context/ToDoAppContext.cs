using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Data.Context
{
    public class ToDoAppContext : DbContext
    {
        public ToDoAppContext(DbContextOptions<ToDoAppContext> options) : base(options)
        {
        }
        public DbSet<Models.ToDoTask> Tasks { get; set; } = null!;
        public DbSet<Models.User> Users { get; set; } = null!;
        public DbSet<Models.Categories> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Models.Categories>()
                .HasKey(tc => tc.Id);

            modelBuilder.Entity<Models.ToDoTask>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Models.ToDoTask>()
                .Property(t => t.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            modelBuilder.Entity<Models.ToDoTask>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.ToDoTask>()
                .HasOne(t => t.TaskCategories)
                .WithMany(tc => tc.Tasks)
                .HasForeignKey(t => t.TaskCategoriesId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Categories>()
                .HasData(
                    new Models.Categories { Id = 1, Name = "Work" },
                    new Models.Categories { Id = 2, Name = "Personal" },
                    new Models.Categories { Id = 3, Name = "Shopping" },
                    new Models.Categories { Id = 4, Name = "Health" },
                    new Models.Categories { Id = 5, Name = "Finance" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
