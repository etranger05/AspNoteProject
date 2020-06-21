using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNoteCore.MVC.DataContext;
using AspNoteCore.MVC.Models;
using AspNoteCore.MVC.ViewModel;
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
                        return RedirectToAction("LoginSuccess", "Home");
                }

                ModelState.AddModelError(string.Empty, "No user or invalid ID/Password");
            }
            return View(model);
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
