using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.Services.DTOs.Reservation;

namespace Office.Services.Interfaces.Reservation
{
    public interface IReservationService
    {
        public Task<GetReservationResponse> GetReservation(int reservationId);
        public Task<GetReservationListResponse> GetAllReservations();
        public Task<CreateReserationResponse> CreateReseration(CreateReserationRequest createReserationRequest);
        public Task<FastReservationResponse> CreateFastReservation(int userId);
        public Task<GetReservationListResponse> GetAllReservationsPerUser(int userId);
    }
}
