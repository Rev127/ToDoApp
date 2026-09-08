using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Data.Context
{
    public class ToDoAppContext : DbContext
    {
        public ToDoAppContext(DbContextOptions<ToDoAppContext> options) : base(options)
        {
        }
        public DbSet<Models.Task> Tasks { get; set; } = null!;
        public DbSet<Models.User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Models.Task>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Models.Task>()
                .Property(t => t.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            modelBuilder.Entity<Models.Task>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
