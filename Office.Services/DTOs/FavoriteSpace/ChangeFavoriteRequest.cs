using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Services.DTOs.FavoriteSpace
{
    public class ChangeFavoriteRequest
    {
        public ChangeFavoriteRequest() {
            favoriteSpaces = new FavoriteSpaceDTO[3];
        }
        public FavoriteSpaceDTO[] favoriteSpaces { get; set; }
        public int UserId { get; set; }
    }
}
