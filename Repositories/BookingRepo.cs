using ClinicAppointmentApi.Models;
using ClinicAppointmentApi.Repositories;
using ClinicAppointmentApi;

namespace ClinicAppointmentApi.Repositories
{
    public class BookingRepo : IBookingRepo
    {
        private readonly ApplicationDbContext _context;

        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAllAppointments()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetAppointmentById(int id)
        {
            try
            {
                return _context.Bookings.FirstOrDefault(a => a.BookingId == id);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error retrieving Appointment by ID {id}: {ex.Message}");
                throw; // Rethrow the exception if necessary
            }
        }

        public int AddAppointments(Booking booking)
        {
            try
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return booking.PId;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error while adding new Appointment : {ex.Message}");
                throw;
            }
        }


        public Booking ViewAppointmentByClinic(int clinicID)
        {
            try
            {
                return _context.Bookings.FirstOrDefault(b => b.CId == clinicID);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error while retrieving Appointment by clinic : {ex.Message}");
                throw;
            }

        }



        public Booking ViewAppointmentByPatient(int patientID)
        {
            try
            {
                return _context.Bookings.FirstOrDefault(p => p.PId == patientID);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error while retrieving Appointment by Patient : {ex.Message}");
                throw;
            }
        }

    }
}