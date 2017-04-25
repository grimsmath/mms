using MMS.Models;
using MMS.ViewModels;
using MMS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMS.Helpers
{
    public class MentorHelper
    {
        public static IEnumerable<SelectListItem> GetMentorsDropdownList(ref DAO.ApplicationContext context)
        {
            int mentorType = DomainHelper.GetValueByKeyValue(ref context, "PersonType", "Mentor").id;
            int leadMentorType = DomainHelper.GetValueByKeyValue(ref context, "PersonType", "Lead Mentor").id;
            int headMentorType = DomainHelper.GetValueByKeyValue(ref context, "PersonType", "Head Mentor").id;

			var data = (from r in context.People
                        where r.PersonTypeId == mentorType || r.PersonTypeId == leadMentorType || r.PersonTypeId == headMentorType
                        select r).AsEnumerable()
						.Select(x => new SelectListItem
						{
							Text = x.LastName + ", " + x.FirstName,
							Value = x.id.ToString()
						}).ToList();

			data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ..." });

			return data;
        }

        public static IEnumerable<SelectListItem> GetMenteesDropdownList(ref DAO.ApplicationContext context)
        {
            int menteeType = DomainHelper.GetValueByKeyValue(ref context, "PersonType", "Mentee").id;

            var data = (from r in context.People
                        where r.PersonTypeId == menteeType
                        select r).AsEnumerable()
                        .Select(x => new SelectListItem
                        {
                            Text = x.LastName + ", " + x.FirstName,
                            Value = x.id.ToString()
                        }).ToList();

            data.Insert(0, new SelectListItem { Value = "0", Text = "Please select ..." });

            return data;
        }

        public static List<MenteeViewModel> GetMentees(ref DAO.ApplicationContext context)
        {
            int menteeType = DomainHelper.GetValueByKeyValue(ref context, "PersonType", "Mentee").id;

            var data = (from r in context.People
                        where r.PersonTypeId == menteeType
                        select r).AsEnumerable()
                        .Select(x => new MenteeViewModel
                        {
                            Mentee = x,
                        });
                                          

            return (List<MenteeViewModel>) data.ToList();
        }

        public static List<MentorViewModel> GetMentors(ref DAO.ApplicationContext context)
        {
            int mentorType = DomainHelper.GetValueByKeyValue(ref context, "PersonType", "Mentor").id;
            int leadMentorType = DomainHelper.GetValueByKeyValue(ref context, "PersonType", "Lead Mentor").id;
            int headMentorType = DomainHelper.GetValueByKeyValue(ref context, "PersonType", "Head Mentor").id;

            var data = (from r in context.People
                        where r.PersonTypeId == mentorType || r.PersonTypeId == leadMentorType || r.PersonTypeId == headMentorType
                        select r).AsEnumerable()
                        .Select(x => new MentorViewModel
                        {
                            Person = x,
                        });


            return (List<MentorViewModel>)data.ToList();
        }

        public static MentorViewModel GetMentorById(ref DAO.ApplicationContext context, int personId)
        {
            MentorViewModel mentor = new MentorViewModel();

            mentor.Person = (from r in context.People
                             where r.id == personId
                             select r).First();

            mentor.HomeAddress = AddressHelper.GetAddressByPersonAndType(ref context, personId, "Home");
            mentor.WorkAddress = AddressHelper.GetAddressByPersonAndType(ref context, personId, "Work");
            mentor.MinistryId = MinistryHelper.GetMinistryByPersonId(ref context, personId);

            return mentor;
        }
    }
}