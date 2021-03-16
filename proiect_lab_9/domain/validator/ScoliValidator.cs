using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;

namespace proiect_lab_9.domain.validator
{
    class ScoliValidator : IValidator<Institutie_Invatamant>
    {
        private static ScoliValidator validator;
        private ScoliValidator()
        {
        }

        public static ScoliValidator GetValidator()
        {
            if (Object.ReferenceEquals(validator, null))
                validator = new ScoliValidator();
            return validator;
        }
        
        public void Validate(Institutie_Invatamant scoala)
        {
            string exceptii = "";
            string numeSc = scoala.Nume.ToLower();
            if (numeSc.StartsWith("scoala") || numeSc.StartsWith("liceul") || numeSc.StartsWith("colegiul"))
                exceptii += "Numele este invalid!\n";
            if (exceptii != "")
                throw new ValidationException(exceptii);
        }
    }
}
