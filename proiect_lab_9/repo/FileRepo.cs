using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_lab_9.domain;
using proiect_lab_9.domain.validator;
using System.IO;

namespace proiect_lab_9.repo
{
    abstract class FileRepo<ID, E> : InMemoryRepo<ID, E> where E : Entity<ID>
    {
        private string fileName;

        protected FileRepo(IValidator<E> validator, string fileName) : base(validator)
        {
            this.fileName = fileName;
            LoadData();
        }

        //load all data from file
        private void LoadData()
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    E entity = EntityFromString(line);
                    entities.Add(entity.Id, entity);
                }
            }

        }

        protected abstract E EntityFromString(string s);
        protected abstract string StringFromEntity(E entity);

        //update all data to file
        private void UpdateData()
        {
            using(StreamWriter sw = new StreamWriter(fileName, false))
            {
                foreach(E entity in base.FindAll())
                {
                    sw.WriteLine(StringFromEntity(entity));
                }
            }
        }

        //push back the entity
        private void AddData(E entity)
        {
            using(StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(StringFromEntity(entity));
            }
        }

        public override void Save(E entity)
        {
            base.Save(entity);
            AddData(entity);
        }

        public override E Delete(ID id)
        {
            E entity = base.Delete(id);
            UpdateData();
            return entity;
        }

        public override E Update(E entity)
        {
            E old =  base.Update(entity);
            UpdateData();
            return old;
        }

    }
}
