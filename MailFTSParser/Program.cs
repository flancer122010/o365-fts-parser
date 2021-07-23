using MailFTSParsers.Enums;
using MailFTSParsers.Models;
using MailFTSParsers.Models.Impl;
using MsgKit;
using MsgKit.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers
{
    class ReceipientDetails
    {
        public UInt32 RecipientType { get; set; }
        public String DisplayName { get; set; }
        public String AddressType { get; set; }
        public String EmailAddress { get; set; }
        public String SmtpAddress { get; set; }
        public String DisplayType { get; set; }
    }

    public class MessageCreator
    {
        public static PropertyTag GetMKPTag(int x)
        {
            ushort propertyId = ushort.Parse($"{x:X8}".Substring(0, 4), System.Globalization.NumberStyles.AllowHexSpecifier);
            ushort propertyType = ushort.Parse($"{x:X8}".Substring(4), System.Globalization.NumberStyles.AllowHexSpecifier);
            Console.WriteLine("Value is {0}", $"{x:X8}");
            return new PropertyTag(propertyId, (PropertyType)Enum.Parse(typeof(PropertyType), propertyType.ToString()));
        }
        private String ATTACHMENT_TEMP_LOCATION = null;
        public MessageCreator(String tempLocation)
        {
            ATTACHMENT_TEMP_LOCATION = tempLocation;
        }
        private String GetTempFile(String name)
        {
            if(ATTACHMENT_TEMP_LOCATION == null)
            {
                return Path.GetTempFileName();
            } else
            {
                return ATTACHMENT_TEMP_LOCATION + Path.DirectorySeparatorChar + (name != null ? name:Path.GetRandomFileName());
            }
        }
        private Dictionary<UInt32, List<ReceipientDetails>> RetrieveRecipients(ICollection<SortedList<uint, object>> recipientsColl)
        {
            Dictionary<UInt32, List<ReceipientDetails>> recipients = new Dictionary<UInt32, List<ReceipientDetails>>();
            if(recipientsColl == null)
            {
                return recipients;
            }

            foreach (var item in recipientsColl)
            {
                ReceipientDetails receipientDetails = new ReceipientDetails();
                foreach (var i in item)
                {
                    PropertyId pid = new PropertyId((uint)i.Key);
                    //i.Value == 0 => From,  1 => (To) Primary recipient, 2 => CC recipient, 3 = >Bcc  recipient
                    if (pid == new PropertyId(MAPIProps.PR_RECIPIENT_TYPE))
                    {
                        receipientDetails.RecipientType = (UInt32)i.Value;
                        if (recipients.ContainsKey(receipientDetails.RecipientType))
                        {
                            recipients[receipientDetails.RecipientType].Add(receipientDetails);
                        }
                        else
                        {
                            recipients.Add(receipientDetails.RecipientType, new List<ReceipientDetails> { receipientDetails });
                        }
                    }
                    if (pid == new PropertyId(MAPIProps.PR_DISPLAY_NAME))
                    {
                        receipientDetails.DisplayName = i.Value.ToString();
                    }
                    else if (pid == new PropertyId(MAPIProps.PR_ADDRTYPE))
                    {
                        receipientDetails.AddressType = i.Value.ToString();
                    }
                    else if (pid == new PropertyId(MAPIProps.PR_EMAIL_ADDRESS))
                    {
                        receipientDetails.EmailAddress = i.Value.ToString();
                    }
                    else if (pid == new PropertyId(MAPIProps.PR_SMTP_ADDRESS))
                    {
                        receipientDetails.SmtpAddress = i.Value.ToString();
                    }
                }
            }
            return recipients;
        }

        private Attachment AddReferenceOnly(AttachInfo att)
        {
            object[] args = new object[] {att.Name,DateTime.Now, DateTime.Now, AttachmentType.ATTACH_BY_REF_ONLY, -1, att.Hidden, att.ContentId};

            var ctor = typeof(Attachment).GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
                                    null, new Type[] {
                                        typeof(Stream), typeof(string), typeof(DateTime),typeof(DateTime),
                                        typeof(AttachmentType), typeof(long), typeof(bool),
                                        typeof(string), typeof(bool)
                                    }, null);
            return (Attachment) ctor.Invoke(args);
        }

        public Email CreateMessage(ItemInfo itemInfo)
        {
            var receipients = RetrieveRecipients(itemInfo.Recipients);
            Sender sender = null;
            if (receipients.ContainsKey(0))
            {
                sender = new Sender(receipients[0].ElementAt(0).SmtpAddress, receipients[0].ElementAt(0).DisplayName);
            }
            else
            {
                sender = new Sender("", "");
            }
            var email = new Email(sender, itemInfo.Subject);
            foreach (var typeColl in receipients)
            {
                RecipientType recipientType = RecipientType.Originator;
                switch (typeColl.Key)
                {
                    case 1:
                        recipientType = RecipientType.To;
                        break;
                    case 2:
                        recipientType = RecipientType.Cc;
                        break;
                    case 3:
                        recipientType = RecipientType.Bcc;
                        break;
                }
                foreach (var recipient in typeColl.Value)
                {
                    email.Recipients.AddRecipient(recipient.SmtpAddress, recipient.DisplayName, AddressType.Smtp, recipientType);
                }
            }
            PropertyId tstProperty = new PropertyId(MAPIProps.PR_BODY);
            object val = null;
            if (itemInfo.Properties.Keys.Contains(tstProperty))
            {
                val = itemInfo.Properties[tstProperty];
                email.AddProperty(GetMKPTag((int)MAPIProps.PR_BODY), val);
            }
            tstProperty = new PropertyId(MAPIProps.PR_HTML);
            if (itemInfo.Properties.Keys.Contains(tstProperty))
            {
                val = itemInfo.Properties[tstProperty];
                email.AddProperty(GetMKPTag((int)MAPIProps.PR_HTML), val);
            }
            tstProperty = new PropertyId(MAPIProps.PR_RTF_COMPRESSED);
            if (itemInfo.Properties.Keys.Contains(tstProperty))
            {
                val = itemInfo.Properties[tstProperty];
                email.AddProperty(GetMKPTag((int)MAPIProps.PR_RTF_COMPRESSED), val);
            }
            email.SentOn = itemInfo.SubmittedTime; // Need to revisit this
            if (itemInfo.HasAttachments)
            {
                foreach (var att in itemInfo.Attachments)
                {
                    if (att.Embedded != null)
                    {
                        Email msg = CreateMessage(att.Embedded);
                        String tmpName = GetTempFile(att.Name);
                        msg.Save(tmpName + ".msg");
                        msg?.Dispose();
                        msg = null;
                        email.Attachments.Add(tmpName + ".msg");
                    }
                    else if (att.Method == AttachMethod.Value)
                    {
                        MemoryStream ms = new MemoryStream(att.Content);
                        // File.WriteAllBytes("C://Users/rsrini/Desktop/attachment.doc", att.Content);
                        email.Attachments.Add(ms, att.Name, -1, att.Hidden, att.ContentId);
                    }
                    else if (att.Method == AttachMethod.Storage)
                    {
                        //TODO: Yet to implement
                    }
                    else if (att.Method == AttachMethod.ReferenceOnly)
                    {
                        email.Attachments.Add(AddReferenceOnly(att));
                    }
                }
            }
            email.Priority = (itemInfo.Priority == (int)MessagePriority.PRIO_NONURGENT) ? MessagePriority.PRIO_NONURGENT : (itemInfo.Priority == (int)MessagePriority.PRIO_URGENT ? MessagePriority.PRIO_URGENT : MessagePriority.PRIO_NORMAL);
            email.ReceivedOn = itemInfo.CreatedTime;
            email.Importance = itemInfo.Importance == 2 ? MessageImportance.IMPORTANCE_HIGH : (itemInfo.Importance == 0 ? MessageImportance.IMPORTANCE_LOW : MessageImportance.IMPORTANCE_NORMAL);
            email.IconIndex = itemInfo.IsUnread ? MessageIconIndex.UnreadMail : MessageIconIndex.ReadMail;
            return email;
        }
        public Email CreateMessage(byte[] contentFromStorage)
        {
            ItemInfo itemInfo = FtsParser.GetItemInfo(contentFromStorage);
            return CreateMessage(itemInfo);
        }
    }

    class Program
    {
        
        
        static void Main(string[] args)
        {

            String data = File.ReadAllText(@"C:\16367560559E1B242D0D0000.eml");
            byte[] decodedByteArray = Convert.FromBase64CharArray(data.ToCharArray(), 0, data.Length);
            ItemInfo itemInfo = FtsParser.GetItemInfo(decodedByteArray);
            Email email = new MessageCreator(@"C:\").CreateMessage(itemInfo);
            email.Save(@"c:\email.msg");
            Console.ReadLine();
        }
    }
}
