﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Office.Services.DTOs.FavoriteSpace;
using Office.Services.Interfaces.FavoriteSpace;
using Office.Web.Attributes;

namespace Office.Web.Controllers
{
    [RequireLogin]
    public class FavoriteSpaceController : Controller
    {
        private readonly IFavoriteSpaceService _favoriteSpaceService;
        public FavoriteSpaceController(IFavoriteSpaceService favoriteSpaceService)
        {
            _favoriteSpaceService = favoriteSpaceService;
        }
        // GET: FavoriteSpaceController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FavoriteSpaceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FavoriteSpaceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FavoriteSpaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleForm(string action, int spaceId)
        {
            if (action == "Add")
            {
                return RedirectToAction("Add", new { spaceId = spaceId });
            }
            else
            {
                return RedirectToAction("Delete", new { spaceId = spaceId });
            }

        }

        public async Task<ActionResult> Add(int spaceId)
        {
            AddFavoriteRequest request = new AddFavoriteRequest
            {
                Space = new FavoriteSpaceDTO
                {
                    SpaceId = spaceId,
                    UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"))
                }

            };
            var response = await _favoriteSpaceService.AddFavorite(request);
            Console.WriteLine(response.IsSuccesful);
            Console.WriteLine(response.Message);
            return RedirectToAction("Index", "Home");
        }


        public async Task<ActionResult> Delete(int spaceId)
        {
            RemoveFavoriteRequest request = new RemoveFavoriteRequest
            {
                Space = new FavoriteSpaceDTO
                {
                    SpaceId = spaceId,
                    UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"))
                }

            };
            var response = await _favoriteSpaceService.RemoveFavorite(request);

            return RedirectToAction("Index", "Home");
        }


    }
}
