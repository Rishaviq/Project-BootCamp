using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Repositories.Interfaces.Reservation
{
    public class ReservationFilter
    {
        public SqlInt32? ReservationId { get; set; }
        public SqlInt32? UserId { get; set; }
        public SqlInt32? ReservedSpaceId { get; set; }
        public DateTime? ReservationDate { get; set; }

    }
}
