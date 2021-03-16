using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lab_9.domain
{
    class Meci : Entity<long>
    {
        private static long static_id = 0;
        private long gazde;
        private long oaspeti;
        private DateTime data;

        public Meci(long gazde, long oaspeti, DateTime data) : base(++static_id)
        {
            this.gazde = gazde;
            this.oaspeti = oaspeti;
            this.data = data;
        }

        public Meci(long id, long gazde, long oaspeti, DateTime data) : base(id)
        {
            this.gazde = gazde;
            this.oaspeti = oaspeti;
            this.data = data;
            if (id > static_id)
                static_id = id;
        }

        public long Gazde
        {
            get
            {
                return gazde;
            }
        }

        public long Oaspeti
        {
            get
            {
                return oaspeti;
            }
        }

        public DateTime Data
        {
            get
            {
                
                return data;
            }
        }

        public override string ToString()
        {
            return "Meci " + Id + ", data " + data.ToShortDateString();
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (Object.ReferenceEquals(obj, null))
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            Meci meci = (Meci)obj;
            return this.data == meci.data && (
                (this.oaspeti == meci.oaspeti && this.gazde == meci.gazde) ||
                (this.oaspeti == meci.gazde && this.gazde == meci.oaspeti)
                );
        }

        public override int GetHashCode()
        {
            return (data, oaspeti, gazde).GetHashCode();
        }

        public static bool operator ==(Meci m1, Meci m2)
        {
            if (Object.ReferenceEquals(m1, m2))
                return true;
            if (Object.ReferenceEquals(m1, null) || Object.ReferenceEquals(m2, null))
                return false;
            return m1.data == m2.data && (
                (m1.oaspeti == m2.oaspeti && m1.gazde == m2.gazde) ||
                (m1.oaspeti == m2.gazde && m1.gazde == m2.oaspeti)
                );
        }

        public static bool operator !=(Meci m1, Meci m2)
        {
            return !(m1 == m2);
        }
    }
}
