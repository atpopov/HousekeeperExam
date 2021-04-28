using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HousekeeperManager.Controllers
{
    public class HomeController : Controller
    {
        private User loggedUser;

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register(int id=0)
        {
            User userModel = new User();
            return View(userModel);        
        }

        [HttpPost]
        public ActionResult Register(User userModel)
        {
            using (UserContext context = new UserContext())
            {
                if (userModel.Password == null || userModel.Username == null || userModel.FirstName==null || userModel.LastName==null)
                {
                    ViewBag.FailedRegisterMessage = "You must fill in all of the spaces!";
                    return View("Register", new User());
                }
                else
                {

                    if (context.Users.Count() == 0)
                    {
                        User admin = new User();
                        admin.FirstName = "Admin";
                        admin.LastName = "Admin";
                        admin.Username = "admin";
                        admin.Password = "adminpass";
                        admin.Role = "Admin";
                        context.Users.Add(admin);
                    }
                    
                    userModel.Role = "Customer";
                    
                    if (context.Users.Any(x => x.Username == userModel.Username))
                    {
                        ViewBag.DuplicateMessage = "An User with this user name already exists.";
                        return View("Register", userModel);
                    }
                    context.Users.Add(userModel);
                    context.SaveChanges();

                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Register successful!";
                return View("~/Home/Index.cshtml");
            }
        }

        [HttpGet]
        public ActionResult Login(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Login(User userModel)
        {
            using (UserContext context = new UserContext())
            {
                if (context.Users.Any(x => x.Username == userModel.Username && x.Password == userModel.Password))
                {
                    var ddd = context.Users.Where(x => x.Username == userModel.Username && x.Password == userModel.Password);
                    loggedUser = userModel;

                    //Methods for storing the data for the logged in User, so we can use it in the other Controllers
                    TempData["Admin"] = ddd.First();
                    TempData["Customer"] = ddd.First();
                    ViewBag.SuccessLoginMessage = "Success!";
                    if (ddd.First().Role == "Admin")
                    {
                        return View("~/Views/Admin/Home.cshtml");
                    }
                    else if (ddd.First().Role == "Customer")
                    {
                        return View("~/Views/Customer/Home.cshtml");
                    }
                    else return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    ViewBag.FailedLoginMessage = "The username or password is invalid!";
                    return View("Login", new User());
                }
            }
        }

        public ActionResult Logout()
        {
            loggedUser = null;
            return View("~/Views/Home/Index.cshtml");
        }
    }
}