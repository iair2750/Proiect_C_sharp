using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lab_9.domain.validator
{
    interface IValidator<E>
    {
        void Validate(E entity);
    }
}
