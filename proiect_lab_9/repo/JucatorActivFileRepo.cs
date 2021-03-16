using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;
using proiect_lab_9.domain.validator;

namespace proiect_lab_9.repo
{
    class JucatorActivFileRepo : FileRepo<(long,long), JucatorActiv>
    {
        public JucatorActivFileRepo(string fileName) : base(JucatorActivValidator.GetValidator(), fileName)
        {
        }

        protected override JucatorActiv EntityFromString(string s)
        {
            string[] fields = s.Split(';');
            return new JucatorActiv(long.Parse(fields[0]), long.Parse(fields[1]), int.Parse(fields[2]),
                (Tip)Enum.Parse(typeof(Tip), fields[3]));
        }

        protected override string StringFromEntity(JucatorActiv entity)
        {
            return entity.IdJucator + ";" + entity.IdMeci + ";" + entity.PuncteInscrise + ";" + entity.TipCurent;
        }
    }
}
