using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;

namespace proiect_lab_9.domain.validator
{
    class JucatorActivValidator : IValidator<JucatorActiv>
    {
        private static JucatorActivValidator validator;
        private JucatorActivValidator()
        {
        }

        public static JucatorActivValidator GetValidator()
        {
            if (Object.ReferenceEquals(validator, null))
                validator = new JucatorActivValidator();
            return validator;
        }

        public void Validate(JucatorActiv entity)
        {
            if (entity.PuncteInscrise < 0 || (entity.TipCurent == Tip.Rezerva && entity.PuncteInscrise != 0))
                throw new ValidationException("Punctele inscrise nu sunt introduse corect!\n");
        }
    }
}
