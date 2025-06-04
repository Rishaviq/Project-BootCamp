using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.Services.DTOs.FavoriteSpace;

namespace Office.Services.Interfaces.FavoriteSpace
{
    public interface IFavoriteSpaceService
    {
        public Task<GetFavResponse> GetFavoritePerUser(int userId);
        public Task<ChangeFavoriteReponse> AddFavorite(AddFavoriteRequest addFavoriteRequest);
        public Task<ChangeFavoriteReponse> RemoveFavorite(RemoveFavoriteRequest removeFavoriteRequest);
    }
}
