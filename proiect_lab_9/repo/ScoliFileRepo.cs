using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;
using proiect_lab_9.domain.validator;

namespace proiect_lab_9.repo
{
    class ScoliFileRepo : FileRepo<long, Institutie_Invatamant>
    {
        public ScoliFileRepo(string fileName) : base(ScoliValidator.GetValidator(), fileName)
        {
        }

        protected override Institutie_Invatamant EntityFromString(string s)
        {
            string[] fields = s.Split(';');
            return new Institutie_Invatamant(long.Parse(fields[0]), fields[1]);
        }

        protected override string StringFromEntity(Institutie_Invatamant entity)
        {
            return entity.Id + ";" + entity.Nume;
        }
    }
}
