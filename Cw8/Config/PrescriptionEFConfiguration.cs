using Cw8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Cw8.Config
{
    public class PrescriptionEFConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescription");
            builder.HasKey(e => e.IdPrescription)
                .HasName("IdPrescription");
            builder.Property(e => e.IdPrescription)
                .UseIdentityColumn();
            builder.Property(e => e.Date)
                .IsRequired();
            builder.Property(e => e.DueDate)
                .IsRequired();
            builder.HasOne(e => e.PatientNavigation)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(fk => fk.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Patient");
            builder.HasOne(e => e.DoctorNavigation)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(fk => fk.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Doctor");

            var prescriptions = new List<Prescription>();

            #region Add prescriptions
            prescriptions.Add(new Prescription
            {
                IdPrescription = 1,
                Date = DateTime.Parse("31/01/2009"),
                DueDate = DateTime.Parse("10/10/2018"),
                IdPatient = 1,
                IdDoctor = 1
            });
            prescriptions.Add(new Prescription
            {
                IdPrescription = 2,
                Date = DateTime.Parse("30/07/1992"),
                DueDate = DateTime.Parse("24/08/1986"),
                IdPatient = 3,
                IdDoctor = 3
            });
            prescriptions.Add(new Prescription
            {
                IdPrescription = 3,
                Date = DateTime.Parse("19/10/1967"),
                DueDate = DateTime.Parse("29/11/1984"),
                IdPatient = 3,
                IdDoctor = 4
            });

            prescriptions.Add(new Prescription
            {
                IdPrescription = 4,
                Date = DateTime.Parse("24/01/2007"),
                DueDate = DateTime.Parse("14/10/2008"),
                IdPatient = 2,
                IdDoctor = 1
            });
            #endregion

            builder.HasData(prescriptions);
        }
    }
}
