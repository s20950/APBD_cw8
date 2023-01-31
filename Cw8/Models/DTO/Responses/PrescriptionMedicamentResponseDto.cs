namespace Cw8.Models.DTO.Responses
{
    public class PrescriptionMedicamentResponseDto
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
        public virtual PrescriptionResponseDto IdPrescriptionNavigation { get; set; }
        public virtual Medicament IdMedicamentNavigation { get; set; }
    }
}