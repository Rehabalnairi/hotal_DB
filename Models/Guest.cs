using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace hotal_DB.Models
{
    
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
