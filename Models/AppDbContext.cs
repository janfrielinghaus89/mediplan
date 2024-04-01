using Microsoft.EntityFrameworkCore;
using MEDIplan.Models;

namespace MEDIplan.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet properties for each model
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Dosage> Dosages { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Ward> Wards { get; set; } = default!;
    }
}
    