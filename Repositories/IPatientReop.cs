using ClinicAppointmentApi.Models;


namespace ClinicAppointmentApi.Repositories
{
    public interface IPatientRepo
    {
        int Addpatient(Patient patient);
        IEnumerable<Patient> GetAllPatient();
        Patient GetpatientById(int id);
    }
}
