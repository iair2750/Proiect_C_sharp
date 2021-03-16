using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;

namespace proiect_lab_9.domain.validator
{
    class MeciValidator : IValidator<Meci>
    {
        private static MeciValidator validator;
        private MeciValidator()
        {
        }

        public static MeciValidator GetValidator()
        {
            if (Object.ReferenceEquals(validator, null))
                validator = new MeciValidator();
            return validator;
        }

        public void Validate(Meci entity)
        {
            string exceptii = "";
            if (entity.Oaspeti == entity.Gazde)
                exceptii += "Meciul trebuie sa se dispute intre echipe diferite!\n";
            if (exceptii != "")
                throw new ValidationException(exceptii);
        }
    }
}
