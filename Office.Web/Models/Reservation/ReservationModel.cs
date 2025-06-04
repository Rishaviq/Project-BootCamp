namespace Office.Web.Models.Reservation
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ReservedSpaceId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
    }
}
