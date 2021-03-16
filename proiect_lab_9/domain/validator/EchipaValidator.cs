using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;

namespace proiect_lab_9.domain.validator
{
    class EchipaValidator : IValidator<Echipa>
    {
        private static EchipaValidator validator;
        private EchipaValidator()
        {
        }

        public static EchipaValidator GetValidator()
        {
            if (Object.ReferenceEquals(validator, null))
                validator = new EchipaValidator();
            return validator;
        }

        public void Validate(Echipa entity)
        {
            string errors = "";
            if (entity.Nume.Length <= 2)
                errors += "Nume invalid\n";
            if (errors != "")
                throw new ValidationException(errors);
        }
    }
}
