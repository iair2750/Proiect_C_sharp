using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;
using proiect_lab_9.domain.validator;

namespace proiect_lab_9.repo
{
    class JucatorFileRepo : FileRepo<long, Jucator>
    {
        public JucatorFileRepo(string fileName) : base(JucatorValidator.GetValidator(), fileName)
        {
        }

        protected override Jucator EntityFromString(string s)
        {
            string[] fields = s.Split(';');
            return new Jucator(long.Parse(fields[0]), fields[1], long.Parse(fields[2]), long.Parse(fields[3]));
        }

        protected override string StringFromEntity(Jucator entity)
        {
            return entity.Id + ";" + entity.Nume + ";" + entity.IdScoala + ";" + entity.IdEchipa;
        }
    }
}
