using BlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AppContext = BlogApplication.DAL.AppContext;

namespace BlogApplication.Controllers
{
    public class HomeController : Controller
    {
        private AppContext db = new AppContext();
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.userName == _user.userName);
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Username already exists";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password)
        {
            if (ModelState.IsValid)
            {
                var data = db.Users.Where(s => s.userName.Equals(userName) && s.password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["userName"] = data.FirstOrDefault().userName;
                    Session["userId"] = data.FirstOrDefault().userId;
                    if (data.FirstOrDefault().isAdmin)
                    {
                        Session["isAdmin"] = "true";
                    }
                    else
                    {
                        Session["isAdmin"] = "false";
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public string GetUserName(User user) { return user.userName; }

        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
    }
}