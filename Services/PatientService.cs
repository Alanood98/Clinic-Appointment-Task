using ClinicAppointmentApi.Models;
using ClinicAppointmentApi.Repositories;
using ClinicAppointmentApi.Services;

using System.Text.RegularExpressions;

namespace ClinicAppointmentApi.Services
{
    public class PatientService : IPatientServices
    {

        private readonly IPatientRepo _patientRepo;

        public PatientService(IPatientRepo patientRepo)

        {
            // Assign the injected repository instance to the private field
            _patientRepo = patientRepo;
        }

        // Retrieves a list of all patients from the repository
        public List<Patient> GetAllPatients()
        {
            var patient = _patientRepo.GetAll()
                .OrderBy(p => p.PName)          //The patients are sorted alphabetically by their name(PName).
                .ToList();
            if (patient == null || patient.Count == 0)
            {
                throw new InvalidOperationException("No patient found.");
            }
            return patient;
        }

        //Get all patients from the repository by there ID:
        public Patient GetPatientById(int id)
        {
            var patient = _patientRepo.GetById(id);
            if (patient == null)
            {
                throw new KeyNotFoundException("patient not found.");
            }
            return patient;
        }

        public int AddPatient(Patient patient)
        {
            if (string.IsNullOrWhiteSpace(patient.PName))
            {
                throw new ArgumentException("patient name is required.");
            }
            if (patient.Age <= 0)
            {
                throw new ArgumentException("Patient age must be a positive integer.");
            }
            if (!Enum.IsDefined(typeof(Patient.Gen), patient.gender))
            {
                throw new ArgumentException("Invalid gender. Gender must be Male or Female.");
            }
            _patientRepo.Add(patient);

            return patient.PId;


        }

    }
}
