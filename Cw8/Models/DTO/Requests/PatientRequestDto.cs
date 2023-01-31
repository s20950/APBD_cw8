using System;

namespace Cw8.Models.DTO.Requests
{
    public class PatientRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}