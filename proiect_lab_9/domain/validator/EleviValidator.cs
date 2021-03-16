using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lab_9.domain.validator
{
    class EleviValidator : IValidator<Elev>
    {
        private static EleviValidator validator;
        private EleviValidator()
        {
        }

        public static EleviValidator GetValidator()
        {
            if (Object.ReferenceEquals(validator, null))
                validator = new EleviValidator();
            return validator;
        }

        public void Validate(Elev elev)
        {
            string exceptii = "";
            if (elev.Nume.Length <= 2)
                exceptii += "Nume prea scurt!\n";
            if (elev.Nume.Any(char.IsDigit))
                exceptii += "Nu se pot folosi cifre!\n";
            if (exceptii != "")
                throw new ValidationException(exceptii);
        }

    }
}
