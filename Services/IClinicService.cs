using ClinicAppointmentApi.Models;


namespace ClinicAppointmentApi.Services
{
    public interface IClinicService
    {
        Clinic GetClinicById(int id);
        List<Clinic> GetAllClinics();
        string AddClinic(Clinic clinic);

    }
}