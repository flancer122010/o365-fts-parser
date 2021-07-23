using MailFTSParsers.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    class ElementReader
    {
        private readonly IElementBuilder _builder;

        private IPropertyParser _tail;

        internal ElementReader(IElementBuilder builder)
        {
            _builder = builder;
        }

        internal void Read(byte[] buffer)
        {
            BinReader reader = new BinReader(buffer, 0);
            if (_tail != null)
            {
                if (!_tail.Parse(reader))
                {
                    return;
                }
                _tail = null;
            }
            ElementBufferReader elementBufferReader = new ElementBufferReader(_builder, reader);
            _tail = elementBufferReader.Read();
        }
    }
}
