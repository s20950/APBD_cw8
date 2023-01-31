namespace Cw8.Models.DTO.Responses
{
    public class DoctorResponseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IdDoctor { get; internal set; }
    }
}