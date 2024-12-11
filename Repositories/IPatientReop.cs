using ClinicAppointmentApi.Models;


namespace ClinicAppointmentApi.Repositories
{
    public interface IPatientRepo
    {
        int Add(Patient patient);
        IEnumerable<Patient> GetAll();
        Patient GetById(int id);
    }
}
