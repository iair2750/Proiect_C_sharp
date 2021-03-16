using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lab_9.domain
{
    enum Tip
    {
        Rezerva,
        Participant
    }

    class JucatorActiv : Entity<(long,long)>
    {
        private int puncteInscrise;
        private Tip tipCurent;

        public JucatorActiv(long idJucator, long idMeci, int puncteInscrise, Tip tipCurent) : base((idJucator, idMeci))
        {
            this.puncteInscrise = puncteInscrise;
            this.tipCurent = tipCurent;
        }

        //public jucatoractiv(long id, long idjucator, long idmeci, int puncteinscrise, tip tipcurent) : base(id)
        //{
        //    this.idjucator = idjucator;
        //    this.idmeci = idmeci;
        //    this.puncteinscrise = puncteinscrise;
        //    this.tipcurent = tipcurent;
        //    if (id > static_id)
        //        static_id = id;
        //}

        public long IdJucator
        {
            get
            {
                return Id.Item1;
            }
        }

        public long IdMeci
        {
            get
            {
                return Id.Item2;
            }
        }

        public int PuncteInscrise
        {
            get
            {
                return puncteInscrise;
            }
        }

        public Tip TipCurent
        {
            get
            {
                return tipCurent;
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
            JucatorActiv ja = (JucatorActiv)obj;
            return this.Id == ja.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(JucatorActiv j1, JucatorActiv j2)
        {
            if (Object.ReferenceEquals(j1, j2))
                return true;
            if (Object.ReferenceEquals(j1, null) || Object.ReferenceEquals(j2, null))
                return false;
            return j1.Id == j2.Id;
        }

        public static bool operator !=(JucatorActiv j1, JucatorActiv j2)
        {
            return !(j1 == j2);
        }
    }
}
