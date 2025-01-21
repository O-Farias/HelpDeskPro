using Microsoft.EntityFrameworkCore;
using HelpDeskPro.Models;

namespace HelpDeskPro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de relacionamento
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Client)
                .WithMany()
                .HasForeignKey(t => t.ClientId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Technician)
                .WithMany()
                .HasForeignKey(t => t.TechnicianId);
        }
    }
}
