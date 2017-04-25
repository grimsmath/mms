﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MMS.Models
{
    [Table("Signee")]
    public class Signee : BaseModel
    {
        #region Members

        public int SignupId { get; set; }
        public int PersonId { get; set; } 
        
        #endregion

        #region Constructors

        public Signee()
        {

        } 

        #endregion
    }
}