using Cw8.Config;
using Microsoft.EntityFrameworkCore;

namespace Cw8.Models
{
    public partial class s20950Context : DbContext
    {
        public s20950Context()
        {
        }

        public s20950Context(DbContextOptions<s20950Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorEFConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentEFConfiguration());
            modelBuilder.ApplyConfiguration(new PatientEFConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionEFConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEFConfiguration());
        }

    }
}