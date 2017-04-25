using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.ViewModels
{
    public class EventListViewModel
    {
        /*
         * id = e.EventId,
         * title = e.EventName,
         * start = e.BeginDate.ToString("s"),
         * end = e.EndDate.ToString("s"),
         * allDay = e.AllDayEvent,
         * url = url + e.EventId
         */

        public int id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string allDay { get; set; }
        public string url { get; set; }
    }
}