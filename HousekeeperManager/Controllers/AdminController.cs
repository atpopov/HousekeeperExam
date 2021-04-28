using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HousekeeperManager.Controllers
{
    public class AdminController : Controller
    {
        UserContext userContext;
        LocationContext locationContext;
        TaskContext taskContext;

        // GET: Admin
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserCreate(int id=0)
        {
            User userModel = new User();
            return View(userModel);         
        }

        [HttpPost]
        public ActionResult UserCreate(User userModel)
        {
            using (userContext = new UserContext())
            {
                if (userModel.Password == null || userModel.Username == null || userModel.FirstName == null || userModel.LastName == null || userModel.Role == null)
                {
                    ViewBag.FailedRegisterMessage = "You must fill in all of the spaces!";
                    return View("UserCreate", new User());
                }
                else
                {
                    if (userContext.Users.Any(x => x.Username == userModel.Username))
                    {
                        ViewBag.DuplicateMessage = "An User with this user name already exists.";
                        return View("UserCreate", userModel);
                    }
                    userContext.Users.Add(userModel);
                    userContext.SaveChanges();

                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Success!";
                return View("~/Views/Admin/Users.cshtml");
            }

          
        }

        [HttpGet]
        public ActionResult UserEdit(int id = 0)
        {
            using (userContext = new UserContext())
            {
                User user = userContext.Users.First(x => x.Id == id);
                if (user == null)
                {
                    return View("~/Views/Admin/Users.cshtml");
                }
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult UserEdit(User userModel)
        {
            using (userContext = new UserContext())
            {
                if (userModel.Username == null || userModel.FirstName == null || userModel.LastName == null || userModel.Role == null)
                {
                    ViewBag.FailedAddMessage = "You must fill in all of the spaces and the data should be correct!";
                    return View("UserEdit", new User());
                }
                else
                {
                    userContext.Users.First(x => x.Id == userModel.Id).Username = userModel.Username;
                    userContext.Users.First(x => x.Id == userModel.Id).FirstName = userModel.FirstName;
                    userContext.Users.First(x => x.Id == userModel.Id).LastName = userModel.LastName;
                    userContext.Users.First(x => x.Id == userModel.Id).Role = userModel.Role;
                    userContext.SaveChanges();
                    return View("~/Views/Admin/Users.cshtml");
                }
            }
        }


        [HttpGet]
        public ActionResult UserRemove(int id = 0)
        {
            using (userContext = new UserContext())
            {
                User user = userContext.Users.First(x => x.Id == id);
                if (user == null)
                {
                    return View("~/Views/Admin/Users.cshtml");
                }
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult UserRemove(User user)
        {
            using (userContext = new UserContext())
            {
                User toRemove = userContext.Users.Find(user.Id);
                userContext.Users.Remove(toRemove);
                userContext.SaveChanges();
                return View("~/Views/Admin/Users.cshtml");
            }
        }

        public ActionResult Locations()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LocationCreate(int id = 0)
        {
            Location locationModel = new Location();
            return View(locationModel);
        }

        [HttpPost]
        public ActionResult LocationCreate(Location locationModel)
        {
            using (locationContext = new LocationContext())
            {
                if (locationModel.Name == null || locationModel.Address == null )
                {
                    ViewBag.FailedRegisterMessage = "You must fill in all of the spaces!";
                    return View("LocationCreate", new Location());
                }
                else
                {
                    if (locationContext.Locations.Any(x => x.Address == locationModel.Address))
                    {
                        ViewBag.DuplicateMessage = "A Location with this address already exists.";
                        return View("LocationCreate", locationModel);
                    }
                    locationContext.Locations.Add(locationModel);
                    locationContext.SaveChanges();

                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Success!";
                return View("~/Views/Admin/Locations.cshtml");
            }


        }

        [HttpGet]
        public ActionResult LocationEdit(int id = 0)
        {
            using (locationContext = new LocationContext())
            {
                Location location = locationContext.Locations.First(x => x.Id == id);
                if (location == null)
                {
                    return View("~/Views/Admin/Locations.cshtml");
                }
                return View(location);
            }
        }

        [HttpPost]
        public ActionResult LocationEdit(Location locationModel)
        {
            using (locationContext = new LocationContext())
            {
                if (locationModel.Name == null || locationModel.Address == null || locationModel.UserId <=0 )
                {
                    ViewBag.FailedAddMessage = "You must fill in all of the spaces and the data should be correct!";
                    return View("LocationEdit", new Location());
                }
                else
                {
                    locationContext.Locations.First(x => x.Id == locationModel.Id).Name = locationModel.Name;
                    locationContext.Locations.First(x => x.Id == locationModel.Id).Address = locationModel.Address;
                    locationContext.Locations.First(x => x.Id == locationModel.Id).UserId = locationModel.UserId;
                    locationContext.SaveChanges();
                    return View("~/Views/Admin/Locations.cshtml");
                }
            }
        }

        [HttpGet]
        public ActionResult LocationRemove(int id = 0)
        {
            using (locationContext = new LocationContext())
            {
                Location location = locationContext.Locations.First(x => x.Id == id);
                if (location == null)
                {
                    return View("~/Views/Admin/Locations.cshtml");
                }
                return View(location);
            }
        }

        [HttpPost]
        public ActionResult LocationRemove(Location location)
        {
            using (locationContext = new LocationContext())
            {
                Location toRemove = locationContext.Locations.Find(location.Id);
                locationContext.Locations.Remove(toRemove);
                locationContext.SaveChanges();
                return View("~/Views/Admin/Locations.cshtml");
            }
        }

        public ActionResult Tasks()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TaskCreate(int id = 0)
        {
            Task taskModel = new Task();
            taskModel.DeadLine = DateTime.Now;
            return View(taskModel);
        }

        [HttpPost]
        public ActionResult TaskCreate(Task taskModel)
        {
            using (taskContext = new TaskContext())
            {
                if (taskModel.Name == null || taskModel.Description == null || taskModel.DeadLine == null || taskModel.Category == null || taskModel.UserId <= 0)
                {
                    ViewBag.FailedRegisterMessage = "You must fill in all of the spaces!";
                    return View("TaskCreate", new Task());
                }
                else
                {
                    taskModel.Status = "Waiting";
                    taskModel.DateOfAssignment = DateTime.Now;
                    taskContext.Tasks.Add(taskModel);
                    taskContext.SaveChanges();

                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Success!";
                return View("~/Views/Admin/Tasks.cshtml");
            }


        }

        [HttpGet]
        public ActionResult TaskEdit(int id = 0)
        {
            using (taskContext = new TaskContext())
            {
                Task task = taskContext.Tasks.First(x => x.Id == id);
                if (task == null)
                {
                    return View("~/Views/Admin/Tasks.cshtml");
                }
                return View(task);
            }
        }

        [HttpPost]
        public ActionResult TaskEdit(Task taskModel)
        {
            using (taskContext = new TaskContext())
            {
                if (taskModel.Name == null || taskModel.Description == null || taskModel.LocationId <= 0 || taskModel.Category == null || taskModel.Status == null)
                {
                    ViewBag.FailedAddMessage = "You must fill in all of the spaces and the data should be correct!";
                    return View("TaskEdit", new Task());
                }
                else
                {
                    taskContext.Tasks.First(x => x.Id == taskModel.Id).Name = taskModel.Name;
                    taskContext.Tasks.First(x => x.Id == taskModel.Id).Description = taskModel.Description;
                    taskContext.Tasks.First(x => x.Id == taskModel.Id).LocationId = taskModel.LocationId;
                    taskContext.Tasks.First(x => x.Id == taskModel.Id).DeadLine = taskModel.DeadLine;
                    taskContext.Tasks.First(x => x.Id == taskModel.Id).Category = taskModel.Category;
                    taskContext.Tasks.First(x => x.Id == taskModel.Id).Status = taskModel.Status;
                    taskContext.Tasks.First(x => x.Id == taskModel.Id).ImageUrl = taskModel.ImageUrl;
                    taskContext.Tasks.First(x => x.Id == taskModel.Id).DateOfAssignment = taskModel.DateOfAssignment;
                    taskContext.Tasks.First(x => x.Id == taskModel.Id).UserId = taskModel.UserId;
                    taskContext.SaveChanges();
                    return View("~/Views/Admin/Tasks.cshtml");
                }
            }
        }

        [HttpGet]
        public ActionResult TaskRemove(int id = 0)
        {
            using (taskContext = new TaskContext())
            {
                Task task = taskContext.Tasks.First(x => x.Id == id);
                if (task == null)
                {
                    return View("~/Views/Admin/Tasks.cshtml");
                }
                return View(task);
            }
        }

        [HttpPost]
        public ActionResult TaskRemove(Task task)
        {
            using (taskContext = new TaskContext())
            {
                Task toRemove = taskContext.Tasks.Find(task.Id);
                taskContext.Tasks.Remove(toRemove);
                taskContext.SaveChanges();
                return View("~/Views/Admin/Tasks.cshtml");
            }
        }
    }
}