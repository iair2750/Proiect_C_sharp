using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;

namespace proiect_lab_9.repo
{
    interface IRepo<ID, E> where E : Entity<ID>
    {
        /**
         * throw RepoExeception if there are no entity with given id
         * return the entity otherwise
        */
        E FindOne(ID id);

        /**
         * return a IEnumerable with all entities
        */ 
        IEnumerable<E> FindAll();

        /**
         * throw:   ValidationException if the entity is not valid 
         *          RepoException if the entity is already existing or if there is other entity with same id
         * save the entity otherwise
        */
        void Save(E entity);

        /**
         * throw RepoException if there are no entity with given id
         * otherwise delete the entitiy with the given id and return it
        */
        E Delete(ID id);

        /**
         * throw ValidationException if the entity is not valid
         *          RepoException if there are no entity with id of the given entity 
         *                     or if there are another entity equal with the given entity
         * otherwise update the entity
         * return the old entity
         */
        E Update(E entity);

    }
}
