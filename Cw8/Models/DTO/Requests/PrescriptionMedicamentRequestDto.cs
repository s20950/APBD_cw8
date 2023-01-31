namespace Cw8.Models.DTO.Requests
{
    public class PrescriptionMedicamentRequestDto
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
    }
}