﻿using MMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MMS.ViewModels
{
    public class SignupViewModel
    {
        [DisplayName("Signup ID")]
        public int SignupId { get; set; }
        public EventSignup Signup { get; set; }
     
        [DisplayName("Event")]
        public int EventId { get; set; }
        public CalendarEvent Event { get; set; }
        public List<Signee> Signees { get; set; }
    }
}