using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class UserController : Controller
    {
        User ur = new User();
        UserDAL UDAL = new UserDAL();
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(IFormCollection form)
        {
            string EmailId = form["EmailId"].ToString();
            string Password = form["Password"].ToString();
            ur.Email= form["Emaild"];
            ur.Password = form["Password"];
            User u=UDAL.Varify(EmailId);

            if (Password == u.Password)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(IFormCollection form)
        {
            ur.Name = form["Name"].ToString();
            ur.Email = form["Emailid"].ToString();
            ur.Password = form["Password"].ToString();
            int res = UDAL.Register(ur);
            if (res == 1)
                return RedirectToAction("SignIn");
            else
                return View();
        }

    }
}
