using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MMS.Models
{
    [Table("MentorMentor")]
    public class MentorMentor : BaseModel
    {
        #region Members

        public int ParentPersonId { get; set; }
        public int ChildPersonId { get; set; } 
        
        #endregion

        #region Constructors

        public MentorMentor()
        {

        } 
        
        #endregion
    }
}