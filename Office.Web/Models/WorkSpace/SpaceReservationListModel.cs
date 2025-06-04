namespace Office.Web.Models.WorkSpace
{
    public class SpaceReservationListModel
    {
        public List<WorkSpaceModel> Spaces { get; set; } = new List<WorkSpaceModel>();
        public List<WorkSpaceModel> favoriteSpaces { get; set; } = new List<WorkSpaceModel>();
    }
}
