using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    class ItemTreeBuilder : IElementBuilder
    {
        private const uint Check = 0u;

        private readonly IItemTreeBuilder _builder;

        private Func<uint, bool> _state;

        private int _level;

        private bool Embedded => _level > 0;

        internal ItemTreeBuilder(IItemTreeBuilder builder)
        {
            _builder = builder;
            _state = InitState;
        }

        public void Marker(uint markerId)
        {
            if (_state(markerId))
            {
                return;
            }
            //throw new ParseError(string.Format(Resources.ErrUnexpectedMarker, markerId), null);
        }

        internal void FinalCheck()
        {
            if (_state(0u))
            {
                return;
            }
            //throw new ParseError(Resources.ErrUnexpectedEndOfStream, null);
        }

        public void Prop(byte[] stream, PropertyId propertyId, byte[] value, IValueParser parser)
        {
            _builder.Prop(stream, propertyId, value, parser);
        }

        public void PropMV(byte[] stream, PropertyId propertyId, byte[][] value, IValueParser parser)
        {
            _builder.PropMV(stream, propertyId, value, parser);
        }

        private bool InitState(uint markerId)
        {
            _builder.SetItemProps();
            switch (markerId)
            {
                case 1073938435u:
                    _builder.StartRecipient();
                    _state = RecipState;
                    break;
                case 1073741827u:
                    _builder.StartAttach();
                    _state = NewAttachState;
                    break;
                case 0u:
                    _state = null;
                    break;
                default:
                    return false;
            }
            return true;
        }

        private bool RecipState(uint markerId)
        {
            if (markerId != 1074003971)
            {
                return false;
            }
            _builder.EndRecipient();
            _state = RecipAttachState;
            return true;
        }

        private bool NewAttachState(uint markerId)
        {
            switch (markerId)
            {
                case 1074659331u:
                    _builder.EndAttach();
                    _state = AttachesState;
                    break;
                case 1073807363u:
                    _level++;
                    _builder.StartEmbeddedItem();
                    _state = EmbedProps;
                    break;
                default:
                    return false;
            }
            return true;
        }

        private bool RecipAttachState(uint markerId)
        {
            bool result = true;
            switch (markerId)
            {
                case 1073938435u:
                    _builder.StartRecipient();
                    _state = RecipState;
                    break;
                case 1073741827u:
                    _builder.StartAttach();
                    _state = NewAttachState;
                    break;
                case 1073872899u:
                    if (Embedded)
                    {
                        _state = EndEmbedAttach;
                    }
                    else
                    {
                        result = false;
                    }
                    break;
            }
            return result;
        }

        private bool AttachesState(uint markerId)
        {
            if (Embedded)
            {
                switch (markerId)
                {
                    case 1073741827u:
                        _builder.StartAttach();
                        _state = NewAttachState;
                        break;
                    case 1073872899u:
                        _state = EndEmbedAttach;
                        break;
                    default:
                        return false;
                }
                return true;
            }
            switch (markerId)
            {
                case 0u:
                    return true;
                default:
                    return false;
                case 1073741827u:
                    _builder.StartAttach();
                    _state = NewAttachState;
                    return true;
            }
        }

        private bool EmbedProps(uint markerId)
        {
            switch (markerId)
            {
                case 1073872899u:
                    _builder.SetItemProps();
                    _state = EndEmbedAttach;
                    break;
                case 1073938435u:
                    _builder.SetItemProps();
                    _builder.StartRecipient();
                    _state = RecipState;
                    break;
                case 1073741827u:
                    _builder.SetItemProps();
                    _builder.StartAttach();
                    _state = NewAttachState;
                    break;
                default:
                    return false;
            }
            return true;
        }

        private bool EndEmbedAttach(uint markerId)
        {
            if (markerId != 1074659331)
            {
                return false;
            }
            _level--;
            _builder.EndEmbeddedItem();
            _state = AttachesState;
            return true;
        }
    }
}
