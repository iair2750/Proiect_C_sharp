using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lab_9.domain
{
    class Institutie_Invatamant : Entity<long>
    {
        private static long static_id = 0;
        private string nume;

        public Institutie_Invatamant(string nume) : base(++static_id)
        {
            this.nume = nume;
        }

        public Institutie_Invatamant(long id, string nume) : base(id)
        {
            this.nume = nume;
            if (id > static_id)
                static_id = id;
        }

        public string Nume
        {
            get
            {
                return nume;
            }
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (Object.ReferenceEquals(obj, null))
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            Institutie_Invatamant i = (Institutie_Invatamant)obj;
            return this.nume == i.nume;
        }

        public override int GetHashCode()
        {
            return nume.GetHashCode();
            //return (nume).GetHashCode();
        }

        public override string ToString()
        {
            return nume;
        }

        public static bool operator ==(Institutie_Invatamant i1, Institutie_Invatamant i2)
        {
            if (Object.ReferenceEquals(i1, i2))
                return true;
            if (Object.ReferenceEquals(i1, null))
                return false;
            if (Object.ReferenceEquals(i2, null))
                return false;
            return i1.nume == i2.nume;
        }

        public static bool operator !=(Institutie_Invatamant i1, Institutie_Invatamant i2)
        {
            return !(i1 == i2);
        }

    }
}
