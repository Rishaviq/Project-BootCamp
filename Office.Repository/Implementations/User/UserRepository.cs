using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Office.Models;
using Office.Repositories.BaseClasses;
using Office.Repositories.Helpers;
using Office.Repositories.Interfaces.User;

namespace Office.Repositories.Implementations.User
{
    public class UserRepository : BaseRepository<Models.User>, IUserRepository
    {
        private readonly string idFieldName= "userId";
        public Task<int> CreateAsync(Models.User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.User> RetrieveAsync(int objectId)
        {
            return RetrieveAsync(idFieldName,objectId);
        }

        public IAsyncEnumerable<Models.User> RetrieveCollectionAsync(UserFilter filter)
        {
            Filter commandFilter = new Filter();
            if (filter.Username is not null) {
            commandFilter.AddCondition("username", filter.Username);
            }
            if (filter.Email is not null) {
            commandFilter.AddCondition("email", filter.Email);
            }
            if (filter.UserId is not null) {
            commandFilter.AddCondition("userId", filter.UserId.Value);
            } 

            return base.RetrieveCollectionAsync(commandFilter);
        }

        public Task<bool> UpdateAsync(int objectId, UserUpdate update)
        {
            throw new NotImplementedException();
        }

        protected override string[] GetColumns()
        {
            return new string[]
            {
                "userId",
                "email",
                "username",
                "password"
            };
        }

        protected override string GetTableName()
        {
            return "Users";
        }

        protected override Models.User MapEntity(SqlDataReader reader)
        {
            return new Models.User
            {
                UserId = Convert.ToInt32(reader["Userid"]),
                Email = Convert.ToString(reader["email"]),
                Username = Convert.ToString(reader["username"]),
                Password = Convert.ToString(reader["password"])
            };
        }
    }
}
