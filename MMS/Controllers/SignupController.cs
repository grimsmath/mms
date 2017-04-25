using MMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMS.Controllers
{
    [Authorize]
    public class SignupController : DefaultController
    {
        public SignupController()
        {
            ViewBag.YesNoList = _db.YesNoList;
            ViewBag.EventList = Helpers.CalendarHelper.GetValidEventsDropdown(ref this._db);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SignupViewModel viewModel)
        {
            if (ModelState.IsValid)
            { 
                // Good, continue
            }

            return View(viewModel);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(SignupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Good, continue    
            }

            return View(viewModel);
        }
    }
}
