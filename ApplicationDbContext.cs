namespace AppointmentApprover
{
    using AppointmentApprover.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }
        public DbSet<Rules> Rules { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da tabela Task
            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            });

            // Configuração da tabela TimeEntry
            modelBuilder.Entity<TimeEntry>(entity =>
            {
                entity.ToTable("TimeEntry");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.StartTime).IsRequired();
                entity.Property(e => e.EndTime).IsRequired();
                entity.Property(e => e.Description).IsRequired().HasMaxLength(255);
                entity.Property(e => e.IsApproved);
                entity.HasOne(e => e.Task)
                      .WithMany(t => t.TimeEntries)
                      .HasForeignKey(e => e.TaskId);
            });

            //Configuração da tabela Rules
            modelBuilder.Entity<Rules>(entity =>
            {
                entity.ToTable("Rules");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PropertyName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Condition).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Value).IsRequired().HasMaxLength(255);
            });
        }
    }

}
