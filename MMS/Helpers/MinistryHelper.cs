using MMS.DAO;
using MMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MMS.Helpers
{
    public static class MinistryHelper
    {
        public static IEnumerable<SelectListItem> GetMinistriesDropdownList(ref ApplicationContext context)
        {
            var data = (from r in context.Ministries
                        select r).AsEnumerable()
                        .Select(x => new SelectListItem
                        {
                            Text = x.MinistryName,
                            Value = x.id.ToString()
                        }).ToList();

            data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ..." });

            return data;
        }

        public static int GetMinistryByPersonId(ref ApplicationContext context, int personId)
        {
            var data = (from r in context.Ministries
                        join p in context.MentorApplications on r.id equals p.MinistryId
                        where p.PersonId == personId
                        select r).First();

            if (data != null)
                return data.id;
            else
                return 0;
        }

        public static List<MinistryViewModel> GetMinistries(ref ApplicationContext context)
        {
            var data = (from r in context.Ministries
                        join c in context.Addresses on r.AddressId equals c.id
                        select r).AsEnumerable()
                        .Select(x => new MinistryViewModel
                        {
                            MinistryId = x.id,
                            Name = x.MinistryName,
                            Description = x.Description,
                            LeadMentorId = x.LeadMentorId,
                        }).ToList();

            return data;
        }
    }
}