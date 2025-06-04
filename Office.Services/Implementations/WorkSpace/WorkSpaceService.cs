using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.Repositories.Interfaces.Reservation;
using Office.Repositories.Interfaces.WorkSpace;
using Office.Services.DTOs.Workspace;
using Office.Services.Interfaces.WorkSpace;

namespace Office.Services.Implementations.WorkSpace
{
    public class WorkSpaceService : IWorkSpaceService
    {
        private readonly IWorkSpaceRepository _workSpaceRepository;
        private readonly IReservationRepository _reservationRepository;
        public WorkSpaceService(IWorkSpaceRepository workSpaceRepository, IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _workSpaceRepository = workSpaceRepository;
        }
        public async Task<GetWorkspaceListResponse> GetAllWorkspaces()
        {
            try
            {
                GetWorkspaceListResponse response = new GetWorkspaceListResponse();
                await foreach (var space in _workSpaceRepository.RetrieveCollectionAsync(new WorkSpaceFilter()))
                {
                    response.WorkSpaces.Add(new WorkSpaceDTO
                    {
                        spaceId = space.spaceId,
                        SpaceLocationFloor = space.SpaceLocationFloor,
                        SpaceLocationZone = space.SpaceLocationZone
                    });
                }
                return response;
            }
            catch (Exception ex)
            {
                return new GetWorkspaceListResponse
                {
                    Message = ex.Message,
                    IsSuccesful = false
                };

            }
        }

        public Task<GetWorkspaceListResponse> GetFreeSpaces(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<GetWorkspaceResponse> GetWorkspaceById(int workspaceId)
        {
            try {
            Models.WorkSpace space= await _workSpaceRepository.RetrieveAsync(workspaceId);
                return new GetWorkspaceResponse
                {
                    WorkSpace = new WorkSpaceDTO
                    {
                        spaceId = space.spaceId,
                        SpaceLocationFloor = space.SpaceLocationFloor,
                        SpaceLocationZone = space.SpaceLocationZone
                    }
                };
            }
            catch (Exception ex) {
            return new GetWorkspaceResponse
            {
                Message = ex.Message,
                IsSuccesful = false
            };
            }
        }
    }
}
