namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Models;

    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>()
       .HasKey(ut => new { ut.UserId, ut.TripId });
            modelBuilder.Entity<UserTrip>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTrips)
                .HasForeignKey(ut => ut.UserId);
            modelBuilder.Entity<UserTrip>()
                .HasOne(ut => ut.Trip)
                .WithMany(t => t.UserTrips)
                .HasForeignKey(ut => ut.TripId);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }
    }
}
