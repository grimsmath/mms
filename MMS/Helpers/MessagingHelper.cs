using MMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.Helpers
{
    public static class MessagingHelper
    {
        public static List<MessageViewModel> GetMessages(ref DAO.ApplicationContext context)
        {
            // Get messages for this mentor
            var messages = context.Messages.ToList();

            var msgs = (from r in messages
                        join c in context.UserProfiles on r.ToUserId equals c.id
                        join p in context.UserProfiles on r.FromUserId equals p.id
                        orderby r.Created ascending
                        select new MessageViewModel
                        {
                            MessageId = r.id,
                            FromUserId = r.FromUserId,
                            FromUser = p.Username,
                            ToUserId = r.ToUserId,
                            ToUser = WebMatrix.WebData.WebSecurity.CurrentUserName,
                            Created = r.Created,
                            IsFlashTraffic = r.IsFlashTraffic,
                            Subject = r.Subject,
                            Body = r.Body
                        }).ToList();

            return (List<MessageViewModel>) msgs;
        }

        public static List<MessageViewModel> GetMessagesToUserId(ref DAO.ApplicationContext context, int toUserId)
        {
            List<MessageViewModel> msgs = (List<MessageViewModel>) GetMessages(ref context)
                .Where(x => x.ToUserId == toUserId).OrderByDescending(x => x.Created).ToList();

            return msgs;
        }

        public static List<MessageViewModel> GetMessagesFromUserId(ref DAO.ApplicationContext context, int fromUserId)
        {
            List<MessageViewModel> msgs = (List<MessageViewModel>)GetMessages(ref context)
                .Where(x => x.FromUserId == fromUserId).ToList();

            return msgs;
        }
    }
}