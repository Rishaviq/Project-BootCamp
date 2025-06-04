using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Repositories.Interfaces.User
{
    public class UserFilter
    {
        public SqlInt32? UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
    }
}
