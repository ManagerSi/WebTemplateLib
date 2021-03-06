﻿using cpts_161_bet.Security.Attribute;
using DataBaseLib;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cpts_161_bet.Controllers {
    [MP_OAuth]
    [Authorize]
    public class HomeController : BaseController {
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index() {
            log.Info("Index");
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}