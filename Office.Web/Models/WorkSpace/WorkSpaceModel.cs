namespace Office.Web.Models.WorkSpace
{
    public class WorkSpaceModel
    {
        public int SpaceId { get; set; }
        public int SpaceLocationFloor { get; set; }
        public required string SpaceLocationZone { get; set; }
    }
}
