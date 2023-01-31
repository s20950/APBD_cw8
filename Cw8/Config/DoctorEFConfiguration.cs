using Cw8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Cw8.Config
{
    public class DoctorEFConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");
            builder.HasKey(e => e.IdDoctor)
                .HasName("IdDoctor");
            builder.Property(e => e.IdDoctor).UseIdentityColumn();
            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();

            var doctors = new List<Doctor>();

            #region Add doctors
            doctors.Add(new Doctor
            {
                IdDoctor = 1,
                FirstName = "Hastings",
                LastName = "Pinckney",
                Email = "hpinckney0@google.nl"
            });
            doctors.Add(new Doctor
            {
                IdDoctor = 2,
                FirstName = "Elisha",
                LastName = "Baseke",
                Email = "ebaseke0@geocities.com"
            });
            doctors.Add(new Doctor
            {
                IdDoctor = 3,
                FirstName = "Vincents",
                LastName = "De Matteis",
                Email = "vdematteis1@devhub.com"
            });
            doctors.Add(new Doctor
            {
                IdDoctor = 4,
                FirstName = "Milli",
                LastName = "Harsnipe",
                Email = "mharsnipe2@creativecommons.org"
            });
            #endregion

            builder.HasData(doctors);
        }
    }
}