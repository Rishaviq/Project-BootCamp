namespace Office.Services.DTOs.Reservation
{
    public class GetReservationResponse : ResponseDTO
    {
       public ReservationDTO? Reservation { get; set; }
    }
}