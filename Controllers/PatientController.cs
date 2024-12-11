using Microsoft.AspNetCore.Mvc;
using ClinicAppointmentApi.Models;
using ClinicAppointmentApi.Services;
using static ClinicAppointmentApi.Models.Patient;

namespace HospitalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices _patientServices;

        public PatientController(IPatientServices patientServices)
        {
            _patientServices = patientServices;
        }

        // GET: api/Patient/GetAllPatient
        //this Function for retrieving all patients:
        [HttpGet("GetAllPatient")]
        public ActionResult<List<Patient>> GetAll()
        {
            try
            {
                var patients = _patientServices.GetAllPatients();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"This error occurred while retrieving all patients: {ex.Message}");
            }
        }

        // GET: api/Patient/GetPatientById/{id}
        [HttpGet("GetPatientById/{id}")]
        public ActionResult<Patient> GetPatientById(int id)
        {
            try
            {
                var patient = _patientServices.GetPatientById(id);
                return Ok(patient);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"This error occurred while Git the patient by id: {ex.Message}");
            }
        }


        //adding new patient with his details:
        [HttpPost("AddPatient")]
        public IActionResult AddPatient(string patientName, int Age, Gen gender)
        {
            try
            {
                if (patientName == null) // Check if the patientName is null to ensure the input is valid
                {
                    return BadRequest("Patient data is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var patient = new Patient
                {
                    PName = patientName,
                    Age = Age,
                    gender = gender
                };
                _patientServices.AddPatient(patient);   // Add all patient details to the database by calling the AddPatient method in the service layer.

                // Return a 201 Created response.
                return CreatedAtAction(nameof(AddPatient), new { id = patient.PId }, patient);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return StatusCode(500, $"This error occurred while adding a new patient: {ex.Message}");
            }



        }
    }
}
