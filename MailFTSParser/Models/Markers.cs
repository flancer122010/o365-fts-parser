using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public static class Markers
    {
        public const uint StartEmbed = 1073807363u;

        public const uint EndEmbed = 1073872899u;

        public const uint StartRecip = 1073938435u;

        public const uint EndToRecip = 1074003971u;

        public const uint NewAttach = 1073741827u;

        public const uint EndAttach = 1074659331u;

        public static byte[] StartRecipBytes = BitConverter.GetBytes(1073938435u);

        public static byte[] EndToRecipBytes = BitConverter.GetBytes(1074003971u);

        public static byte[] NewAttachBytes = BitConverter.GetBytes(1073741827u);

        public static byte[] EndAttachBytes = BitConverter.GetBytes(1074659331u);

        public static byte[] StartEmbedBytes = BitConverter.GetBytes(1073807363u);

        public static byte[] EndEmbedBytes = BitConverter.GetBytes(1073872899u);
    }
}
