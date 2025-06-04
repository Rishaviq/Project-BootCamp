using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult HandleForm(string action,int spaceId)
        {
            if (action == "add")
            {
                return RedirectToAction("Add",new {spaceId= spaceId });
            }
            else {
                return RedirectToAction("Delete", new { spaceId = spaceId });
            }
                
        }

        public ActionResult Add(int spaceId)
        {
            _favoriteSpaceService.AddFavorite()
            return View("Index", "Home");
        }


        public ActionResult Delete(int spaceId)
        {
            return View("Index","Home");
        }

        
    }
}
