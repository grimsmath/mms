using MMS.Models;
using MMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMS.Helpers
{
    public static class AccountHelper
    {
        public static List<UserProfileViewModel> GetUserProfiles(ref DAO.ApplicationContext context)
        {
            var users = (from r in context.UserProfiles
                         join p in context.UserRoles on r.RoleId equals p.id
                         join c in context.People.DefaultIfEmpty() on r.PersonId equals c.id
                         select new UserProfileViewModel
                         {
                             UserProfile = r,
                             UserRole = p,
                             Person = c
                         }).ToList();

            return (List<UserProfileViewModel>)users;
        }

        public static IEnumerable<SelectListItem> GetUserDropdownList(ref DAO.ApplicationContext context)
        {
            int menteeTypeId = DomainHelper.GetIdByKeyValue(ref context, "PersonType", "Mentee");

            var data = (from r in context.People
                        where r.PersonTypeId != menteeTypeId 
                        select r).AsEnumerable()
                        .Select(x => new SelectListItem
                        {
                            Text = x.LastName + ", " + x.FirstName,
                            Value = x.id.ToString()
                        }).ToList();

            data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ...", Selected = true });

            return data;
        }

        public static int GetUserIdByUsername(ref DAO.ApplicationContext context, string username)
        {
            var user = (from r in context.People
                        join p in context.UserProfiles on r.id equals p.PersonId
                        where p.Username == username
                        select r).FirstOrDefault();

            return (user != null) ? user.id : 0;
        }

        public static UserProfileViewModel GetUserProfileByPersonId(ref DAO.ApplicationContext context, int personId)
        {
            UserProfileViewModel user = (UserProfileViewModel) GetUserProfiles(ref context)
                .Where(x => x.Person.id == personId);

            return user;
        }

        public static UserProfileViewModel GetUserProfileByUsername(ref DAO.ApplicationContext context, string username)
        {
            UserProfileViewModel user = (UserProfileViewModel) GetUserProfiles(ref context)
                .Where(x => x.UserProfile.Username == username).FirstOrDefault();

            return user;
        }

        public static List<UserProfileViewModel> GetUserProfilesByRoleId(ref DAO.ApplicationContext context, int roleId)
        {
            List<UserProfileViewModel> users = (List<UserProfileViewModel>) GetUserProfiles(ref context)
                .Where(x => x.UserRole.id == roleId).ToList();

            return users;
        }

        public static List<UserProfileViewModel> GetUserProfilesByRoleName(ref DAO.ApplicationContext context, string roleName)
        {
            List<UserProfileViewModel> users = (List<UserProfileViewModel>) GetUserProfiles(ref context)
                .Where(x => x.UserRole.Name == roleName).ToList();

            return users;
        }

        public static string GetUserRoleByUsername(ref DAO.ApplicationContext context, string username)
        {
            var data = (from r in context.UserProfiles
                       join p in context.UserRoles on r.RoleId equals p.id
                       where r.Username == username
                       select p.Name).FirstOrDefault();

            return (string)data;
        }

        public static UserProfile GetUsernameByUserId(ref DAO.ApplicationContext context, int id)
        {
            var data = (from r in context.UserProfiles
                        where r.id == id
                        select r).FirstOrDefault();

            return data;
        }
    }
}