using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.Repositories.Interfaces.FavoriteSpace;
using Office.Repositories.Interfaces.Reservation;
using Office.Repositories.Interfaces.User;
using Office.Repositories.Interfaces.WorkSpace;
using Office.Services.DTOs.Reservation;
using Office.Services.Interfaces.Reservation;

namespace Office.Services.Implementations.Reservation
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IFavoriteSpaceRepository _favoriteSpaceRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWorkSpaceRepository _workSpaceRepository;
        public ReservationService(
            IReservationRepository reservationRepository,
            IFavoriteSpaceRepository favoriteSpaceRepository,
            IUserRepository userRepository,
            IWorkSpaceRepository workSpaceRepository)
        {
            _userRepository = userRepository;
            _favoriteSpaceRepository = favoriteSpaceRepository;
            _reservationRepository = reservationRepository;
            _workSpaceRepository = workSpaceRepository;
        }
        public async Task<FastReservationResponse> CreateFastReservation(int UserId)
        {
            try
            {
                List<int> favoriteSpacesId = new List<int>();
                await foreach (var space in _favoriteSpaceRepository.RetrieveCollectionAsync(new FavoriteSpaceFilter { UserId = UserId }))
                {
                    favoriteSpacesId.Add(space.id);
                }

                ReservationFilter reservationFilter = new ReservationFilter { ReservationDate = DateTime.Now.AddDays(1).Date };
                await foreach (var reservation in _reservationRepository.RetrieveCollectionAsync(reservationFilter))
                {
                    if (reservation.UserId == UserId) { return new FastReservationResponse { IsSuccesful = false, Message = "user has already reserved for tomorrow" }; }
                    favoriteSpacesId.Remove(reservation.ReservedSpaceId);

                }
                if (!(favoriteSpacesId.Count < 1))
                {
                    await _reservationRepository.CreateAsync(new Models.Reservation
                    {
                        UserId = UserId,
                        ReservedSpaceId = favoriteSpacesId.FirstOrDefault(),
                        ReservationDate = DateTime.Now.AddDays(1).Date
                    });

                    return new FastReservationResponse { IsSuccesful = true, Message = "Reservation created successfully" };

                }
                else return new FastReservationResponse { IsSuccesful = false, Message = "no available favorite spaces" };
            }
            catch (Exception ex)
            {
                return new FastReservationResponse { IsSuccesful = false, Message = ex.Message };
            }

        }

        public async Task<CreateReserationResponse> CreateReseration(CreateReserationRequest Request)
        {
            try
            {
                if (Request.ReservationDate.Date < DateTime.Now.Date) { return new CreateReserationResponse { IsSuccesful = false, Message = "date already passed" }; }
                if (Request.ReservationDate.Date > DateTime.Now.AddDays(14).Date) { return new CreateReserationResponse { IsSuccesful = false, Message = "cant reserve that far in the future" }; }
                ReservationFilter reservationFilter = new ReservationFilter { ReservationDate = Request.ReservationDate };
                await foreach (var reservation in _reservationRepository.RetrieveCollectionAsync(reservationFilter))
                {
                    if (reservation.UserId == Request.UserId) { return new CreateReserationResponse { IsSuccesful = false, Message = "User already has a reservation on that date" }; }
                }
                await _reservationRepository.CreateAsync(new Models.Reservation
                {
                    UserId = Request.UserId,
                    ReservedSpaceId = Request.SpaceId,
                    ReservationDate = Request.ReservationDate
                });
                return new CreateReserationResponse();
            }
            catch (Exception ex)
            {
                return new CreateReserationResponse { IsSuccesful = false, Message = ex.Message };
            }
        }

        public async Task<GetReservationListResponse> GetAllReservations()
        {
            try
            {
                GetReservationListResponse response = new GetReservationListResponse();
                await foreach (var reservation in _reservationRepository.RetrieveCollectionAsync(new ReservationFilter()))
                {
                    response.Reservations.Add(
                        new ReservationDTO
                        {
                            ReservationId = reservation.ReservationId,
                            UserId = reservation.UserId,
                            ReservedSpaceId = reservation.ReservedSpaceId,
                            ReservationDate = reservation.ReservationDate,
                            UserName = _userRepository.RetrieveAsync(reservation.UserId).Result.Username
                        }
                        );
                }
                return response;
            }
            catch (Exception ex)
            {
                return new GetReservationListResponse { IsSuccesful = false, Message = ex.Message };
            }
        }

        public async Task<GetReservationResponse> GetReservation(int reservationId)
        {
            try
            {
                var reservation = await _reservationRepository.RetrieveAsync(reservationId);
                return new GetReservationResponse
                {
                    Reservation = new ReservationDTO
                    {
                        ReservationId = reservation.ReservationId,
                        UserId = reservation.UserId,
                        ReservedSpaceId = reservation.ReservedSpaceId,
                        ReservationDate = reservation.ReservationDate,
                        UserName = _userRepository.RetrieveAsync(reservation.UserId).Result.Username
                    }
                };
            }
            catch (Exception ex)
            {
                return new GetReservationResponse { IsSuccesful = false, Message = ex.Message };
            }
            }
    }
}
