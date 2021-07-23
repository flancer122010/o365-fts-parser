using MailFTSParsers.Enums;
using System.Collections.Generic;

namespace MailFTSParsers.Models
{
    public static class AttachInfoExt
    {
        public static void Fill(this IAttachInfo info, IDictionary<PropertyId, object> props)
        {

            info.Properties = new SortedList<PropertyId, object>(props);
            if (props.TryGetValue(new PropertyId(MAPIProps.PR_DISPLAY_NAME), out object obj))
            {
                info.Name = (string)obj;
            }
            else
            {
                info.Name = string.Empty;
            }
            if (props.TryGetValue(new PropertyId(MAPIProps.PR_ATTACH_CONTENT_ID), out object obj2))
            {
                info.ContentId = (string)obj2;
            }
            else
            {
                info.ContentId = string.Empty;
            }
            if (props.TryGetValue(new PropertyId(MAPIProps.PR_ATTACHMENT_HIDDEN), out object obj3))
            {
                info.Hidden = (bool)obj3;
            }
            if (props.TryGetValue(new PropertyId(MAPIProps.PR_ATTACH_METHOD), out object obj4))
            {
                info.Method = (AttachMethod)(int)obj4;
            }
            if (props.TryGetValue(new PropertyId(MAPIProps.PR_ATTACH_LONG_FILENAME), out object obj5))
            {
                info.LongFileName = (string)obj5;
            }
            else
            {
                info.LongFileName = string.Empty;
            }
        }
    }
}
