using MMS.DAO;
using MMS.Helpers;
using MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.Helpers
{
    public static class AddressHelper
    {
        public static Address GetAddressByPersonAndType(ref ApplicationContext context, int personId, string addressType)
        {
            int addrType = DomainHelper.GetIdByKeyValue(ref context, "AddressType", addressType);

            var homeAddr = (from r in context.PersonToAddress
                            where r.PersonId == personId && r.AddressType == addrType
                            select r).FirstOrDefault();

            if (homeAddr != null)
            {
                var addr = (from r in context.Addresses
                            where r.id == homeAddr.AddressId
                            select r).FirstOrDefault();

                return (Address)addr;
            }
            else
            {
                return null;
            }
        }
    }
}