using ClinicAppointmentApi.Models;
using ClinicAppointmentApi.Repositories;
using ClinicAppointmentApi.Services;

using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ClinicAppointmentApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _bookingRepo;
        private readonly IPatientServices _patientService;
        private readonly IClinicService _clinicService;

        // Constructor to initialize BookingService with required dependencies
        public BookingService(IBookingRepo bookingRepo, IPatientServices patientService, IClinicService clinicService)
        {
            _bookingRepo = bookingRepo;
            _patientService = patientService;
            _clinicService = clinicService;
        }

        // Retrieve all appointments
        public List<Booking> GetAllAppointments()
        {
            var appointments = _bookingRepo.GetAllAppointments()
                .OrderBy(p => p.BookingId)
                .ToList();

            if (appointments == null || appointments.Count == 0)
            {
                throw new InvalidOperationException("No appointments found.");
            }

            return appointments;
        }

        // View appointment details for a specific clinic by clinic ID
        public Booking ViewAppointmentByClinic(int clinicID)
        {
            return _bookingRepo.ViewAppointmentByClinic(clinicID);
        }

        // View appointment details for a specific patient by patient ID
        public Booking ViewAppointmentByPatient(int patientID)
        {
            return _bookingRepo.ViewAppointmentByPatient(patientID);
        }

        // Add a new appointment
        public int AddAppointment(string patientName, int clinicId, DateTime date, int slotNumber)
        {
            // Step 1: Validate patient using the service
            var patient = _patientService.GetAllPatients()
                .FirstOrDefault(p => p.PName.Equals(patientName, StringComparison.OrdinalIgnoreCase));
            if (patient == null)
            {
                throw new ArgumentException($"Patient with name '{patientName}' does not exist.");
            }

            // Step 2: Validate clinic using the service
            var clinic = _clinicService.GetClinicById(clinicId);
            if (clinic == null)
            {
                throw new ArgumentException($"Clinic with ID '{clinicId}' does not exist.");
            }

            // Step 3: Check slot availability using the repository
            var existingBookings = _bookingRepo.GetAllAppointments()
                .Where(b => b.CId == clinicId && b.Date.HasValue && b.Date.Value.Date == date.Date)
                .ToList();

            // Validate slot number
            if (slotNumber < 1 || slotNumber > clinic.NumberOfSlots)
            {
                throw new ArgumentException($"Slot number must be between 1 and {clinic.NumberOfSlots}.");
            }

            // Check if the slot is already booked
            if (existingBookings.Any(b => b.SlotNumber == slotNumber))
            {
                throw new InvalidOperationException($"Slot {slotNumber} is already booked for the selected date.");
            }

            // Step 4: Add booking using the repository
            var booking = new Booking
            {
                PId = patient.PId,
                CId = clinic.CId,
                Date = date,
                SlotNumber = slotNumber
            };

            return _bookingRepo.AddAppointments(booking);
        }
    }
}
