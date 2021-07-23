using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    interface IElementBuilder : IPropertyBuilder
    {
        void Marker(uint markerId);
    }
}
