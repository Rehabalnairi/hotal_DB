
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotal_DB.Models
{
    public class Room
    {
        [Key]
        public int RoomNumber { get; set; }

        [Required]
        public string RoomType { get; set; }

        [Required]
        [Range(10, 1000)]
        public double Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}