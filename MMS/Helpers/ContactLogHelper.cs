using MMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.Helpers
{
    public static class ContactLogHelper
    {
        public static IEnumerable<ContactLogViewModel> GetContactLogs(ref DAO.ApplicationContext context)
        {
            var contactLogs = context.ContactLogs.ToList();
            var logs = (from r in contactLogs
                       join c in context.People on r.MentorId equals c.id
                       join d in context.People on r.MenteeId equals d.id
                       orderby r.ContactDate descending
                       select new ContactLogViewModel
                       {
                           ContactLogId = r.id,
                           ContactDate = r.ContactDate.ToString("s"),
                           MenteeName = c.LastName + ", " + c.FirstName,
                           MentorName = c.LastName + ", " + c.LastName,
                           ActivityTypeId = r.ActivityTypeId,
                           ContactTypeId = r.ContactTypeId
                       }).AsEnumerable();

            return logs;
        }

        public static IEnumerable<ContactLogViewModel> GetContactLogsByMentorId(ref DAO.ApplicationContext context, int personId)
        {
            var logs = (IEnumerable<ContactLogViewModel>)GetContactLogs(ref context)
                .Where(x => x.MentorId == personId).ToList();

            return logs;
        }

        public static IEnumerable<ContactLogViewModel> GetContactLogsByMenteeId(ref DAO.ApplicationContext context, int personId)
        {
            List<ContactLogViewModel> logs = (List<ContactLogViewModel>) GetContactLogs(ref context)
                .Where(x => x.MenteeId == personId).ToList();

            return logs;
        }

        public static IEnumerable<ContactLogViewModel> GetContactLogsByMinistryId(ref DAO.ApplicationContext context, int ministryId)
        {
            var contactLogs = context.ContactLogs.ToList();
            var logs = (from r in GetContactLogs(ref context)
                       join c in context.Ministries on r.MinistryId equals c.id
                       where c.id == ministryId
                       select r).ToList();

            return (List<ContactLogViewModel>)logs;
        }
    }
}