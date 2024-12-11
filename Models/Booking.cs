using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Security.Cryptography;
using ClinicAppointmentApi.Models;
using ClinicAppointmentApi.Models;

namespace ClinicAppointmentApi.Models
{
    [PrimaryKey(nameof(CId), nameof(PId), nameof(BookingId))]
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        public DateTime? Date { get; set; }
        public int SlotNumber { get; set; }


        [ForeignKey("patient")]
        public int PId { get; set; }

        [JsonIgnore]
        public virtual Patient patient { get; set; }

        [ForeignKey("clinic")]
        public int CId { get; set; }

        [JsonIgnore]
        public virtual Clinic clinic { get; set; }
    }
}
