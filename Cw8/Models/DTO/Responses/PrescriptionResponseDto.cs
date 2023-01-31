using System;
using System.Collections.Generic;

namespace Cw8.Models.DTO.Responses
{
    public class PrescriptionResponseDto
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public PatientResponseDto Patient { get; set; }
        public DoctorResponseDto Doctor { get; set; }
        public ICollection<MedicamentResponseDto> Medicaments { get; set; }
    }
}