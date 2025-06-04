using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Services.DTOs.Workspace
{
    public class GetWorkspaceListResponse : ResponseDTO
    {
        public GetWorkspaceListResponse()
        {
            WorkSpaces= new List<WorkSpaceDTO>();
        }
        public List<WorkSpaceDTO> WorkSpaces { get; set; }
    }
}
