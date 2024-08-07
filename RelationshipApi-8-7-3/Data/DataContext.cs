using Microsoft.EntityFrameworkCore;
using RelationshipApi_8_7_3.Models;

namespace RelationshipApi_8_7_3.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1-to-M Customer-Car
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Car)
                .WithOne(car => car.Customer)
                .HasForeignKey(car => car.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // M-to-M Car-Make
            modelBuilder.Entity<CarMake>()
                .HasKey(cm => new { cm.CarId, cm.MakeId });

            modelBuilder.Entity<CarMake>()
                .HasOne(cm => cm.Car)
                .WithMany(car => car.CarMake)
                .HasForeignKey(cm => cm.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarMake>()
                .HasOne(cm => cm.Make)
                .WithMany(make => make.CarMake)
                .HasForeignKey(cm => cm.MakeId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
