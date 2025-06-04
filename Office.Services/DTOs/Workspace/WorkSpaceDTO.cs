using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Services.DTOs.Workspace
{
    public class WorkSpaceDTO
    {
        public int spaceId { get; set; }
        public int SpaceLocationFloor { get; set; }
        public required string SpaceLocationZone { get; set; }


    }
}
