using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.Services.DTOs.Workspace;

namespace Office.Services.Interfaces.WorkSpace
{
    public interface IWorkSpaceService
    {
        public Task<GetWorkspaceListResponse> GetAllWorkspaces();
        public Task<GetWorkspaceResponse> GetWorkspaceById(int workspaceId);
        public Task<GetWorkspaceListResponse> GetFreeSpaces(DateTime date);
    }
}
