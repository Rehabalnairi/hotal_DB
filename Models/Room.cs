
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
        public int roomNumber { get; set; }
        [Required]
        public string roomType { get; set; }
        [Required,]
        [Range(10,1000)]
        public double price { get; set; }
        [Required]
        public bool isAvailable { get; set; }

    }
}
