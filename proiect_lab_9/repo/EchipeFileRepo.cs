using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain.validator;
using proiect_lab_9.domain;

namespace proiect_lab_9.repo
{
    class EchipeFileRepo : FileRepo<long, Echipa>
    {
        public EchipeFileRepo(string fileName) : base(EchipaValidator.GetValidator(), fileName)
        {
        }

        protected override Echipa EntityFromString(string s)
        {
            string[] fields = s.Split(';');
            return new Echipa(long.Parse(fields[0]), fields[1], long.Parse(fields[2]));
        }

        protected override string StringFromEntity(Echipa entity)
        {
            return entity.Id + ';' + entity.Nume + ';' + entity.IdScoala;
        }
    }
}
