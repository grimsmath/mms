﻿using MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.Models
{
    public class PersonPhone : BaseModel
    {
        public int PersonId { get; set; }
        public int PhoneId { get; set; }
        public int PhoneType { get; set; }

        public PersonPhone()
        {
            //
        }

        public PersonPhone(int personId, int phoneId, int phoneType)
        {
            this.PersonId = personId;
            this.PhoneId = phoneId;
            this.PhoneType = phoneType;
        }
    }
}