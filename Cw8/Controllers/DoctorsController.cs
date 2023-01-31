using System.Threading.Tasks;
using Cw8.Models.DTO.Requests;
using Cw8.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private IDatabaseService _databaseService;

        public DoctorsController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet("{idDoctor}")]
        public async Task<IActionResult> GetDoctor([FromRoute] int idDoctor)
        {
            var doctorExists = await _databaseService.DoctorExists(idDoctor);
            return doctorExists.StatusCode == 404 ? NotFound(doctorExists.StatusDescription) : Ok(await _databaseService.GetDoctor(idDoctor));
        }

        [HttpPut]
        public async Task<IActionResult> AddNewDoctor([FromBody] DoctorRequestDto doctor)
        {
            var res = await _databaseService.AddDoctor(doctor);
            return res.StatusCode == 200 ? Ok(res.StatusDescription) : BadRequest();
        }

        [HttpPost("{idDoctor}")]
        public async Task<IActionResult> UpdateDoctorData([FromBody] DoctorRequestDto doctor, [FromRoute] int idDoctor)
        {
            var res = await _databaseService.UpdateDoctor(doctor, idDoctor);
            return res.StatusCode == 404 ? NotFound(res.StatusDescription) : Ok(res.StatusDescription);
        }

        [HttpDelete("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int idDoctor)
        {
            var res = await _databaseService.DeleteDoctor(idDoctor);
            return res.StatusCode == 404 ? NotFound(res.StatusDescription) : Ok(res.StatusDescription);
        }
    }
}