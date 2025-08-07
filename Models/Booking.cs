using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotal_DB.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GuestId { get; set; }

        public Guest Guest { get; set; }

        [Required] // ✅ Add this line
        public int RoomId { get; set; } 

        public Room Room { get; set; }

        [Required, Range(10, 90)]
        public int roomNumber { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}