using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;
using proiect_lab_9.domain.validator;

namespace proiect_lab_9.repo
{
    class MeciFileRepo : FileRepo<long, Meci>
    {
        public MeciFileRepo(string fileName) : base(MeciValidator.GetValidator(), fileName)
        {
        }

        protected override Meci EntityFromString(string s)
        {
            string[] fields = s.Split(';');
            return new Meci(long.Parse(fields[0]), long.Parse(fields[1]), long.Parse(fields[2]), DateTime.Parse(fields[3]));
        }

        protected override string StringFromEntity(Meci entity)
        {
            return entity.Id + ";" + entity.Gazde + ";" + entity.Oaspeti + ";" + entity.Data;
        }
    }
}
