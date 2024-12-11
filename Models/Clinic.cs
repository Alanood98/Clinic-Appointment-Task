using ClinicAppointmentApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicAppointmentApi.Models
{

    public class Clinic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CId { get; set; }

        [Required]
        public string Specialization { get; set; }
        [Required]
        [Range(1, 20, ErrorMessage = "Number of slots must be between 1 and 20.")]
        public int NumberOfSlots { get; set; }


        public virtual ICollection<Booking>? Bookings { get; set; }


    }
}
