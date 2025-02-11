﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Common;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var session = Session[Constants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}