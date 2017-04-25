using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.Helpers
{
    public class DefaultView
    {
        public string Message { get; set; }
        public string Error { get; set; }
        public string CurrentPage { get; set; }
        public IDictionary<string, string> Settings { get; set; }

        public DefaultView WithErrorMessage(string errorMessage)
        {
            this.Error = errorMessage;
            return this;
        }

        public DefaultView WithMessage(string message)
        {
            this.Message = message;
            return this;
        }

        public DefaultView WithCurrentPage(string page)
        {
            this.CurrentPage = page;
            return this;
        }

        public DefaultView WithSettings(IDictionary<string, string> settings)
        {
            this.Settings = settings;
            return this;
        }
    }
}