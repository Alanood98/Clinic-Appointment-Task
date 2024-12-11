using ClinicAppointmentApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicAppointmentApi.Models
{


    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Required]
        public string PName { get; set; }
        [Required]
        public int Age { get; set; }
        public enum Gen { Male, Femal }
        [Required]
        public Gen gender { get; set; }


        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
