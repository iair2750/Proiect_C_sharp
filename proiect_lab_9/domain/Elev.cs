using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.HashCode;

namespace proiect_lab_9.domain
{
    class Elev : Entity<long>
    {
        private static long static_id = 0;
        protected string nume;
        protected long id_scoala;

        public Elev(string nume, long id_scoala) : base(++static_id)
        {
            this.nume = nume;
            this.id_scoala = id_scoala;
        }

        public Elev(long id, string nume, long id_scoala) : base(id)
        {
            this.nume = nume;
            this.id_scoala = id_scoala;
            if (id > static_id)
                static_id = id;
        }

        public Elev(Elev other) : base(other)
        {
            this.nume = other.nume;
            this.id_scoala = other.id_scoala;
        }

        public string Nume 
        {
            get 
            {
                return nume;
            }
        }

        public long IdScoala
        {
            get
            {
                return id_scoala;
            }
        }

        public override string ToString()
        {
            return "Elev " + Id + ": " + nume;
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj)) 
                return true;
            if (Object.ReferenceEquals(obj, null))
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            Elev elev = (Elev)obj;
            return this.nume == elev.nume && this.id_scoala == elev.id_scoala;
        }

        public override int GetHashCode()
        {
            return (nume, id_scoala).GetHashCode();
        }

        public static bool operator ==(Elev e1, Elev e2)
        {
            if (Object.ReferenceEquals(e1, e2))
                return true;
            if (Object.ReferenceEquals(e1, null))
                return false;
            if (Object.ReferenceEquals(e2, null))
                return false;
            return e1.nume == e2.nume && e1.id_scoala == e2.id_scoala;
        }

        public static bool operator !=(Elev e1, Elev e2)
        {
            return !(e1 == e2);
        }
    }
}
