using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lab_9.repo
{
    class RepoException : ApplicationException
    {
        public RepoException(string mesaj) : base(mesaj)
        {
        }
    }
}
