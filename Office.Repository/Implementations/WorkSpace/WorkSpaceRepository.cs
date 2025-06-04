using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Office.Repositories.BaseClasses;
using Office.Repositories.Interfaces.WorkSpace;

namespace Office.Repositories.Implementations.WorkSpace
{
    public class WorkSpaceRepository : BaseRepository<Models.WorkSpace>, IWorkSpaceRepository
    {
        private readonly string idFieldName = "spaceId";
        public Task<int> CreateAsync(Models.WorkSpace entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.WorkSpace> RetrieveAsync(int objectId)
        {
            return base.RetrieveAsync(idFieldName, objectId);
        }

        public IAsyncEnumerable<Models.WorkSpace> RetrieveCollectionAsync(WorkSpaceFilter filter)
        {
            return base.RetrieveCollectionAsync(new Helpers.Filter());
        }

        public Task<bool> UpdateAsync(int objectId, WorkSpaceUpdate update)
        {
            throw new NotImplementedException();
        }

        protected override string[] GetColumns()
        {
            return new string[]
            {
                "spaceId",
                "spaceLocationFloor",
                "spacelocationZone",
                "hasMonitor",
                "hasDockStation",
                "hasWindow",
                "hasPrinter"
            };
        }

        protected override string GetTableName()
        {
            return "WorkSpaces";
        }

        protected override Models.WorkSpace MapEntity(SqlDataReader reader)
        {
            return new Models.WorkSpace
            {
                spaceId = Convert.ToInt32(reader["spaceId"]),
                SpaceLocationFloor = Convert.ToInt32(reader["spaceLocationFloor"]),
                SpaceLocationZone = Convert.ToString(reader["spaceLocationZone"]),
                HasMonitor =Convert.ToBoolean(reader.GetOrdinal("hasMonitor")),
                hasDockStation = Convert.ToBoolean(reader.GetOrdinal("hasDockStation")),
                HasWindow = Convert.ToBoolean(reader.GetOrdinal("hasWindow")),
                HasPrinter = Convert.ToBoolean(reader.GetOrdinal("hasPrinter"))
            };
        }
    }
}
