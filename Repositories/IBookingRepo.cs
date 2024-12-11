using ClinicAppointmentApi.Models;


namespace ClinicAppointmentApi.Repositories
{
    public interface IBookingRepo
    {
        int AddAppointments(Booking booking);
        IEnumerable<Booking> GetAllAppointments();
        Booking GetAppointmentById(int id);
        Booking ViewAppointmentByClinic(int clinicID);
        Booking ViewAppointmentByPatient(int patientID);

    }
}
