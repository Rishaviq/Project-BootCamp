using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Services.DTOs.Reservation
{
    public class ReservationDTO
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ReservedSpaceId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
    }
}
