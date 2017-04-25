using MMS.Helpers;
using MMS.Models;
using MMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMS.Controllers
{
	[Authorize]
	public class StaffController : DefaultController
	{
		public StaffController()
		{
            this.ViewBag.Logs = ContactLogHelper.GetContactLogsByMentorId(ref this._db, 1).Take(3);
            this.ViewBag.Messages = MessagingHelper.GetMessagesToUserId(ref this._db, 1).Take(3);
            this.ViewBag.Events = CalendarHelper.GetEventsByUserId(ref this._db, 1).Take(3);
            ViewBag.Resources = ResourceHelper.GetResources(ref this._db).Take(3);
		}

		public StaffController(IConfiguration config)
		{
			this._config = config;
		}

		public ActionResult Index()
		{         
            return View();
		}

		public ActionResult Users()
		{
			return View();
		}

		public ActionResult AddUser()
		{
			ViewBag.UserRoles = this._db.GetUserRoles();

			return View();
		}

		[HttpPost]
		public ActionResult AddUser(UserProfileViewModel viewModel)
		{
			if (ModelState.IsValid) 
			{
				// We need to add the user
				UserProfile user = this._db.UserProfiles.Find(viewModel.UserProfile.Username);
				if (user == null)
				{
					// New User user
					user = this._db.UserProfiles.Add(viewModel.UserProfile);

					// Add a person record
					Person myPerson = this._db.People.Add(viewModel.Person);

					// Save the user's role
					user.RoleId = viewModel.UserRole.id;

					// Link the person to the userprofile
					user.PersonId = myPerson.id;

					// Save the changes
					_db.SaveChanges();

					// Send the user back to the user's list
					Response.Redirect("~/Staff/Users");
				}
				else
				{
					ModelState.AddModelError("", "The username already exists!");
				}
			}
			
			ViewBag.UserRoles = this._db.GetUserRoles();
			return View(viewModel);
		}
	}
}
