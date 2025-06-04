using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Repositories.Interfaces.FavoriteSpace
{
    public class FavoriteSpaceFilter
    {
        public SqlInt32? UserId { get; set; }
        public SqlInt32? SpaceId { get; set; }
    }
}
