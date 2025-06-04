using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Services.DTOs.FavoriteSpace
{
    public class GetFavResponse : ResponseDTO
    {
        public GetFavResponse()
        {
            FavoriteSpaces = new List<FavoriteSpaceDTO>();
        }
        public List<FavoriteSpaceDTO> FavoriteSpaces { get; set; }
    }
}
