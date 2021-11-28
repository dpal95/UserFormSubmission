using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using UserFormSubmission.Services;

namespace UserFormSubmission.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SubmitData(string txtEmail, string txtPassword)
        {            
            string response = "";
            //check if the user exists before saving
            var exists = _userService.CheckUserExists(txtEmail);
            if (!exists)
            {
              //save user to db
              response = _userService.InsertUser(txtEmail, txtPassword);
            }
            else
            {
                response = "User already exists, please try again";
            }
            return Json(new { message = response }, JsonRequestBehavior.AllowGet);

        }
    }
}