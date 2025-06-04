using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.Repositories.Interfaces.FavoriteSpace;
using Office.Services.DTOs.FavoriteSpace;
using Office.Services.Interfaces.FavoriteSpace;

namespace Office.Services.Implementations.FavoriteSpace
{
    public class FavoriteSpaceService : IFavoriteSpaceService
    {
        private readonly IFavoriteSpaceRepository _favoriteSpaceRepository;
        public FavoriteSpaceService(IFavoriteSpaceRepository favoriteSpaceRepository)
        {
            _favoriteSpaceRepository = favoriteSpaceRepository;
        }

        public async Task<ChangeFavoriteReponse> AddFavorite(AddFavoriteRequest Request)
        {
            try
            {
                var response = await GetFavoritePerUser(Request.Space.UserId);
                if (response.FavoriteSpaces.Count() >= 3)
                {
                    return new ChangeFavoriteReponse { IsSuccesful = false, Message = "User already has 3 favorite spaces" };
                }

                await _favoriteSpaceRepository.CreateAsync(new Models.FavoriteSpace
                {
                    UserId = Request.Space.UserId,
                    SpaceId = Request.Space.SpaceId
                });
                return new ChangeFavoriteReponse();
            }
            catch (Exception ex)
            {
                return new ChangeFavoriteReponse
                {
                    IsSuccesful = false,
                    Message = ex.Message
                };

            }
        }

        /*    public async Task<ChangeFavoriteReponse> ChangeFavoriteSpace(ChangeFavoriteRequest Request)
    {
        try {
        List<Models.FavoriteSpace> favoriteSpaces= new List<Models.FavoriteSpace>();

            await foreach (var space in _favoriteSpaceRepository.RetrieveCollectionAsync(new FavoriteSpaceFilter { UserId = Request.UserId })) {
            favoriteSpaces.Add(space);
            }
            for (int i = 0; i < 3; i++) {


            }

        }

        catch(Exception ex)
        {
            return new ChangeFavoriteReponse
            {
                IsSuccesful = false,
                Message = ex.Message
            };
        }

    }*/

        public async Task<GetFavResponse> GetFavoritePerUser(int userId)
        {
            try
            {
                GetFavResponse response = new GetFavResponse();
                await foreach (var space in _favoriteSpaceRepository.RetrieveCollectionAsync(new FavoriteSpaceFilter { UserId = userId }))
                {
                    response.FavoriteSpaces.Add(new FavoriteSpaceDTO
                    {
                        Id = space.id,
                        UserId = space.UserId,
                        SpaceId = space.SpaceId
                    });

                }
                return response;
            }
            catch (Exception ex)
            {
                return new GetFavResponse
                {
                    IsSuccesful = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ChangeFavoriteReponse> RemoveFavorite(RemoveFavoriteRequest Request)
        {
            try
            {
                await foreach (var space in _favoriteSpaceRepository.RetrieveCollectionAsync(new FavoriteSpaceFilter { UserId = Request.Space.UserId, SpaceId = Request.Space.SpaceId }))
                {
                    await _favoriteSpaceRepository.DeleteAsync(space.id);
                    return new ChangeFavoriteReponse
                    {
                        IsSuccesful = true,
                        Message = "Space removed from favorites successfully."
                    };
                }
                return new ChangeFavoriteReponse
                {
                    IsSuccesful = false,
                    Message = "this user has not favorated this space"
                };


            }
            catch (Exception ex)
            {
                return new ChangeFavoriteReponse
                {
                    IsSuccesful = false,
                    Message = ex.Message
                };
            }

        }
    }
}
