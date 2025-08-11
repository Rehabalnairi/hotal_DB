using hotal_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace hotal_DB.Data
{
    public class HotelContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-IV1AER0;Database=HotelDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>()
                .HasMany(g => g.Bookings)
                .WithOne(b => b.Guest)
                .HasForeignKey(b => b.GuestId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Guest)
                .WithMany(g => g.Reviews)
                .HasForeignKey(r => r.GuestId)
                .OnDelete(DeleteBehavior.Restrict);  

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Room)
                .WithMany() 
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Restrict);  
        }
    }
}
