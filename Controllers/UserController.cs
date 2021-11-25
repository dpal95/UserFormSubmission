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
            //_userService.InsertUser("new", "testpassword");
            return View();
        }
    }
}