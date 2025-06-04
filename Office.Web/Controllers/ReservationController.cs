using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using Office.Repositories.Interfaces.FavoriteSpace;
using Office.Services.Interfaces.Reservation;
using Office.Web.Attributes;
using Office.Web.Models.WorkSpace;
using Office.Services.Interfaces.WorkSpace;
using Office.Services.Implementations.WorkSpace;
using Office.Services.Interfaces.FavoriteSpace;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Office.Services.DTOs.Reservation;

namespace Office.Web.Controllers
{
    [RequireLogin]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly Office.Services.Interfaces.WorkSpace.IWorkSpaceService _workspaceService;
        private readonly IFavoriteSpaceService _favoriteSpaceService;
        public ReservationController(IReservationService reservationService, Office.Services.Interfaces.WorkSpace.IWorkSpaceService workspace, IFavoriteSpaceService favoriteSpaceRepository)
        {
            _favoriteSpaceService = favoriteSpaceRepository;
            _workspaceService = workspace;
            _reservationService = reservationService;
        }




        public async Task<ActionResult> Create()
        {
            SpaceReservationListModel model = new SpaceReservationListModel();
            var response = await _workspaceService.GetAllWorkspaces();
            foreach (var space in response.WorkSpaces)
            {
                model.Spaces.Add(new WorkSpaceModel
                {
                    SpaceId = space.spaceId,
                    SpaceLocationFloor = space.SpaceLocationFloor,
                    SpaceLocationZone = space.SpaceLocationZone,
                });
            }

            var favorites = await _favoriteSpaceService.GetFavoritePerUser(Convert.ToInt32(HttpContext.Session.GetInt32("UserId")));
            foreach (var space in model.Spaces)
            {
                for (int i = 0; i < favorites.FavoriteSpaces.Count(); i++)
                {
                    if (space.SpaceId == favorites.FavoriteSpaces[i].SpaceId)
                    {
                        model.favoriteSpaces.Add(space);
                    }
                }
            }

            return View(model);
        }


        public async Task<ActionResult> ChooseDate(int id)
        {
            return View(id);
        }
        [HttpPost]

        public async Task<ActionResult> Create(int id, DateTime date)
        {
            CreateReserationRequest request = new CreateReserationRequest
            {
                UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId")),
                ReservationDate=date,
                SpaceId=id
            };
            var response = await _reservationService.CreateReseration(request);
            Console.WriteLine(response.IsSuccesful);
            Console.WriteLine(response.Message);

            return RedirectToAction("Index", "Home");
        }





        public async Task<ActionResult> QuickCreate()
        {
            var response = await _reservationService.CreateFastReservation(Convert.ToInt32(HttpContext.Session.GetInt32("UserId")));
            Console.WriteLine(response.IsSuccesful);
            Console.WriteLine(response.Message);
            return RedirectToAction("Index", "Home");
        }


    }
}
