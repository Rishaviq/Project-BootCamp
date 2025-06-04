using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Office.Repositories.BaseClasses;
using Office.Repositories.Helpers;
using Office.Repositories.Interfaces.FavoriteSpace;

namespace Office.Repositories.Implementations.FavoriteSpace
{
    public class FavoriteSpaceRepository : BaseRepository<Models.FavoriteSpace>, IFavoriteSpaceRepository
    {
        private readonly string idFieldName = "id";
        public Task<int> CreateAsync(Models.FavoriteSpace entity)
        {
            return base.CreateAsync(entity, idFieldName);
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            return base.DeleteAsync(idFieldName, objectId);
        }

        public Task<Models.FavoriteSpace> RetrieveAsync(int objectId)
        {
            return base.RetrieveAsync(idFieldName, objectId);
        }

        public IAsyncEnumerable<Models.FavoriteSpace> RetrieveCollectionAsync(FavoriteSpaceFilter filter)
        {
            Filter commandFilter = new Filter();
            if (filter.UserId is not null)
            {
                commandFilter.AddCondition("userId", filter.UserId.Value);
            }
            if (filter.SpaceId is not null)
            {
                commandFilter.AddCondition("spaceId", filter.SpaceId.Value);
            }
            return base.RetrieveCollectionAsync(commandFilter);
        }

        public async Task<bool> UpdateAsync(int objectId, FavotireSpaceUpdate update)
        {
            SqlConnection connection = await ConnectionFactory.CreateConnectionAsync();
            UpdateCommand command = new UpdateCommand(connection, GetTableName(), idFieldName, objectId);
            command.AddSetClause("userId", update.UserId);
            command.AddSetClause("spaceId", update.SpaceId);
            return await command.ExecuteNonQueryAsync() > 0;
        }

        protected override string[] GetColumns()
        {
            return new string[] {
            "id",
            "userId",
            "spaceId",
            };
        }

        protected override string GetTableName()
        {
            return "FavoriteSpaces";
        }

        protected override Models.FavoriteSpace MapEntity(SqlDataReader reader)
        {
            return new Models.FavoriteSpace
            {
                id = Convert.ToInt32(reader["id"]),
                UserId = Convert.ToInt32(reader["userId"]),
                SpaceId = Convert.ToInt32(reader["spaceId"])
            };
        }
    }
}
