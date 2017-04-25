﻿using MMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MMS.ViewModels
{
    public class UserProfileViewModel
    {
        public int id { get; set; }

        [Required]
        public UserProfile UserProfile { get; set; }
        public UserRole UserRole { get; set; }
        public Person Person { get; set; }
    }
}