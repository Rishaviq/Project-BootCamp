using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Office.Repositories.BaseClasses;
using Office.Repositories.Helpers;
using Office.Repositories.Interfaces.Reservation;

namespace Office.Repositories.Implementations.Reservation
{
    public class ReservationRepository : BaseRepository<Models.Reservation>, IReservationRepository
    {
        private readonly string idFieldName = "reservationId";
        public Task<int> CreateAsync(Models.Reservation entity)
        {
            return base.CreateAsync(entity, idFieldName);
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Reservation> RetrieveAsync(int objectId)
        {
            return base.RetrieveAsync(idFieldName, objectId);
        }

        public IAsyncEnumerable<Models.Reservation> RetrieveCollectionAsync(ReservationFilter filter)
        {
            Filter commandFilter = new Filter();
            if (filter.UserId is not null)
            {
                commandFilter.AddCondition("userId", filter.UserId.Value);
            }
            if (filter.ReservedSpaceId is not null)
            {
                commandFilter.AddCondition("reservedSpaceId", filter.ReservedSpaceId.Value);
            }
            if (filter.ReservationId is not null)
            {
                commandFilter.AddCondition("reservationId", filter.ReservationId.Value);
            }
            if (filter.ReservationDate is not null)
            {
                commandFilter.AddCondition("reservationDate", filter.ReservationDate.Value);
            }
            return base.RetrieveCollectionAsync(commandFilter);
        }

        public Task<bool> UpdateAsync(int objectId, ReservationUpdate update)
        {
            throw new NotImplementedException();
        }

        protected override string[] GetColumns()
        {
            return new string[]
            {
                "reservationId",
                "userId",
                "reservedSpaceId",
                "reservationDate"
               
            };
        }

        protected override string GetTableName()
        {
            return "Reservations";
        }

        protected override Models.Reservation MapEntity(SqlDataReader reader)
        {
            return new Models.Reservation
            {
                ReservationId = Convert.ToInt32(reader["reservationId"]),
                UserId = Convert.ToInt32(reader["userid"]),
                ReservedSpaceId = Convert.ToInt32(reader["reservedSpaceId"]),
                ReservationDate = Convert.ToDateTime(reader["reservationDate"])
            };
        }
    }
}
