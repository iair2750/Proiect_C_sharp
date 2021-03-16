using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lab_9.service
{
    class ServiceException : ApplicationException
    {
        public ServiceException(string mesaj) : base(mesaj)
        {
        }
    }
}
