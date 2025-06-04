using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Office.Services.DTOs.User;
using Office.Services.Interfaces.User;


namespace Office.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
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
        
        public async Task<ActionResult> Login(string username,string password)
        {
            LoginRequest request = new LoginRequest { Password = password, Username = username };
            var response = await _userService.Login(request);
            if (response.IsSuccesful ) {
            HttpContext.Session.SetInt32("UserId", response.UserId);
            HttpContext.Session.SetString("Name", username);
            }

           return RedirectToAction("Index","Home");
        }

        
    }
}
