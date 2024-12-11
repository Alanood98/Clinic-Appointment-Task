using ClinicAppointmentApi.Models;
using ClinicAppointmentApi.Repositories;
using ClinicAppointmentApi.Services;

using System.Text.RegularExpressions;

namespace ClinicAppointmentApi.Services
{
    public class ClinicService : IClinicService
    {

        private readonly IClinicReop _clinicRepo;

        public ClinicService(IClinicReop clinicRepo)
        {
            _clinicRepo = clinicRepo;
        }

        //retrive all clinic
        public List<Clinic> GetAllClinics()
        {
            var clinic = _clinicRepo.GetAllClinic()
                .OrderBy(c => c.Specialization)       //Orders the list of clinics alphabetically by the Specialization property.
                .ToList();     // Converts the result to a List.
            if (clinic == null || clinic.Count == 0)
            {
                throw new InvalidOperationException("No clinic found.");
            }
            return clinic;
        }

        
        public Clinic GetClinicById(int id)
        {
            var clinic = _clinicRepo.GetClinicById(id);
            if (clinic == null)
            {
                throw new KeyNotFoundException("clinic not found.");
            }
            return clinic;
        }

        
    
        public string AddClinic(Clinic clinic)
        {
            if (clinic == null)
            {
                throw new ArgumentException("Invalid clinic details.");
            }

            _clinicRepo.AddClinic(clinic);

            // Return a confirmation message or the specialization name.
            return $"Clinic '{clinic.Specialization}' has been added successfully.";
        }
    }

}

