using ClinicAppointmentApi.Models;

namespace ClinicAppointmentApi.Repositories
{
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext _context;

        public PatientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all patients
        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        // Get a patient by ID
        public Patient GetById(int id)
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
        public int Add(Patient patient)
        {
            try
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();
                return patient.PId;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error adding new patient: {ex.Message}");
                throw; // Rethrow the exception if necessary
            }
        }
    }
}
