﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEgitim.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminAnasayfa()
        {
            return View();
        }
    }
}