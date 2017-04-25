using MMS.Models;
using MMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMS.Helpers
{
    public static class CalendarHelper
    {
        public static IEnumerable<EventViewModel> GetEvents(ref DAO.ApplicationContext context)
        {
            var evts = (from r in context.Events
                        orderby r.EventBegins
                        select new EventViewModel
                        {
                            id = r.id,
                            CreatorId = r.CreatorId,
                            EventName = r.EventName,
                            EventDetails = r.EventDetails,
                            EventUrl = r.EventUrl,
                            EventBegins = r.EventBegins,
                            EventEnds = r.EventEnds,
                            AllDayEvent = r.AllDayEvent,
                            EventType = r.EventType,
                            MentorId = r.MentorId,
                            MenteeId = r.MenteeId,
                            SignupId = r.SignupId
                        }).AsEnumerable();

            return evts;            
        }

        public static List<EventViewModel> GetEventsByUserId(ref DAO.ApplicationContext context, int creatorId)
        {
            var myEvents = CalendarHelper.GetEvents(ref context)
                .Where(x => x.CreatorId == creatorId);

            return (List<EventViewModel>) myEvents.ToList();
        }

        public static List<EventViewModel> GetEventsForMentor(ref DAO.ApplicationContext context, int mentorId)
        {
            var myEvents = CalendarHelper.GetEvents(ref context)
                .Where(x => x.MentorId == mentorId);

            return (List<EventViewModel>) myEvents.ToList();
        }

        public static List<EventViewModel> GetEventsForMentee(ref DAO.ApplicationContext context, int menteeId)
        {
            var myEvents = CalendarHelper.GetEvents(ref context)
                .Where(x => x.MenteeId == menteeId);

            return (List<EventViewModel>) myEvents.ToList();
        }

        public static List<EventViewModel> GetTrainingEvents(ref DAO.ApplicationContext context)
        {
            int eventType = DomainHelper.GetIdByKeyValue(ref context, "EventType", "Training");

            var myEvents = CalendarHelper.GetEvents(ref context)
                .Where(x => x.EventType == eventType);

            return (List<EventViewModel>)myEvents.ToList();            
        }

        public static List<EventViewModel> GetPublicEvents(ref DAO.ApplicationContext context)
        {
            int eventType = DomainHelper.GetIdByKeyValue(ref context, "EventType", "Public");

            var myEvents = CalendarHelper.GetEvents(ref context)
                .Where(x => x.EventType == eventType);

            return (List<EventViewModel>)myEvents.ToList();            
        }

        public static List<EventViewModel> GetMenteeMeetingRequests(ref DAO.ApplicationContext context, int mentorId)
        {
            int eventType = DomainHelper.GetIdByKeyValue(ref context, "EventType", "Mentee Meeting Request");

            var myEvents = CalendarHelper.GetEvents(ref context)
                .Where(x => x.EventType == eventType && x.MentorId == mentorId);

            return (List<EventViewModel>)myEvents.ToList();
        }

        public static IEnumerable<SelectListItem> GetValidEventsDropdown(ref DAO.ApplicationContext context)
        {
            var events = (from r in context.Events
                          where r.EventBegins >= DateTime.Today
                          where r.EventEnds <= DateTime.Today
                          select r).AsEnumerable()
                          .Select(x => new SelectListItem
                          {
                              Value = x.id.ToString(),
                              Text = x.EventName
                          }).ToList();

            events.Insert(0, new SelectListItem { Value = "0", Text = "Please select ..." });

            return events;
        }
    }
}