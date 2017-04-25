using MMS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMS.Controllers
{
	public class HomeController : DefaultController
	{
        public HomeController()
        {
            
        }

        public HomeController(IConfiguration config)
        {
            this._config = config;
        }

		public ActionResult Index()
		{
            ViewBag.UserRole = Helpers.AccountHelper.GetUserRoleByUsername(ref this._db, User.Identity.Name);

			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}
	}
}
