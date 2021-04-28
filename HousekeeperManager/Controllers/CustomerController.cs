using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HousekeeperManager.Controllers
{
    public class CustomerController : Controller
    {
        private TaskContext taskContext;
        private LocationContext locationContext;
        

        // GET: Customer
        public ActionResult Home()
        {
            return View();
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
            var user = (User)TempData["Customer"];
            using (taskContext = new TaskContext())
            {
                if (taskModel.Name == null || taskModel.Description == null || taskModel.DeadLine == null || taskModel.Category == null || taskModel.UserId <=0)
                {
                    ViewBag.FailedRegisterMessage = "You must fill in all of the spaces!";
                    return View("TaskCreate", new Task());
                }
                else
                {
                    taskModel.UserId = user.Id;
                    taskModel.Status = "Waiting";
                    taskModel.DateOfAssignment = DateTime.Now;
                    taskContext.Tasks.Add(taskModel);
                    taskContext.SaveChanges();

                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Success!";
                return View("~/Views/Customer/Tasks.cshtml");
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
                    return View("~/Views/Customer/Tasks.cshtml");
                }
                return View(task);
            }
        }

        [HttpPost]
        public ActionResult TaskEdit(Task taskModel)
        {
            using (taskContext = new TaskContext())
            {
                if (taskModel.Name == null || taskModel.Description == null || taskModel.LocationId <= 0 || taskModel.Category == null || taskModel.Status == null || taskModel.Budget<=0.0)
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
                    taskContext.Tasks.First(x => x.Id == taskModel.Id).Budget = taskModel.Budget;
                    taskContext.SaveChanges();
                    return View("~/Views/Customer/Tasks.cshtml");
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
                    return View("~/Views/Customer/Tasks.cshtml");
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
                return View("~/Views/Customer/Tasks.cshtml");
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
                if (locationModel.Name == null || locationModel.Address == null)
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
                return View("~/Views/Customer/Locations.cshtml");
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
                    return View("~/Views/Customer/Locations.cshtml");
                }
                return View(location);
            }
        }

        [HttpPost]
        public ActionResult LocationEdit(Location locationModel)
        {
            using (locationContext = new LocationContext())
            {
                if (locationModel.Name == null || locationModel.Address == null || locationModel.UserId <= 0)
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
                    return View("~/Views/Customer/Locations.cshtml");
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
                    return View("~/Views/Customer/Locations.cshtml");
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
                return View("~/Views/Customer/Locations.cshtml");
            }
        }
    }
}