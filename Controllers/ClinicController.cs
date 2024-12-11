using Microsoft.AspNetCore.Mvc;
using ClinicAppointmentApi.Models;
using ClinicAppointmentApi.Services;


namespace ClinicAppointmentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinicServices;

        // // This enables dependency injection to access service-layer functionality.
        public ClinicController(IClinicService clinicServices)
        {
            _clinicServices = clinicServices;
        }

        // GET: api/Clinic/GetAllClinics
        [HttpGet("GetAllClinics")]
        public ActionResult<List<Clinic>> GetAll()
        {
            try
            {
                var clinics = _clinicServices.GetAllClinics();
                if (clinics == null)
                    return Ok(clinics);
                else return Ok(clinics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"This error occurred while retrieving all clinic: {ex.Message}");
            }
        }

        // GET: api/Clinic/GetClinicById/{id}
        [HttpGet("GetClinicById/{id}")]
        public ActionResult<Clinic> GetClinicById(int id)
        {
            try
            {
                var clinic = _clinicServices.GetClinicById(id);
                return Ok(clinic);  // Return HTTP 200 
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"This error occurred while git clinic by id: {ex.Message}");
            }
        }


        [HttpPost]
        public IActionResult AddClinic(string specialization, int NumberOfSlots)
        {
            try
            {
                string newClinicId = _clinicServices.AddClinic(new Clinic
                {
                    Specialization = specialization,
                    NumberOfSlots = NumberOfSlots
                });
                return Created(string.Empty, newClinicId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"This error occurred whileadding new clinic: {ex.Message}");
            }
        }
    }
}
