using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotal_DB.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GestID { get; set; }
        [ForeignKey("GestID")]
        public Guest Guest { get; set; }
        [Required]
        public string Bookingid { get; set; }
        [ForeignKey("Bookingid")]
        public Booking Booking { get; set; }
        [Range(1, 5, ErrorMessage ="Rating must be between 1 and 5")]
        public int Rating { get; set; }
        [MaxLength(500, ErrorMessage = "Comment cannot exceed 500 characters")]
        public string comment { get; set; }
    }
}
