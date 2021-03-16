using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lab_9.domain
{
    abstract class Entity<TID>
    {
        private TID id;

        protected Entity(TID id)
        {
            this.id = id;
        }

        protected Entity(Entity<TID> other)
        {
            this.id = other.id;
        }

        public TID Id
        {
            get
            {
                return id;
            }
        }

    }
}
