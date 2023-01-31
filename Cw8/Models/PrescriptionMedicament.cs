namespace Cw8.Models
{
    public class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
        public virtual Prescription PrescriptionNavigation { get; set; }
        public virtual Medicament MedicamentNavigation { get; set; }
    }
}