using ClinicAppointmentApi.Models;

namespace ClinicAppointmentApi.Repositories
{
    public interface IClinicReop
    {
        string AddClinic(Clinic clinic);
        IEnumerable<Clinic> GetAllClinic();
        Clinic GetClinicById(int id);
    }
}
