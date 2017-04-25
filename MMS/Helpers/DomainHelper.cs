using MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.Helpers
{
    public static class DomainHelper
    {
        public static List<string> GetValuesByKey(ref MMS.DAO.ApplicationContext context, string key)
        {
            List<string> data = (from r in context.Domains
                                 where r.Key == key
                                 select r.Value).ToList();

            if (data.Count() > 0)
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public static int GetStateIdByName(ref MMS.DAO.ApplicationContext context, string stateName)
        {
            State state = (State) (from r in context.States
                        where r.Name == stateName
                        select r).FirstOrDefault();

            return state.id;
        }

        public static string GetValueById(ref MMS.DAO.ApplicationContext context, int id)
        {
            Domain data = (Domain)(from r in context.Domains
                                   where r.id == id
                                   select r).First();

            return data.Value;
        }

        public static Domain GetValueByKeyValue(ref MMS.DAO.ApplicationContext context, string keyValue, string valueValue)
        {
            Domain mydomain = (Domain)(from r in context.Domains
                                       where r.Key == keyValue && r.Value == valueValue
                                       select r).FirstOrDefault();

            return mydomain;
        }

        public static int GetIdByKeyValue(ref MMS.DAO.ApplicationContext context, string keyValue, string valueValue)
        {
            Domain mydomain = (Domain)(from r in context.Domains
                                       where r.Key == keyValue && r.Value == valueValue
                                       select r).FirstOrDefault();

            return mydomain.id;
        }

        public static string GetMiscDataByKey1(ref MMS.DAO.ApplicationContext context, string key1)
        {
            var data = (from r in context.MiscData
                       where r.Key1 == key1
                       select r).FirstOrDefault();

            return data.ToString();
        }

        public static string GetMiscDataByKey2(ref MMS.DAO.ApplicationContext context, string key1, string key2)
        {
            var data = (from r in context.MiscData
                        where r.Key1 == key1 && r.Key2 == key2
                        select r).FirstOrDefault();

            return data.ToString();
        }

        public static string GetMiscDataByKey3(ref MMS.DAO.ApplicationContext context, string key1, string key2, string key3)
        {
            var data = (from r in context.MiscData
                        where r.Key1 == key1 && r.Key2 == key2 && r.Key3 == key3
                        select r).FirstOrDefault();

            return data.ToString();
        }
    }
}