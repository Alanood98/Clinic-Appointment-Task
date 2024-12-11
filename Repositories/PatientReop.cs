using ClinicAppointmentApi.Models;

namespace ClinicAppointmentApi.Repositories
{
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext _context;

        // The ApplicationDbContext is injected via Dependency Injection

        public PatientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all patients
        public IEnumerable<Patient> GetAllPatient()
        {
            return _context.Patients.ToList();
        }

        // Get a patient by ID
        public Patient GetpatientById(int id)
        {
            try
            {
                return _context.Patients.FirstOrDefault(a => a.PId == id);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error retrieving patient with ID {id}: {ex.Message}");
                throw; // Rethrow the exception if necessary
            }
        }

        // Add a new patient
        public int Addpatient(Patient patient)
        {
            try
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();
                return patient.PId;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error adding new patient: {ex.Message}");
                throw; 
            }
        }
    }
}
