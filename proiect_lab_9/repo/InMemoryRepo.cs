using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;
using proiect_lab_9.domain.validator;

namespace proiect_lab_9.repo
{
    class InMemoryRepo<ID, E> : IRepo<ID, E> where E : Entity<ID>
    {
        protected IDictionary<ID, E> entities;
        private IValidator<E> validator;

        public InMemoryRepo(IValidator<E> validator)
        {
            entities = new Dictionary<ID, E>();
            this.validator = validator;
        }

        public E FindOne(ID id)
        {
            E entity;
            entities.TryGetValue(id, out entity);
            if (entity == default(E))
                throw new RepoException("Nu exista nicio entitate cu acest id\n"); // entity doesn't exist
            return entity;
        }

        public IEnumerable<E> FindAll()
        {
            return entities.Values;
        }

        public virtual void Save(E entity)
        {
            validator.Validate(entity);
            E other;
            entities.TryGetValue(entity.Id, out other);
            if (other != default(E))
                throw new RepoException("Id-ul exista deja\n"); // id exception
            if (FindAll().Contains(entity))
                throw new RepoException("Entitatea exista deja\n"); // entity already exist
            entities.Add(entity.Id, entity);
        }

        public virtual E Delete(ID id)
        {
            E entity;
            entities.TryGetValue(id, out entity);
            if (entity == default(E))
                throw new RepoException("Id inexistent\n");
            entities.Remove(id);
            return entity;
        }

        public virtual E Update(E entity)
        {
            validator.Validate(entity);
            E old;
            entities.TryGetValue(entity.Id, out old);
            if (old == default(E))
                throw new RepoException("Id inexistent\n"); /// no entity with given id
            if (entities.Values.Except(Enumerable.Repeat(old, 1)).Contains(entity))
                throw new RepoException("Entitatea noua exista deja\n"); /// there are other entity = with the given one (except the old with same id)
            entities[entity.Id] = entity;
            return old;
        }

    }
}
