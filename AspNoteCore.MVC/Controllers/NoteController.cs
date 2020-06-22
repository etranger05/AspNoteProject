using System.Collections.Generic;
using System.Linq;
using AspNoteCore.MVC.DataContext;
using AspNoteCore.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNoteCore.MVC.Controllers
{
    public class NoteController : Controller
    {
        /// <summary>
        /// 
        /// Show note List
        /// </summary>
        /// <returns></returns>
        public IActionResult List()
        {
            // Not loged in
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
                return RedirectToAction("Login", "Account");

            List<Note> list;

            using (var db = new NoteDBContext())
            {
                list = db.Notes.ToList();
            }

            return View(list);
        }

        /// <summary>
        /// Add a note
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Note model)
        {
            // Not loged in
            var sessionId = HttpContext.Session.GetInt32("USER_LOGIN_KEY");
            if (sessionId == null)
                return RedirectToAction("Login", "Account");

            model.UserNo = int.Parse(sessionId.ToString());

            if (ModelState.IsValid)
            {
                using NoteDBContext db = new NoteDBContext();
                db.Notes.Add(model);
                if (db.SaveChanges() > 0)
                    return Redirect("List");

                ModelState.AddModelError(string.Empty, "Unable to add note");
            }
            return View();
        }

        /// <summary>
        /// Edit a note
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit()
        {
            // Not loged in
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        /// <summary>
        /// Delete a note
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete()
        {
            // Not loged in
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        /// <summary>
        /// Note Details
        /// </summary>
        /// <param name="noteNo"></param>
        /// <returns></returns>
        public IActionResult Detail(int noteNo) 
        {
            // Not loged in
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
                return RedirectToAction("Login", "Account");
            using NoteDBContext db = new NoteDBContext();
            Note note = db.Notes.FirstOrDefault(d => d.NodeNo.Equals(noteNo));
            return View(note);
        }
    }
}
