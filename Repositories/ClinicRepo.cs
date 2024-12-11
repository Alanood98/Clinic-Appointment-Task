using ClinicAppointmentApi.Models;
using ClinicAppointmentApi.Repositories;
using ClinicAppointmentApi;


namespace ClinicAppointmentApi.Repositories
{
    public class ClinicRepo : IClinicReop
    {
        private readonly ApplicationDbContext _context;

        public ClinicRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Clinic> GetAllClinic()
        {
            return _context.Clinics.ToList();
        }

        public Clinic GetClinicById(int id)
        {
            try
            {
                return _context.Clinics.FirstOrDefault(a => a.CId == id);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error retrieving Clinic with ID {id}: {ex.Message}");
                throw; // Rethrow the exception if necessary
            }
        }

        public string AddClinic(Clinic clinic)
        {
            try
            {
                _context.Clinics.Add(clinic);
                _context.SaveChanges();
                return clinic.Specialization.ToString();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error adding new clinic: {ex.Message}");
                throw; // Rethrow the exception if necessary
            }

        }
    }
}