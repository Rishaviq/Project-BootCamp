using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        [Required]
        public int ReservedSpaceId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
