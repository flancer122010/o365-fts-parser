using MailFTSParsers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFTSParsers.Models
{
    public class PropertyId : IComparable<PropertyId>, IEquatable<PropertyId>
    {
        private uint tag;

        private Guid propset;

        private int id;

        private string name;
        public uint Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
            }
        }

        public Guid PropSet
        {
            get
            {
                return propset;
            }
            set
            {
                propset = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public bool IsTag
        {
            get { return tag != uint.MaxValue; }
        }


        public MSFTProperty PropertyType
        {
            get
            {
                if (id != 2147483647)
                {
                    return MSFTProperty.Id;
                }
                return MSFTProperty.Name;
            }
        }

        public PropertyId(uint t)
        {
            tag = t;
            propset = Guid.Empty;
            id = 2147483647;
            name = string.Empty;
        }

        public PropertyId(Guid n, int i)
        {
            tag = uint.MaxValue;
            propset = n;
            id = i;
            name = string.Empty;
        }

        public PropertyId(Guid n, string s)
        {
            tag = uint.MaxValue;
            propset = n;
            id = 2147483647;
            name = s;
        }

        public int CompareTo(PropertyId other)
        {
            if (tag > other.tag)
            {
                return 1;
            }
            if (tag < other.tag)
            {
                return -1;
            }
            int num = propset.CompareTo(other.propset);
            if (num != 0)
            {
                return num;
            }
            int num2 = id.CompareTo(other.id);
            if (num2 != 0)
            {
                return num2;
            }
            return name.CompareTo(other.name);
        }

        private static int Compare(PropertyId left, PropertyId right)
        {
            if ((object)left == right)
            {
                return 0;
            }
            return left?.CompareTo(right) ?? (-1);
        }

        public static bool operator <(PropertyId left, PropertyId right)
        {
            return Compare(left, right) < 0;
        }

        public static bool operator >(PropertyId left, PropertyId right)
        {
            return Compare(left, right) > 0;
        }

        public bool Equals(PropertyId other)
        {
            if ((object)other == null)
            {
                return false;
            }
            if ((object)this == other)
            {
                return true;
            }
            if (other.tag == tag && other.propset.Equals(propset) && other.id == id)
            {
                return object.Equals(other.name, name);
            }
            return false;
        }

        public static bool operator ==(PropertyId left, PropertyId right)
        {
            return object.Equals(left, right);
        }

        public static bool operator !=(PropertyId left, PropertyId right)
        {
            return !object.Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (this == obj)
            {
                return true;
            }
            if (obj.GetType() != typeof(PropertyId))
            {
                return false;
            }
            return Equals((PropertyId)obj);
        }

        public override int GetHashCode()
        {
            return ((tag.GetHashCode() * 397 ^ propset.GetHashCode()) * 397 ^ id) * 397 ^ ((name != null) ? name.GetHashCode() : 0);
        }

        public override string ToString()
        {
            if (IsTag)
            {
                return $"0x{tag:X8}";
            }
            if (PropertyType == MSFTProperty.Id)
            {
                return $"{propset}\\{id:X8}";
            }
            return $"{propset}\\{name}";
        }
    }

}
