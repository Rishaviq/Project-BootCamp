using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Services.DTOs.User;
using Shopping.Services.Interfaces.UserService;

namespace Shopping.Web.Controllers
{
    public class LoginController : Controller
    {
        IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

       

        // POST: LoginController/Create
        [HttpPost]
        
        public async Task<ActionResult> Login(string pNumber)
        {
           GetUserResponse response=await _userService.GetUserByPhone(pNumber);
            if (response.IsSuccesful && response.User!=null) {
            HttpContext.Session.SetString("UserId", response.User.UserId.ToString());
            HttpContext.Session.SetString("Name", response.User.Name);
            }

           return RedirectToAction("Index","Home");
        }

        
    }
}
