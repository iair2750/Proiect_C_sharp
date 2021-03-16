using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lab_9.domain
{
    class Echipa : Entity<long>
    {
        private static long static_id = 0;
        private string nume;
        private long id_scoala;

        public Echipa(string nume, long id_scoala) : base(++static_id)
        {
            this.nume = nume;
            this.id_scoala = id_scoala;
        }

        public Echipa(long id, string nume, long id_scoala) : base(id)
        {
            this.nume = nume;
            this.id_scoala = id_scoala;
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

        public long IdScoala
        {
            get
            {
                return id_scoala;
            }
        }

        public override string ToString()
        {
            return "Echipa " + Id + ": " + nume;
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj, this))
                return true;
            if (Object.ReferenceEquals(obj, null))
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            Echipa echipa = (Echipa)obj;
            return this.nume == echipa.nume;
        }

        public override int GetHashCode()
        {
            return nume.GetHashCode();
        }

        public static bool operator ==(Echipa e1, Echipa e2)
        {
            if (Object.ReferenceEquals(e1, e2))
                return true;
            if (Object.ReferenceEquals(e1, null) || Object.ReferenceEquals(e2, null))
                return false;
            return e1.nume == e2.nume;
        }
        
        public static bool operator !=(Echipa e1, Echipa e2)
        {
            return !(e1 == e2);
        }

    }
}
