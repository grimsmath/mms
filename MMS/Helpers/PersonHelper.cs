using MMS.DAO;
using MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.Helpers
{
    public static class PersonHelper
    {
        public static Person GetPersonById(ref ApplicationContext context, int id)
        {
            var person = (from r in context.People
                          where r.id == id
                          select r).FirstOrDefault();

            return (Person)person;
        }
    }
}