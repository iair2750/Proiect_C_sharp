using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;
using proiect_lab_9.domain.validator;

namespace proiect_lab_9.repo
{
    class EleviFileRepo : FileRepo<long, Elev>
    {
        public EleviFileRepo(string fileName) : base(EleviValidator.GetValidator(), fileName)
        {
        }

        protected override Elev EntityFromString(string s)
        {
            string[] fields = s.Split(';');
            return new Elev(long.Parse(fields[0]), fields[1], long.Parse(fields[2]));
        }

        protected override string StringFromEntity(Elev entity)
        {
            return entity.Id + ";" + entity.Nume + ";" + entity.IdScoala;
        }

    }
}
