using System.Threading.Tasks;
using System.Web.Mvc;
using Cw8.Models.DTO.Requests;
using Cw8.Models.DTO.Responses;

namespace Cw8.Services
{
    public interface IDatabaseService
    {
        public Task<DoctorResponseDto> GetDoctor(int IdDoctor);
        public Task<HttpStatusCodeResult> AddDoctor(DoctorRequestDto IdDoctor);
        public Task<HttpStatusCodeResult> UpdateDoctor(DoctorRequestDto Doctor, int IdDoctor);
        public Task<HttpStatusCodeResult> DeleteDoctor(int IdDoctor);
        public Task<PrescriptionResponseDto> GetPrescription(int IdPrescription);
        public Task<HttpStatusCodeResult> DoctorExists(int IdDoctor);
        public Task<HttpStatusCodeResult> PrescriptionExists(int IdPrescription);
    }
}