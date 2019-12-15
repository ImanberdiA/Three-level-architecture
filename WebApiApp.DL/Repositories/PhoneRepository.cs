using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.DL.Interfaces;
using WebApiApp.DL.Models;

namespace WebApiApp.DL.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private PersonContext db;

        public PersonRepository(PersonContext db)
        {
            this.db = db;
        }

        public void Create(Person item)
        {
            db.Persons.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
        }

        public IEnumerable<Person> Find(Func<Person, bool> predicate)
        {
            return db.Persons.Where(predicate).ToList();
        }

        public Person Get(int id)
        {
            return db.Persons.Find(id);
        }

        public IEnumerable<Person> GetAll()
        {
            return db.Persons.ToList();
        }

        public void Update(Person item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
