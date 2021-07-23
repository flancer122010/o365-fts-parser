using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public static class MAPIProps
    {
        public const uint PR_ROWID = 805306371u;

        public const uint PR_FOLDER_TYPE = 906035203u;

        public const uint PR_CONTAINER_CLASS = 907214879u;

        public const uint PR_DISPLAY_NAME = 805371935u;

        public const uint PR_DISPLAY_TYPE = 956301315u;

        public const uint PR_7BIT_DISPLAY_NAME = 973013023u;

        public const uint PR_ATTR_HIDDEN = 284426251u;

        public const uint PR_SUBFOLDERS = 906625035u;

        public const uint PR_FOLDER_CHILD_COUNT = 1714946051u;

        public const uint PR_MESSAGE_CLASS = 1703967u;

        public const uint PR_MESSAGE_FLAGS = 235339779u;

        public const uint PR_MESSAGE_RECIPIENTS = 236060685u;

        public const uint PR_MESSAGE_ATTACHMENTS = 236126221u;

        public const uint PR_MESSAGE_SIZE = 235405315u;

        public const uint PR_NORMAL_MESSAGE_SIZE_EXTENDED = 1723006996u;

        public const uint PR_CHANGE_KEY = 1709310210u;

        public const uint PR_SENDER_NAME = 203030559u;

        public const uint PR_SENDER_ENTRYID = 202965250u;

        public const uint PR_SENDER_ADDRTYPE = 203292703u;

        public const uint PR_SENDER_EMAIL_ADDRESS = 203358239u;

        public const uint PR_SENDER_SEARCH_KEY = 203227394u;

        public const uint PR_SENDER_GUID = 239075586u;

        public const uint PR_SENT_REPRESENTING_NAME = 4325407u;

        public const uint PR_SENT_REPRESENTING_ENTRYID = 4260098u;

        public const uint PR_SENT_REPRESENTING_ADDRTYPE = 6553631u;

        public const uint PR_SENT_REPRESENTING_EMAIL_ADDRESS = 6619167u;

        public const uint PR_SENT_REPRESENTING_SEARCH_KEY = 3866882u;

        public const uint PR_RECEIVED_BY_ENTRYID = 4129026u;

        public const uint PR_RECEIVED_BY_EMAIL_ADDRESS = 7733279u;

        public const uint PR_RECEIVED_BY_ADDRTYPE = 7667743u;

        public const uint PR_RECEIVED_BY_NAME = 4194335u;

        public const uint PR_RECEIVED_BY_SEARCH_KEY = 5308674u;

        public const uint PR_RCVD_REPRESENTING_ENTRYID = 4391170u;

        public const uint PR_RCVD_REPRESENTING_EMAIL_ADDRESS = 7864351u;

        public const uint PR_RCVD_REPRESENTING_ADDRTYPE = 7798815u;

        public const uint PR_RCVD_REPRESENTING_NAME = 4456479u;

        public const uint PR_RCVD_REPRESENTING_SEARCH_KEY = 5374210u;

        public const uint PR_DISPLAY_TO = 235143199u;

        public const uint PR_DISPLAY_CC = 235077663u;

        public const uint PR_DISPLAY_BCC = 235012127u;

        public const uint PR_COMMENT = 805568543u;

        public const uint PR_CREATION_TIME = 805765184u;

        public const uint PR_LAST_MODIFICATION_TIME = 805830720u;

        public const uint PR_MESSAGE_DELIVERY_TIME = 235274304u;

        public const uint PR_CLIENT_SUBMIT_TIME = 3735616u;

        public const uint PR_PROVIDER_SUBMIT_TIME = 4718656u;

        public const uint PR_START_DATE = 6291520u;

        public const uint PR_END_DATE = 6357056u;

        public const uint PR_SUBJECT_PREFIX = 3997727u;

        public const uint PR_NORMALIZED_SUBJECT = 236781599u;

        public const uint PR_SUBJECT = 3604511u;

        public const uint PR_CONTENT_COUNT = 906100739u;

        public const uint PR_DELETED_COUNT_TOTAL = 1728774147u;

        public const uint PR_CONVERSATION_INDEX = 7405826u;

        public const uint PR_CONVERSATION_INDEX_TRACKING = 806748171u;

        public const uint PR_CONVERSATION_ID = 806551810u;

        public const uint PR_CONVERSATION_TOPIC = 7340063u;

        public const uint PR_INTERNET_CPID = 1071513603u;

        public const uint PR_MESSAGE_CODEPAGE = 1073545219u;

        public const uint PR_ATTACH_CONTENT_ID = 923926559u;

        public const uint PR_ATTACH_ENCODING = 922878210u;

        public const uint PR_ATTACH_EXTENSION = 922943519u;

        public const uint PR_ATTACH_FILENAME = 923009055u;

        public const uint PR_ATTACH_METHOD = 923074563u;

        public const uint PR_ATTACH_LONG_FILENAME = 923205663u;

        public const uint PR_ATTACH_MIME_TAG = 923664415u;

        public const uint PR_ATTACH_CONTENT_LOCATION = 923992095u;

        public const uint PR_ATTACH_SIZE = 236978179u;

        public const uint PR_ATTACHMENT_HIDDEN = 2147352587u;

        public const uint PR_ATTACH_PATHNAME = 923271199u;

        public const uint PR_ATTACH_LONG_PATHNAME = 923598879u;

        public const uint PR_ATTACHMENT_LINKID = 2147090435u;

        public const uint PR_ATTACH_TAG = 923402498u;

        public const uint PR_ATTACH_FLAGS = 924057603u;

        public const uint PR_ATTACHMENT_FLAGS = 2147287043u;

        public const uint PR_ATTACHMENT_CONTACTPHOTO = 2147418123u;

        public const uint PR_ATTACH_RENDERING = 923336962u;

        public const uint PR_EXCEPTION_STARTTIME = 2147156032u;

        public const uint PR_EXCEPTION_ENDTIME = 2147221568u;

        public const uint PR_ACKNOWLEDGEMENT_MODE = 65539u;

        public const uint PR_ALTERNATE_RECIPIENT_ALLOWED = 131083u;

        public const uint PR_AUTHORIZING_USERS = 196866u;

        public const uint PR_AUTO_FORWARD_COMMENT = 262175u;

        public const uint PR_AUTO_FORWARDED = 327691u;

        public const uint PR_CONTENT_CONFIDENTIALITY_ALGORITHM_ID = 393474u;

        public const uint PR_CONTENT_CORRELATOR = 459010u;

        public const uint PR_CONTENT_IDENTIFIER = 524319u;

        public const uint PR_CONTENT_LENGTH = 589827u;

        public const uint PR_CONTENT_RETURN_REQUESTED = 655371u;

        public const uint PR_CONVERSATION_KEY = 721154u;

        public const uint PR_CONVERSION_EITS = 786690u;

        public const uint PR_CONVERSION_WITH_LOSS_PROHIBITED = 851979u;

        public const uint PR_CONVERTED_EITS = 917762u;

        public const uint PR_DEFERRED_DELIVERY_TIME = 983104u;

        public const uint PR_DELIVER_TIME = 1048640u;

        public const uint PR_DISCARD_REASON = 1114115u;

        public const uint PR_DISCLOSURE_OF_RECIPIENTS = 1179659u;

        public const uint PR_DL_EXPANSION_HISTORY = 1245442u;

        public const uint PR_DL_EXPANSION_PROHIBITED = 1310731u;

        public const uint PR_EXPIRY_TIME = 1376320u;

        public const uint PR_IMPLICIT_CONVERSION_PROHIBITED = 1441803u;

        public const uint PR_IMPORTANCE = 1507331u;

        public const uint PR_SENSITIVITY = 3538947u;

        public const uint PR_IPM_ID = 1573122u;

        public const uint PR_LATEST_DELIVERY_TIME = 1638464u;

        public const uint PR_MESSAGE_DELIVERY_ID = 1769730u;

        public const uint PR_MESSAGE_SECURITY_LABEL = 1966338u;

        public const uint PR_OBSOLETED_IPMS = 2031874u;

        public const uint PR_ORIGINALLY_INTENDED_RECIPIENT_NAME = 2097410u;

        public const uint PR_ORIGINAL_EITS = 2162946u;

        public const uint PR_ORIGINATOR_CERTIFICATE = 2228482u;

        public const uint PR_ORIGINATOR_DELIVERY_REPORT_REQUESTED = 2293771u;

        public const uint PR_ORIGINATOR_RETURN_ADDRESS = 2359554u;

        public const uint PR_PARENT_KEY = 2425090u;

        public const uint PR_PRIORITY = 2490371u;

        public const uint PR_ORIGINAL_SEARCH_KEY = 974389506u;

        public const uint PR_ORIGINAL_SENDER_ENTRYID = 5964034u;

        public const uint PR_ORIGINAL_SENDER_EMAIL_ADDRESS = 6750239u;

        public const uint PR_ORIGINAL_SENDER_ADDRTYPE = 6684703u;

        public const uint PR_ORIGINAL_SENDER_NAME = 5898271u;

        public const uint PR_ORIGINAL_SENDER_SEARCH_KEY = 6029570u;

        public const uint PR_ORIGINAL_SENT_REPRESENTING_ENTRYID = 6160642u;

        public const uint PR_ORIGINAL_SENT_REPRESENTING_EMAIL_ADDRESS = 6881311u;

        public const uint PR_ORIGINAL_SENT_REPRESENTING_ADDRTYPE = 6815775u;

        public const uint PR_ORIGINAL_SENT_REPRESENTING_NAME = 6094879u;

        public const uint PR_ORIGINAL_SENT_REPRESENTING_SEARCH_KEY = 6226178u;

        public const uint PR_RECIPIENT_DATA = 1739849986u;

        public const uint PR_ACCESS = 267649027u;

        public const uint PR_ACCESS_LEVEL = 267845635u;

        public const uint PR_BODY = 268435487u;

        public const uint PR_HTML = 269680898u;

        public const uint PR_MSG_EDITOR_FORMAT = 1493762051u;

        public const uint PR_STORE_SUPPORT_MASK = 873267203u;

        public const uint PR_RTF_SYNC_BODY_COUNT = 268894211u;

        public const uint PR_RTF_SYNC_BODY_CRC = 268828675u;

        public const uint PR_RTF_SYNC_BODY_TAG = 268959775u;

        public const uint PR_RTF_SYNC_PREFIX_COUNT = 269484035u;

        public const uint PR_RTF_SYNC_TRAILING_COUNT = 269549571u;

        public const uint PR_RTF_IN_SYNC = 236912651u;

        public const uint PR_RTF_COMPRESSED = 269025538u;

        public const uint PR_SEARCH_KEY = 806027522u;

        public const uint PR_HASATTACH = 236650507u;

        public const uint PR_OBJECT_TYPE = 268304387u;

        public const uint PR_ATTACH_NUM = 237043715u;

        public const uint PR_RECORD_KEY = 267976962u;

        public const uint PR_RENDERING_POSITION = 923467779u;

        public const uint PR_ATTACH_DATA_OBJ = 922812429u;

        public const uint PR_ATTACH_DATA_BIN = 922812674u;

        public const uint PR_IPM_WASTEBASKET_ENTRYID = 904069378u;

        public const uint PR_MailboxMiscFlags = 1745223683u;

        public const uint PR_MailboxFlags = 1722220547u;

        public const uint PR_ADDITIONAL_REN_ENTRYIDS = 920129794u;

        public const uint PR_ACCOUNT = 973078559u;

        public const uint PR_ALTERNATE_RECIPIENT = 973144322u;

        public const uint PR_CALLBACK_TELEPHONE_NUMBER = 973209631u;

        public const uint PR_CONVERSION_PROHIBITED = 973275147u;

        public const uint PR_DISCLOSE_RECIPIENTS = 973340683u;

        public const uint PR_GENERATION = 973406239u;

        public const uint PR_GIVEN_NAME = 973471775u;

        public const uint PR_GOVERNMENT_ID_NUMBER = 973537311u;

        public const uint PR_BUSINESS_TELEPHONE_NUMBER = 973602847u;

        public const uint PR_OFFICE_TELEPHONE_NUMBER = 973602847u;

        public const uint PR_HOME_TELEPHONE_NUMBER = 973668383u;

        public const uint PR_INITIALS = 973733919u;

        public const uint PR_KEYWORD = 973799455u;

        public const uint PR_LANGUAGE = 973864991u;

        public const uint PR_LOCATION = 973930527u;

        public const uint PR_MAIL_PERMISSION = 973996043u;

        public const uint PR_MHS_COMMON_NAME = 974061599u;

        public const uint PR_ORGANIZATIONAL_ID_NUMBER = 974127135u;

        public const uint PR_SURNAME = 974192671u;

        public const uint PR_ORIGINAL_DISPLAY_NAME = 974323743u;

        public const uint PR_POSTAL_ADDRESS = 974454815u;

        public const uint PR_COMPANY_NAME = 974520351u;

        public const uint PR_TITLE = 974585887u;

        public const uint PR_DEPARTMENT_NAME = 974651423u;

        public const uint PR_OFFICE_LOCATION = 974716959u;

        public const uint PR_PRIMARY_TELEPHONE_NUMBER = 974782495u;

        public const uint PR_BUSINESS2_TELEPHONE_NUMBER = 974848031u;

        public const uint PR_OFFICE2_TELEPHONE_NUMBER = 974848031u;

        public const uint PR_MOBILE_TELEPHONE_NUMBER = 974913567u;

        public const uint PR_CELLULAR_TELEPHONE_NUMBER = 974913567u;

        public const uint PR_RADIO_TELEPHONE_NUMBER = 974979103u;

        public const uint PR_CAR_TELEPHONE_NUMBER = 975044639u;

        public const uint PR_OTHER_TELEPHONE_NUMBER = 975110175u;

        public const uint PR_TRANSMITABLE_DISPLAY_NAME = 975175711u;

        public const uint PR_PAGER_TELEPHONE_NUMBER = 975241247u;

        public const uint PR_BEEPER_TELEPHONE_NUMBER = 975241247u;

        public const uint PR_USER_CERTIFICATE = 975307010u;

        public const uint PR_PRIMARY_FAX_NUMBER = 975372319u;

        public const uint PR_BUSINESS_FAX_NUMBER = 975437855u;

        public const uint PR_HOME_FAX_NUMBER = 975503391u;

        public const uint PR_COUNTRY = 975568927u;

        public const uint PR_BUSINESS_ADDRESS_COUNTRY = 975568927u;

        public const uint PR_LOCALITY = 975634463u;

        public const uint PR_BUSINESS_ADDRESS_CITY = 975634463u;

        public const uint PR_STATE_OR_PROVINCE = 975699999u;

        public const uint PR_BUSINESS_ADDRESS_STATE_OR_PROVINCE = 975699999u;

        public const uint PR_STREET_ADDRESS = 975765535u;

        public const uint PR_BUSINESS_ADDRESS_STREET = 975765535u;

        public const uint PR_POSTAL_CODE = 975831071u;

        public const uint PR_BUSINESS_ADDRESS_POSTAL_CODE = 975831071u;

        public const uint PR_POST_OFFICE_BOX = 975896607u;

        public const uint PR_BUSINESS_ADDRESS_POST_OFFICE_BOX = 975896607u;

        public const uint PR_TELEX_NUMBER = 975962143u;

        public const uint PR_ISDN_NUMBER = 976027679u;

        public const uint PR_ASSISTANT_TELEPHONE_NUMBER = 976093215u;

        public const uint PR_HOME2_TELEPHONE_NUMBER = 976158751u;

        public const uint PR_ASSISTANT = 976224287u;

        public const uint PR_SEND_RICH_INFO = 977272843u;

        public const uint PR_WEDDING_ANNIVERSARY = 977338432u;

        public const uint PR_BIRTHDAY = 977403968u;

        public const uint PR_HOBBIES = 977469471u;

        public const uint PR_MIDDLE_NAME = 977535007u;

        public const uint PR_DISPLAY_NAME_PREFIX = 977600543u;

        public const uint PR_PROFESSION = 977666079u;

        public const uint PR_PREFERRED_BY_NAME = 977731615u;

        public const uint PR_SPOUSE_NAME = 977797151u;

        public const uint PR_COMPUTER_NETWORK_NAME = 977862687u;

        public const uint PR_CUSTOMER_ID = 977928223u;

        public const uint PR_TTYTDD_PHONE_NUMBER = 977993759u;

        public const uint PR_FTP_SITE = 978059295u;

        public const uint PR_MANAGER_NAME = 978190367u;

        public const uint PR_NICKNAME = 978255903u;

        public const uint PR_PERSONAL_HOME_PAGE = 978321439u;

        public const uint PR_BUSINESS_HOME_PAGE = 978386975u;

        public const uint PR_CONTACT_DEFAULT_ADDRESS_INDEX = 978649091u;

        public const uint PR_COMPANY_MAIN_PHONE_NUMBER = 978780191u;

        public const uint PR_HOME_ADDRESS_CITY = 978911263u;

        public const uint PR_HOME_ADDRESS_COUNTRY = 978976799u;

        public const uint PR_HOME_ADDRESS_POSTAL_CODE = 979042335u;

        public const uint PR_HOME_ADDRESS_STATE_OR_PROVINCE = 979107871u;

        public const uint PR_HOME_ADDRESS_STREET = 979173407u;

        public const uint PR_HOME_ADDRESS_POST_OFFICE_BOX = 979238943u;

        public const uint PR_OTHER_ADDRESS_CITY = 979304479u;

        public const uint PR_OTHER_ADDRESS_COUNTRY = 979370015u;

        public const uint PR_OTHER_ADDRESS_POSTAL_CODE = 979435551u;

        public const uint PR_OTHER_ADDRESS_STATE_OR_PROVINCE = 979501087u;

        public const uint PR_OTHER_ADDRESS_STREET = 979566623u;

        public const uint PR_OTHER_ADDRESS_POST_OFFICE_BOX = 979632159u;

        public const uint PR_OUTLOOK_LOCATION = 2147745823u;

        public const uint PR_OUTLOOK_FILE_AS = 2148663327u;

        public const uint PR_OUTLOOK_EMAIL1_DISPLAY_NAME = 2148401183u;

        public const uint PR_OUTLOOK_EMAIL1_ADDRESS = 2149187615u;

        public const uint PR_OUTLOOK_IM_ADDRESS = 2149384223u;

        public const uint PR_OUTLOOK_TASK_START_DATE = 2157248576u;

        public const uint PR_OUTLOOK_TASK_END_DATE = 2157183040u;

        public const uint PR_OUTLOOK_PERCENTAGE_COMPLETE = 2157576197u;

        public const uint PR_OUTLOOK_TASK_OWNER = 2148925471u;

        public const uint PR_OUTLOOK_TASK_STATUS = 2157445123u;

        /// <summary>
        ///     0 => Message Originator
        ///     1 => Primary Recipient
        ///     2 => Cc
        ///     3 => BCc
        /// </summary>
        public const uint PR_RECIPIENT_TYPE = 202702851u;

        public const uint PR_ADDRTYPE = 805437471u;

        public const uint PR_EMAIL_ADDRESS = 805503007u;

        public const uint PR_RECIPIENT_DISPLAY_NAME = 1609957407u;

        public const uint PR_SMTP_ADDRESS = 972947487u;

        public const uint PidTagSenderSmtpAddress = 1560346655u;

        public const uint PR_ENTRYID = 268370178u;

        public const uint PR_RECIPIENT_ENTRYID = 1610023170u;

        public const uint PR_PARENT_ENTRYID = 235471106u;

        public const uint PR_MSG_STATUS = 236388355u;

        public const uint PR_NT_SECURITY_DESCRIPTOR = 237437186u;

        public const uint PR_ACL_TABLE_AND_SECURITY_DESCRIPTOR = 239010050u;

        public const uint PR_SubmitResponsibility = 1739259907u;

        public const uint PR_READ_RECEIPT_REQUESTED = 2686987u;

        public const uint PR_TRANSPORT_MESSAGE_HEADERS = 8192031u;

        public const uint PidTagItemTemporaryFlags = 278331395u;

        public const uint PidSharedDeleteTime = 1720647744u;

        public const uint PR_IPM_DRAFTS_ENTRYID = 920060162u;

        public const uint PR_APPOINTMENT_END_DATE = 6357056u;

        public const uint PR_APPOINTMENT_START_DATE = 6291520u;

        public const uint PR_SUBMITTED_TIME = 3735616u;


        public static uint Type(uint tag)
        {
            return tag & 0xFFFF;
        }

        public static uint Id(uint tag)
        {
            return tag >> 16;
        }

        public static uint Tag(uint id, uint type)
        {
            return id << 16 | type;
        }

        public static bool IsNamedProp(uint tag)
        {
            return Id(tag) >= 32768;
        }
    }
}
