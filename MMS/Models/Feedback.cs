using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MMS.Models
{
    public class Feedback : BaseModel
    {
        public int LogId { get; set; }
        
        public int LeadMentorId { get; set; }

        [DisplayName("Feedback Body")]
        public string FeedbackBody { get; set; }

        public DateTime Provided { get; set; }
    }
}