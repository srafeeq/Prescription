using Microsoft.EntityFrameworkCore;
using System;

namespace PrescriptionApp.Models
{
    public class PrescriptionContext : DbContext
    {
        public PrescriptionContext(DbContextOptions<PrescriptionContext> options)
            : base(options) { }

        public DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    PrescriptionId = 1,
                    MedicationName = "Atorvastatin",
                    FillStatus = "New",
                    Cost = 19.99,
                    RequestTime = DateTime.Now
                },
                new Prescription
                {
                    PrescriptionId = 2,
                    MedicationName = "Metformin",
                    FillStatus = "Filled",
                    Cost = 15.75,
                    RequestTime = DateTime.Now
                }
            );
        }
    }
}

