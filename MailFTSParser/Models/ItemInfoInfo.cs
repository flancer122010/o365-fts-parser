using MailFTSParsers.Enums;
using MailFTSParsers.Models.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    internal class ItemInfoInfo
    {
        private readonly ItemInfo _info = new ItemInfo();

        private List<SortedList<uint, object>> _recipients;

        private List<AttachInfo> _attachments;

        internal ItemInfo Info => _info;

        internal void SetBody(byte[] data, BodyType type)
        {
            _info.Body = new Body
            {
                Content = data,
                Type = type
            };
        }

        public void AddRecipient(SortedList<uint, object> recipient)
        {
            if (_recipients == null)
            {
                _recipients = new List<SortedList<uint, object>>();
                _info.Recipients = _recipients;
            }
            _recipients.Add(recipient);
        }

        internal void AddAttach(AttachInfo attachment)
        {
            if (_attachments == null)
            {
                _attachments = new List<AttachInfo>();
                _info.Attachments = _attachments;
                _info.HasAttachments = true;
            }
            _attachments.Add(attachment);
        }
    }
}
