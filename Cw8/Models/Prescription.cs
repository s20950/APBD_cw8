using System;
using System.Collections.Generic;

namespace Cw8.Models
{
    public class Prescription
    {
        public Prescription()
        {
            PrescriptionMedicaments = new HashSet<PrescriptionMedicament>();
        }
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
        public virtual Patient PatientNavigation { get; set; }
        public virtual Doctor DoctorNavigation { get; set; }
    }
}