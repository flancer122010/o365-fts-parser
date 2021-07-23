using MailFTSParsers.Models.Impl;
using MailFTSParsers.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{

    class BaseParser
    {
        private ItemTreeBuilder tree;

        private readonly ElementReader reader;

        internal BaseParser(IItemTreeBuilder tree)
        {
            this.tree = new ItemTreeBuilder(tree);
            this.reader = new ElementReader(this.tree);
        }

        internal void Parse(Stream stream)
        {
            using (BufferReader bufferReader = new BufferReader(stream))
            {
                bufferReader.Open();
                while (true)
                {
                    byte[] nextBuffer = bufferReader.GetNextBuffer();
                    if (nextBuffer == null)
                    {
                        break;
                    }
                    reader.Read(nextBuffer);
                }
                tree.FinalCheck();
            }
        }
    }

    public static class FtsParser
    {
        public static ItemInfo GetItemInfo(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data, false))
            {
                return GetItemInfo(stream);
            }
        }

        private static ItemInfo GetItemInfo(Stream stream)
        {
            ItemInfoBuilder itemInfoBuilder = new ItemInfoBuilder();
            new BaseParser(new FullItemTreeBuilder(itemInfoBuilder)).Parse(stream);
            return itemInfoBuilder.Info;
        }

        public static SplittedItemInfo SplitItem(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data, false))
            {
                return SplitItem(stream);
            }
        }

        private static SplittedItemInfo SplitItem(Stream stream)
        {
            ItemTreeSplitter itemTreeSplitter = new ItemTreeSplitter();
            new BaseParser(itemTreeSplitter).Parse(stream);
            return itemTreeSplitter.GetSplittedItemInfo();
        }

        public static SortedList<PropertyId, object> GetItemProps(SplittedItemInfo info)
        {
            return GetItemProps(info.ItemProps);
        }

        public static SortedList<PropertyId, object> GetItemProps(byte[] data)
        {
            PropertyBuilder propCollector = new PropertyBuilder();
            new ElementBufferReader(new ItemTreeBuilder(propCollector), new BinReader(data, 0)).Read();
            return InternalProps.Skip(propCollector.Props);
        }

        public static SortedList<PropertyId, object> GetAttachProps(byte[] data)
        {
            return GetItemProps(data);
        }

        public static IReadOnlyList<SortedList<uint, object>> GetRecipients(SplittedItemInfo info)
        {
            return GetRecipients(info.Recipients);
        }

        public static IReadOnlyList<SortedList<uint, object>> GetRecipients(byte[] data)
        {
            if (data != null && data.Length != 0)
            {
                RecipientCollector recipientCollector = new RecipientCollector();
                new ElementBufferReader(new ItemTreeBuilder(recipientCollector), new BinReader(data, 0)).Read();
                IReadOnlyList<SortedList<uint, object>> recipients = recipientCollector.Recipients;
                if (recipients != null && recipients.Count > 0)
                {
                    return recipients;
                }
                return null;
            }
            return null;
        }

        public static ItemInfo GetEmbeddedItemInfo(byte[] data)
        {
            ItemInfoBuilder itemInfoBuilder = new ItemInfoBuilder();
            ItemTreeBuilder itemTreeBuilder = new ItemTreeBuilder(new FullItemTreeBuilder(itemInfoBuilder));
            new ElementReader(itemTreeBuilder).Read(data);
            itemTreeBuilder.FinalCheck();
            return itemInfoBuilder.Info;
        }
    }
}
