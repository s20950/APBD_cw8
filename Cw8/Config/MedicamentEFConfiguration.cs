using Cw8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Cw8.Config
{
    public class MedicamentEFConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.ToTable("Medicament");
            builder.HasKey(e => e.IdMedicament).HasName("IdMedicament");
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Type).HasMaxLength(100).IsRequired();

            var medicaments = new List<Medicament>();

            #region Add medicaments
            medicaments.Add(new Medicament
            {
                IdMedicament = 1,
                Name = "hydromorphone hydrochloride",
                Description = "faucibus cursus urna ut tellus nulla ut erat id mauris",
                Type = "id"
            });
            medicaments.Add(new Medicament
            {
                IdMedicament = 2,
                Name = "Avobenzone, Homosalate, Octisalate, Octocrylene, and Oxybenzone",
                Description = "sed augue aliquam",
                Type = "etiam"
            });
            medicaments.Add(new Medicament
            {
                IdMedicament = 3,
                Name = "OXYGEN",
                Description = "vel dapibus at diam nam",
                Type = "venenatis"
            });
            #endregion

            builder.HasData(medicaments);
        }
    }
}