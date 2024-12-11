using ClinicAppointmentApi.Models;


namespace ClinicAppointmentApi.Services
{
    public interface IPatientServices
    {
        List<Patient> GetAllPatients();
        Patient GetPatientById(int id);
        int AddPatient(Patient patient);

    }
}
