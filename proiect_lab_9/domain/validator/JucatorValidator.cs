using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;

namespace proiect_lab_9.domain.validator
{
    class JucatorValidator : IValidator<Jucator>
    {
        private static JucatorValidator validator;
        private JucatorValidator()
        {
        }

        public static JucatorValidator GetValidator()
        {
            if (Object.ReferenceEquals(validator, null))
                validator = new JucatorValidator();
            return validator;
        }

        public void Validate(Jucator entity)
        {
        }
    }
}
