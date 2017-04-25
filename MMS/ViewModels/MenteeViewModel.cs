using MMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MMS.ViewModels
{
    public class MenteeViewModel
    {
        public Person Mentee { get; set; }
        public Address HomeAddress { get; set; }
        public string Facility { get; set; }
        public Person Chaplain { get; set; }
    }
}