using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.Repositories.BaseClasses;

namespace Office.Repositories.Interfaces.FavoriteSpace
{
    public interface IFavoriteSpaceRepository : IBaseRepository<Models.FavoriteSpace, FavoriteSpaceFilter, FavotireSpaceUpdate>
    {
    }
}
