using MMS.Helpers;
using MMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.Helpers
{
    public class ResourceHelper
    {
        public static IEnumerable<ResourceViewModel> GetResources(ref MMS.DAO.ApplicationContext context)
        {
            MMS.DAO.ApplicationContext tempContext = context;

            var resources = (from r in context.Resources
                                 select r).AsEnumerable()
                                .Select(x => new ResourceViewModel
                                {
                                    id = x.id,
                                    Name = x.Name,
                                    Type = x.Type,
                                    UploadDate = x.UploadDate,
                                    Description = x.Description,
                                    Location = x.Location,
                                    RelativeUrl = x.RelativeUrl,
                                    DocumentType = DomainHelper.GetValueById(ref tempContext, x.Type)
                                }).ToList();

            return resources;
        }
    }
}