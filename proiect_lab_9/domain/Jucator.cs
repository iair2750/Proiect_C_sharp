using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lab_9.domain
{
    class Jucator : Elev
    {
        private long id_echipa;

        public Jucator(long id, string nume, long id_scoala, long id_echipa) : base(id, nume, id_scoala)
        {
            this.id_echipa = id_echipa;
        }

        public Jucator(Elev e, long id_echipa) : base(e)
        {
            this.id_echipa = id_echipa;
        }

        public long IdEchipa
        {
            get
            {
                return id_echipa;
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
            Jucator jucator = (Jucator)obj;
            return this.nume == jucator.nume && this.id_scoala == jucator.id_scoala && this.id_echipa == jucator.id_echipa;
        }

        public override int GetHashCode()
        {
            return (nume, id_scoala, id_echipa).GetHashCode();
        }

        public static bool operator ==(Jucator j1, Jucator j2)
        {
            if (Object.ReferenceEquals(j1, j2))
                return true;
            if (Object.ReferenceEquals(j1, null) || Object.ReferenceEquals(j2, null))
                return false;
            return j1.nume == j2.nume && j1.id_scoala == j2.id_scoala && j1.id_echipa == j2.id_echipa;
        }

        public static bool operator !=(Jucator j1, Jucator j2)
        {
            return !(j1 == j2);
        }
    }
}
