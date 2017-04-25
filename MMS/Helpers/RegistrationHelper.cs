using MMS.Models;
using MMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.Helpers
{
    public static class RegistrationHelper
    {
        public static RegistrationViewModel FindRegistration(ref DAO.ApplicationContext context, string username)
        {
            int personId = AccountHelper.GetUserIdByUsername(ref context, username);
            if (personId > 0)
            {
                RegistrationViewModel viewModel = new RegistrationViewModel();

                int homeAddrType = DomainHelper.GetIdByKeyValue(ref context, "AddressType", "Home");
                int workAddrType = DomainHelper.GetIdByKeyValue(ref context, "AddressType", "Work");

                MentorApplication data = (MentorApplication)(from r in context.MentorApplications
                                                             where r.PersonId == personId
                                                             select r).FirstOrDefault();

                UserProfile profile = (UserProfile)(from r in context.UserProfiles
                                                    where r.PersonId == personId
                                                    select r).FirstOrDefault();

                Person mentor = (Person)(from r in context.People
                                         where r.id == personId
                                         select r).FirstOrDefault();

                Address homeAddr = (Address)(from r in context.Addresses
                                             join c in context.PersonToAddress on r.id equals c.AddressId
                                             where c.PersonId == personId && c.AddressType == homeAddrType
                                             select r).FirstOrDefault();

                Address workAddr = (Address)(from r in context.Addresses
                                             join c in context.PersonToAddress on r.id equals c.AddressId
                                             where c.PersonId == personId && c.AddressType == workAddrType
                                             select r).FirstOrDefault();


                viewModel.AgreeToTerms = data.AgreeToTerms;
                viewModel.Availability = data.Availability;
                viewModel.DateOfBirth = mentor.DOB;
                viewModel.FelonyArrested = mentor.FelonyArrested;
                viewModel.FelonyConvicted = mentor.FelonyConvicted;
                viewModel.FelonyDescription = mentor.FelonyDescription;
                viewModel.FirstName = mentor.FirstName;
                viewModel.GenderId = mentor.GenderId;
                viewModel.HasRelationIncarcerated = data.HasRelationIncarcerated;
                viewModel.HomeAddress = homeAddr;
                viewModel.LastName = mentor.LastName;
                viewModel.LeadershipSkills = data.LeadershipSkills;
                viewModel.MaidenName = mentor.MaidenName;
                viewModel.MiddleInitial = mentor.MiddleInitial;
                viewModel.MinistryExperience = data.MinistryExperience;
                viewModel.MinistryId = data.MinistryId;
                viewModel.MisdemeanorArrested = mentor.MisdemeanorArrested;
                viewModel.MisdemeanorConvicted = mentor.MisdemeanorConvicted;
                viewModel.MisdemeanorDescription = mentor.MisdemeanorDescription;
                viewModel.PersonId = mentor.id;
                viewModel.PrefixId = mentor.PrefixId;
                viewModel.RaceId = mentor.RaceId;
                viewModel.RelationIncarceratedName = data.RelationIncarceratedName;
                viewModel.RelationIncarceratedNumber = data.RelationIncarceratedNumber;
                viewModel.RelationIncarceratedType = data.RelationIncarceratedType;
                viewModel.RelativesWorkingForDoC = data.RelativesWorkingForDoC;
                viewModel.RelativeWorkingForDoCName = data.RelativeWorkingForDoCName;
                viewModel.RelativeWorkingForDoCRelationType = data.RelativeWorkingForDoCRelationType;
                viewModel.RelativeWorkingForDoCWorkLocation = data.RelativeWorkingForDoCWorkLocation;
                viewModel.SocialSecurityNumber = mentor.SSN;
                viewModel.SpecialHobbies = data.SpecialHobbies;
                viewModel.SpecialRequests = data.SpecialRequests;
                viewModel.StateDl = mentor.StateDl;
                viewModel.StateWhereDlIssued = mentor.StateWhereDlWasIssued;
                viewModel.SuffixId = mentor.SuffixId;

                if (data.WhenWorkedEnded != null)
                    viewModel.WhenWorkedEnded = data.WhenWorkedEnded.Value;

                if (data.WhenWorkedStarted != null)
                    viewModel.WhenWorkedStarted = data.WhenWorkedStarted.Value;

                viewModel.WhereDidYouWork = data.WhereDidYouWork;
                viewModel.WorkAddress = workAddr;
                viewModel.WorkedForDoC = data.WorkedForDoC;
                viewModel.Username = profile.Username;

                return viewModel;
            }
            else
            {
                return null;
            }
        }

        public static MentorApplication GetMentorApplicationById(ref DAO.ApplicationContext context, int id)
        {
            MentorApplication application = (from r in context.MentorApplications
                                             where r.id == id
                                             select r).FirstOrDefault();

            return application;
        }

        public static MentorApplication GetMentorApplicationByPersonId(ref DAO.ApplicationContext context, int id)
        {
            MentorApplication application = (from r in context.MentorApplications
                                             where r.PersonId == id
                                             select r).FirstOrDefault();

            return application;
        }

    }
}