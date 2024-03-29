﻿// <auto-generated />
using System;
using Cw8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cw8.Migrations
{
    [DbContext(typeof(s20950Context))]
    [Migration("20230131214507_InitialCommit")]
    partial class InitialCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cw8.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor")
                        .HasName("IdDoctor");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "hpinckney0@google.nl",
                            FirstName = "Hastings",
                            LastName = "Pinckney"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "ebaseke0@geocities.com",
                            FirstName = "Elisha",
                            LastName = "Baseke"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "vdematteis1@devhub.com",
                            FirstName = "Vincents",
                            LastName = "De Matteis"
                        },
                        new
                        {
                            IdDoctor = 4,
                            Email = "mharsnipe2@creativecommons.org",
                            FirstName = "Milli",
                            LastName = "Harsnipe"
                        });
                });

            modelBuilder.Entity("Cw8.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament")
                        .HasName("IdMedicament");

                    b.ToTable("Medicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "faucibus cursus urna ut tellus nulla ut erat id mauris",
                            Name = "hydromorphone hydrochloride",
                            Type = "id"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "sed augue aliquam",
                            Name = "Avobenzone, Homosalate, Octisalate, Octocrylene, and Oxybenzone",
                            Type = "etiam"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "vel dapibus at diam nam",
                            Name = "OXYGEN",
                            Type = "venenatis"
                        });
                });

            modelBuilder.Entity("Cw8.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient")
                        .HasName("IdPatient");

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            Birthdate = new DateTime(1967, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Cointon",
                            LastName = "Gierck"
                        },
                        new
                        {
                            IdPatient = 2,
                            Birthdate = new DateTime(1972, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Carson",
                            LastName = "Ishak"
                        },
                        new
                        {
                            IdPatient = 3,
                            Birthdate = new DateTime(1993, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Farah",
                            LastName = "Carletto"
                        });
                });

            modelBuilder.Entity("Cw8.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription")
                        .HasName("IdPrescription");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescription");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2009, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2018, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 1,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(1992, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(1986, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 3,
                            IdPatient = 3
                        },
                        new
                        {
                            IdPrescription = 3,
                            Date = new DateTime(1967, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(1984, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 4,
                            IdPatient = 3
                        },
                        new
                        {
                            IdPrescription = 4,
                            Date = new DateTime(2007, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2008, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 1,
                            IdPatient = 2
                        });
                });

            modelBuilder.Entity("Cw8.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription")
                        .HasName("PrescriptionMedicament_Medicament_pk_Prescription_pk");

                    b.HasIndex("IdPrescription");

                    b.ToTable("Prescription_Medicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 4,
                            Details = "tristique in tempus sit",
                            Dose = 16
                        },
                        new
                        {
                            IdMedicament = 3,
                            IdPrescription = 2,
                            Details = "lobortis sapien sapien non mi integer ac",
                            Dose = 97
                        },
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 1,
                            Details = "morbi vel lectus in quam fringilla rhoncus",
                            Dose = 38
                        },
                        new
                        {
                            IdMedicament = 3,
                            IdPrescription = 4,
                            Details = "in tempus sit amet sem fusce consequat nulla nisl",
                            Dose = 17
                        });
                });

            modelBuilder.Entity("Cw8.Models.Prescription", b =>
                {
                    b.HasOne("Cw8.Models.Doctor", "DoctorNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .HasConstraintName("Prescription_Doctor")
                        .IsRequired();

                    b.HasOne("Cw8.Models.Patient", "PatientNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .HasConstraintName("Prescription_Patient")
                        .IsRequired();

                    b.Navigation("DoctorNavigation");

                    b.Navigation("PatientNavigation");
                });

            modelBuilder.Entity("Cw8.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("Cw8.Models.Medicament", "MedicamentNavigation")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdMedicament")
                        .HasConstraintName("PrescriptionMedicament_Medicament")
                        .IsRequired();

                    b.HasOne("Cw8.Models.Prescription", "PrescriptionNavigation")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .HasConstraintName("PrescriptionMedicament_Prescription")
                        .IsRequired();

                    b.Navigation("MedicamentNavigation");

                    b.Navigation("PrescriptionNavigation");
                });

            modelBuilder.Entity("Cw8.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Cw8.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("Cw8.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Cw8.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
