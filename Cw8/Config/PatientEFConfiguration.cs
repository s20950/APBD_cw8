using Cw8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Cw8.Config
{
    public class PatientEFConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");
            builder.HasKey(e => e.IdPatient)
                .HasName("IdPatient");
            builder.Property(e => e.IdPatient).UseIdentityColumn();
            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Birthdate).HasMaxLength(100).IsRequired();

            var patients = new List<Patient>();

            #region AddPatients
            patients.Add(new Patient
            {
                IdPatient = 1,
                FirstName = "Cointon",
                LastName = "Gierck",
                Birthdate = DateTime.Parse("10/06/1967")
            });
            patients.Add(new Patient
            {
                IdPatient = 2,
                FirstName = "Carson",
                LastName = "Ishak",
                Birthdate = DateTime.Parse("09/05/1972")
            });
            patients.Add(new Patient
            {
                IdPatient = 3,
                FirstName = "Farah",
                LastName = "Carletto",
                Birthdate = DateTime.Parse("15/02/1993")
            });
            #endregion

            builder.HasData(patients);
        }
    }
}