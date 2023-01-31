using Cw8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Cw8.Config
{
    public class PrescriptionMedicamentEFConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.ToTable("Prescription_Medicament");
            builder.HasKey(e => new { e.IdMedicament, e.IdPrescription })
                .HasName("PrescriptionMedicament_Medicament_pk_Prescription_pk");
            builder.Property(e => e.Details).HasMaxLength(100).IsRequired();
            builder.HasOne(e => e.MedicamentNavigation)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(fk => fk.IdMedicament)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("PrescriptionMedicament_Medicament");

            builder.HasOne(e => e.PrescriptionNavigation)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(fk => fk.IdPrescription)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("PrescriptionMedicament_Prescription");

            var prescriptionMedicaments = new List<PrescriptionMedicament>();

            #region Add prescriptionMedicaments
            prescriptionMedicaments.Add(new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 4,
                Dose = 16,
                Details = "tristique in tempus sit"
            });
            prescriptionMedicaments.Add(new PrescriptionMedicament
            {
                IdMedicament = 3,
                IdPrescription = 2,
                Dose = 97,
                Details = "lobortis sapien sapien non mi integer ac"
            });
            prescriptionMedicaments.Add(new PrescriptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 38,
                Details = "morbi vel lectus in quam fringilla rhoncus"
            });

            prescriptionMedicaments.Add(new PrescriptionMedicament
            {
                IdMedicament = 3,
                IdPrescription = 4,
                Dose = 17,
                Details = "in tempus sit amet sem fusce consequat nulla nisl"
            });
            #endregion

            builder.HasData(prescriptionMedicaments);
        }
    }
}
