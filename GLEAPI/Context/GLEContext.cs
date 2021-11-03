
using GLE.Models;
using Microsoft.EntityFrameworkCore;

namespace GLE.Context
{
    public class GLEContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
        public GLEContext(DbContextOptions<GLEContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<RoutineSchedule> RoutineSchedules { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Routine> Routines { get; set; }
    }
}
