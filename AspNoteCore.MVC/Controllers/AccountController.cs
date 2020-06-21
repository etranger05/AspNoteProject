using System.Linq;
using AspNoteCore.MVC.DataContext;
using AspNoteCore.MVC.Models;
using AspNoteCore.MVC.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNoteCore.MVC.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// User Login
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (NoteDBContext db = new NoteDBContext())
                {
                    User user = db.Users
                        .FirstOrDefault( u => u.UserId.Equals(model.UserId) && u.UserPassword.Equals(model.UserPassword));

                    if(user != null)
                    {
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY",user.UserNo);
                        return RedirectToAction("LoginSuccess", "Home");
                    }                  
                        
                }

                ModelState.AddModelError(string.Empty, "No user or invalid ID/Password");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            //HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// New User Register
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                using (NoteDBContext db = new NoteDBContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
