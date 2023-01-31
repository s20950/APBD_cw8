using System.Threading.Tasks;
using Cw8.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private IDatabaseService _databaseService;

        public PrescriptionController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet("{idPrescription}")]
        public async Task<IActionResult> GetPrescription([FromRoute]int idPrescription)
        {
            var prescriptioExists = await _databaseService.PrescriptionExists(idPrescription);
            return prescriptioExists.StatusCode == 404 ? NotFound(prescriptioExists.StatusDescription) : Ok(await _databaseService.GetPrescription(idPrescription));
        }
    }
}