using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserResistration.Models;

namespace UserResistration.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            dbo_User userModel = new dbo_User();

            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddorEdit (dbo_User userModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                dbModel.dbo_User.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SucessMessage = "Registration Sucessful.";
            return View("AddorEdit", new dbo_User());
        }
    }
}